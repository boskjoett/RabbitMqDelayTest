using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Messages;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Responder
{
    class Program
    {
        private const string MessageExpirationMillisecs = "60000"; // Set messages to expire after 1 minute
        private const string TopicsExchangeName = "RabbitTopics";
        private const string DirectExchangeName = "RabbitDirect";
        private const string QueueName = "ResponderQueue";
        private static IConnection? _sendConnection;
        private static IConnection? _receiveConnection;
        private static IModel? _receiveChannel;
        private static IModel? _sendChannel;
        private static EventingBasicConsumer? _consumer;
        private static int counter;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            IConfigurationRoot configuration = builder
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetConnectionString("RabbitMq");
            Console.WriteLine($"Connecting to RabbitMQ at {connectionString}");

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString)
            };

            _sendConnection = factory.CreateConnection();
            _receiveConnection = factory.CreateConnection();

            _sendChannel = _sendConnection.CreateModel();
            _receiveChannel = _receiveConnection.CreateModel();

            _receiveChannel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            // The topics exchange is used for sending C# message classes
            _receiveChannel.ExchangeDeclare(exchange: TopicsExchangeName, type: ExchangeType.Topic);

            // The direct exchange is used for replying directly back to sender.
            _receiveChannel.ExchangeDeclare(exchange: DirectExchangeName, type: ExchangeType.Direct);

            // Always bind the input queue to the direct exchange
            _receiveChannel?.QueueBind(queue: QueueName, exchange: DirectExchangeName, routingKey: QueueName);

            _receiveChannel?.BasicQos(prefetchSize: 0 /* 0 means no limit */, prefetchCount: 1, global: false);
            _receiveChannel?.QueuePurge(queue: QueueName);

            _consumer = new EventingBasicConsumer(_receiveChannel);
            _consumer.Received += OnMessageReceived;

            string routingKey = typeof(RequestMessage).ToString();
            _receiveChannel?.QueueBind(queue: QueueName, exchange: TopicsExchangeName, routingKey: routingKey);

            // Start consumer
            _receiveChannel?.BasicConsume(queue: QueueName, autoAck: true, consumer: _consumer);

            Console.WriteLine("Connected to RabbitMQ");

            if (IsRunningInContainer())
            {
                new ManualResetEvent(false).WaitOne();
            }
            else
            {
                Console.WriteLine("\nPress any key to exit");
                Console.ReadKey();
            }

            _consumer.Received -= OnMessageReceived;
            _sendChannel.Close();
            _sendChannel.Dispose();
            _receiveChannel?.Close();
            _receiveChannel?.Dispose();
            _sendConnection?.Dispose();
            _receiveConnection?.Dispose();
        }

        private static void OnMessageReceived(object? sender, BasicDeliverEventArgs e)
        {
            counter++;
            Console.WriteLine($"Message received ({counter})");

            Task.Run(() =>
            {
                string json = Encoding.UTF8.GetString(e.Body.ToArray());
                RequestMessage? request = JsonConvert.DeserializeObject<RequestMessage>(json);

                ResponseMessage response = new ResponseMessage(request!.SendTime, DateTime.Now, request.SequenceNumber, "Responder");
                json = JsonConvert.SerializeObject(response);
                var body = Encoding.UTF8.GetBytes(json);
                string routingKey = response.GetType().ToString();

                IBasicProperties props = _sendChannel!.CreateBasicProperties();
                props.Type = routingKey;
                props.CorrelationId = e.BasicProperties.CorrelationId;
                props.DeliveryMode = 1;       // Non-persistent
                props.Expiration = MessageExpirationMillisecs;

                _sendChannel.BasicPublish(exchange: DirectExchangeName, routingKey: e.BasicProperties.ReplyTo, basicProperties: props, body: body);
            });
        }

        public static bool IsRunningInContainer()
        {
            string? dotNetRunningInContainerEnvVariable = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
            if (!string.IsNullOrEmpty(dotNetRunningInContainerEnvVariable))
            {
                if (bool.TryParse(dotNetRunningInContainerEnvVariable, out bool runningInDocker))
                    return runningInDocker;
            }

            return false;
        }
    }
}