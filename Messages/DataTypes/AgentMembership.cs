using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// A representation of a queue membership of an agent
    /// </summary>
    public class AgentMembership
    {
        /// <summary>
        /// Guid of the user this membership is for
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// The subscription role for the queue e.g. Primary, Secondard, Standby, Monitor
        /// </summary>
        public QueueMembershipRole QueueMembershipRole { get; }

        /// <summary>
        /// Create a new queue membership config
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="queueMembershipRole"></param>
        public AgentMembership(Guid userId, QueueMembershipRole queueMembershipRole)
        {
            UserId = userId;
            QueueMembershipRole = queueMembershipRole;
        }
    }
}
