using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// An agents representation on a queue
    /// </summary>
    public class QueueMembership
    {
        /// <summary>
        ///  Unique id of the queue this membership is for
        /// </summary>
        public Guid QueueId { get; }

        /// <summary>
        /// The agents membership role on the queue
        /// </summary>
        public QueueMembershipRole QueueMembershipRole { get; }

        /// <summary>
        /// Indicates if the agent is currently monitoring the queue.
        /// </summary>
        public bool Monitoring { get; }

        /// <summary>
        /// Create a new AgentQueueMembership
        /// </summary>
        /// <param name="queueId"></param>
        /// <param name="queueMembershipRole"></param>
        /// <param name="monitoring"></param>
        public QueueMembership(Guid queueId, QueueMembershipRole queueMembershipRole, bool monitoring)
        {
            QueueId = queueId;
            QueueMembershipRole = queueMembershipRole;
            Monitoring = monitoring;
        }
    }
}
