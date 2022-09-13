using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// A request to fetch all agent sessions
    /// </summary>
    public sealed class GetAgentsRequest : ContactCenterRequest
    {
        /// <summary>
        /// The visibility level of requested agents.
        /// </summary>
        public VisibilityScope VisibilityScope { get; }

        /// <summary>
        /// Create a get agent session request
        /// </summary>
        /// <param name="requestingUser">The requesting user</param>
        /// <param name="visibilityScope"> The visibility level</param>
        /// <param name="requestMessageId">The request message ID</param>
        /// <param name="returnAddress">The request return address</param>
        public GetAgentsRequest(RequestingUser requestingUser, VisibilityScope visibilityScope, Guid requestMessageId, string returnAddress)
            : base(requestingUser, requestMessageId, returnAddress)
        {
            VisibilityScope = visibilityScope;
        }
    }
}
