using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// Get Queues request response.
    /// </summary>
    public sealed class GetQueuesResponse : ContactCenterResponse
    {
        /// <summary>
        /// The HashSet containing the requested queues.
        /// </summary>
        public IEnumerable<Queue> Queues { get; }

        /// <summary>
        /// Create new get agent session response
        /// </summary>
        /// <param name="contactCenterResponseCode">The response code</param>
        /// <param name="description">The response decription</param>
        /// <param name="queues">The queues</param>
        /// <param name="requestMessageId">The request message id</param>
        /// <param name="finalResponse">Is it a final response</param>
        public GetQueuesResponse(ContactCenterResponseCode contactCenterResponseCode, string description, IEnumerable<Queue> queues, Guid requestMessageId, bool finalResponse = true)
            : base(contactCenterResponseCode, description, requestMessageId, finalResponse)
        {
            Queues = queues ?? throw new ArgumentNullException(nameof(queues));
        }
    }
}
