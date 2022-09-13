using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// A request to fetch all agent sessions
    /// </summary>
    public sealed class SubscribeToEventsRequest : ContactCenterRequest
    {
        /// <summary>
        /// The event subscription type.
        /// </summary>
        public SubscriptionScope SubscriptionScope { get; }

        /// <summary>
        /// Create a get agent session request
        /// </summary>
        /// <param name="requestingUser">The requesting user</param>
        /// <param name="subscriptionScope"> The event subscription scope</param>
        /// <param name="requestMessageId">The request message ID</param>
        /// <param name="returnAddress">The request return address</param>
        public SubscribeToEventsRequest(RequestingUser requestingUser, SubscriptionScope subscriptionScope, Guid requestMessageId, string returnAddress)
            : base(requestingUser, requestMessageId, returnAddress)
        {
            SubscriptionScope = subscriptionScope;
        }
    }
}
