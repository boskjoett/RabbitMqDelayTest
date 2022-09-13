namespace Messages
{
    /// <summary>
    /// Common base class for all message bus response messages.
    /// A response message must always be correlated to a request message.
    /// </summary>
    public abstract class ResponseMessageBase : MessageBase
    {
        /// <summary>
        /// The Id of the correlated request.
        /// </summary>
        public Guid RequestMessageId { get; }

        /// <summary>
        /// True, when the response message is the last in a sequence of 1 to many messages.
        /// False, when more responses to the original request will be sent.
        /// </summary>
        public bool FinalResponse { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="requestMessageId"> The Id of the correlated request.</param>
        /// <param name="finalResponse">Indicates if the response is last message in the sequence.</param>
        protected ResponseMessageBase(Guid requestMessageId, bool finalResponse)
        {
            RequestMessageId = requestMessageId;
            FinalResponse = finalResponse;
        }
    }
}