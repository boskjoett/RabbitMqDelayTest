using System;
using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// Get Queues request.
    /// </summary>
    public sealed class GetQueuesRequest : ContactCenterRequest
    {
        /// <summary>
        /// The visibility level of requested queues.
        /// </summary>
        public VisibilityScope VisibilityScope { get; }

        /// <summary>
        /// Create a get queues request
        /// </summary>
        /// <param name="requestingUser">The requesting user</param>
        /// <param name="visibilityScope"> The visibility level</param>
        /// <param name="requestMessageId">The request message ID</param>
        /// <param name="returnAddress">The request return address</param>
        public GetQueuesRequest(RequestingUser requestingUser, VisibilityScope visibilityScope, Guid requestMessageId, string returnAddress)
            : base(requestingUser, requestMessageId, returnAddress)
        {
            VisibilityScope = visibilityScope;
        }
    }
}
