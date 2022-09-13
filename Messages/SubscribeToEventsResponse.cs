using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// Subscribe to events request response
    /// </summary>
    public sealed class SubscribeToEventsResponse : ContactCenterResponse
    {
        /// <summary>
        /// Create new contact center set work mode response
        /// </summary>
        /// <param name="contactCenterResponseCode">The response code</param>
        /// <param name="description">The response decription</param>
        /// <param name="requestMessageId">The request message id</param>
        /// <param name="finalResponse">Is it a final response</param>
        public SubscribeToEventsResponse(ContactCenterResponseCode contactCenterResponseCode, string description, Guid requestMessageId, bool finalResponse = true)
             : base(contactCenterResponseCode, description, requestMessageId, finalResponse)
        {
        }
    }
}
