using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Messages;
using Messages.DataTypes;

namespace Requester
{
    class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private const string MessageExpirationMillisecs = "60000"; // Set messages to expire after 1 minute
        private const string TopicsExchangeName = "RabbitTopics";
        private const string DirectExchangeName = "RabbitDirect";
        private const string QueueName = "RequesterQueue";
        private static IConnection? _sendConnection;
        private static IConnection? _receiveConnection;
        private static IModel? _receiveChannel;
        private static IModel? _sendChannel;
        private static EventingBasicConsumer? _consumer;
        private static int _requests;
        private static int _replies;
        private static long _longestDelayMs;
        private static DateTime? _sendTime;
        private static JsonSerializerSettings _jsonSerializerSettings;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            IConfigurationRoot configuration = builder
                .AddEnvironmentVariables()
                .Build();

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
            };

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

            string routingKey = typeof(ResponseMessage1).ToString();
            _receiveChannel?.QueueBind(queue: QueueName, exchange: TopicsExchangeName, routingKey: routingKey);
            routingKey = typeof(ResponseMessage2).ToString();
            _receiveChannel?.QueueBind(queue: QueueName, exchange: TopicsExchangeName, routingKey: routingKey);
            routingKey = typeof(ResponseMessage3).ToString();
            _receiveChannel?.QueueBind(queue: QueueName, exchange: TopicsExchangeName, routingKey: routingKey);

            // Start consumer
            _receiveChannel?.BasicConsume(queue: QueueName, autoAck: true, consumer: _consumer);

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.WriteLine("\n\nPress");
                Console.WriteLine("'1' to make 1 request");
                Console.WriteLine("'2' to make 3 requests");
                Console.WriteLine("'3' to make 100 requests");
                Console.WriteLine("'x' to exit");

                Console.Write("\nEnter choice: ");
                keyInfo = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();

                _sendTime = DateTime.Now;

                try
                {
                    switch (keyInfo.KeyChar)
                    {
                        case '1':
                            SendRequestMessage(new SubscribeToEventsRequest(new RequestingUser(Guid.NewGuid(), "agent1@zylinc.com", 
                                new ClientInfo(Guid.NewGuid(), ClientType.Web)), SubscriptionScope.All, Guid.NewGuid(), QueueName));
                            break;

                        case '2':
                            Task.Run(() => {
                                SendRequestMessage(new SubscribeToEventsRequest(new RequestingUser(Guid.NewGuid(), "agent1@zylinc.com",
                                    new ClientInfo(Guid.NewGuid(), ClientType.Web)), SubscriptionScope.All, Guid.NewGuid(), QueueName));
                            });
                            Task.Run(() => {
                                SendRequestMessage(new GetQueuesRequest(new RequestingUser(Guid.NewGuid(), "agent1@zylinc.com", 
                                    new ClientInfo(Guid.NewGuid(), ClientType.Web)), VisibilityScope.All, Guid.NewGuid(), QueueName));
                            });
                            Task.Run(() => {
                                SendRequestMessage(new GetAgentsRequest(new RequestingUser(Guid.NewGuid(), "agent1@zylinc.com", 
                                    new ClientInfo(Guid.NewGuid(), ClientType.Web)), VisibilityScope.All, Guid.NewGuid(), QueueName));
                            });
                            break;

                        case '3':
                            for (int i = 1; i <= 100; i++)
                            {
                                SendRequestMessage(new SubscribeToEventsRequest(new RequestingUser(Guid.NewGuid(), "agent1@zylinc.com", 
                                    new ClientInfo(Guid.NewGuid(), ClientType.Web)),
                                    SubscriptionScope.All, Guid.NewGuid(), QueueName));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n******* EXCEPTION *******");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\n");
                }

            } while (keyInfo.Key != ConsoleKey.X);

            _consumer.Received -= OnMessageReceived;
            _sendChannel.Close();
            _sendChannel.Dispose();
            _receiveChannel?.Close();
            _receiveChannel?.Dispose();
            _sendConnection?.Dispose();
            _receiveConnection?.Dispose();
        }


        private static void SendRequestMessage(RequestMessageBase request)
        {
            Guid correlationId = Guid.NewGuid();
            string json = JsonConvert.SerializeObject(request, _jsonSerializerSettings);
            var body = Encoding.UTF8.GetBytes(json);
            string routingKey = request.GetType().ToString();

            IBasicProperties props = _sendChannel!.CreateBasicProperties();
            props.ContentType = "application/json";
            props.Type = routingKey;
            props.CorrelationId = correlationId.ToString();
            props.ReplyTo = QueueName;
            props.DeliveryMode = 1;       // Non-persistent
            props.Expiration = MessageExpirationMillisecs;

            lock (_sendChannel)
            {
                _requests++;
                _sendChannel.BasicPublish(exchange: TopicsExchangeName, routingKey: routingKey, basicProperties: props, body: body);
            }
        }

        private static void OnMessageReceived(object? sender, BasicDeliverEventArgs e)
        {
            DateTime receiveTime = DateTime.Now;
            _replies++;

            string json = Encoding.UTF8.GetString(e.Body.ToArray());

            switch (e.BasicProperties.Type)
            {
                case "Messages.ResponseMessage1":
                    {
                        var response = JsonConvert.DeserializeObject<ResponseMessage1>(json, _jsonSerializerSettings);
                        _sendTime = response!.SendTime;
                    }
                    break;

                case "Messages.ResponseMessage2":
                    {
                        var response = JsonConvert.DeserializeObject<ResponseMessage2>(json, _jsonSerializerSettings);
                        _sendTime = response!.SendTime;
                    }
                    break;

                case "Messages.ResponseMessage3":
                    {
                        var response = JsonConvert.DeserializeObject<ResponseMessage3>(json, _jsonSerializerSettings);
                        _sendTime = response!.SendTime;
                    }
                    break;

                case "Messages.SubscribeToEventsResponse":
                    {
                        var response = JsonConvert.DeserializeObject<SubscribeToEventsResponse>(json, _jsonSerializerSettings);
                    }
                    break;

                case "Messages.GetQueuesResponse":
                    {
                        var response = JsonConvert.DeserializeObject<GetQueuesResponse>(json, _jsonSerializerSettings);
                    }
                    break;

                case "Messages.GetAgentsResponse":
                    {
                        var response = JsonConvert.DeserializeObject<GetAgentsResponse>(json, _jsonSerializerSettings);
                    }
                    break;

                default:
                    Console.WriteLine($"Unknown type: {e.BasicProperties.Type}");
                    return;
            }

            TimeSpan delay = receiveTime - _sendTime!.Value;
            int delayMs = (int)delay.TotalMilliseconds;

            if (_requests > 1 && delayMs > _longestDelayMs)
            {
                _longestDelayMs = delayMs;
            }

            Console.WriteLine($"Received message. Delay: {delayMs} ms. Longest delay: {_longestDelayMs} ms.  Requests: {_requests}, replies: {_replies}");
        }
    }
}