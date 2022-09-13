using System;

namespace Messages
{
    /// <summary>
    /// Common base class for all message bus request messages.
    /// A request message must always send the name of the senders input queue.
    /// Responses are send to the return address.
    /// </summary>
    public abstract class RequestMessageBase : MessageBase
    {
        /// <summary>
        /// The Id of the request. This will be returned in the response.
        /// </summary>
        public Guid RequestMessageId { get; }

        /// <summary>
        /// The return address (with RabbitMQ/Rebus the input queue name) used when replying.
        /// Without an address the response cannot be sent. It should not be broadcasted with a publish event.
        /// </summary>
        public string ReturnAddress { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestMessageId">Id of the request.</param>
        /// <param name="returnAddress">Return address of the request.</param>
        protected RequestMessageBase(Guid requestMessageId, string returnAddress)
        {
            ReturnAddress = returnAddress;
            RequestMessageId = requestMessageId;
        }
    }
}