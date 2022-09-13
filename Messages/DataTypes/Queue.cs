using System;
using System.Collections.Generic;
using System.Globalization;

namespace Messages.DataTypes
{
    /// <summary>
    /// The class for Queues
    /// </summary>
    public class Queue
    {
        /// <summary>
        /// The unique id of the queue
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The display name of the queue
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The type of queue. Media type: audio, mail, chat, social
        /// </summary>
        public QueueType Type { get; }

        /// <summary>
        /// The endpoint of the queue: number, sip-uri, mail address
        /// </summary>
        public Endpoint Endpoint { get; }

        /// <summary>
        /// The state of the queue, open, close or standby activated
        /// </summary>
        public QueueState State { get; }

        /// <summary>
        /// The wrap up time associated with the queue, the grace period after handling a channel on the queue.
        /// </summary>
        public TimeSpan? WrapupTime { get; }

        /// <summary>
        /// The service goal of the queue. The duration that the channel should preferably not exceed in queue before being handled by an agent. 
        /// </summary>
        public TimeSpan? ServiceGoal { get; }

        /// <summary>
        /// The capacity of the queue, maximum number of channel in the queue.
        /// </summary>
        public int? ConversationCapacity { get; }

        /// <summary>
        /// The language of the queue
        /// </summary>
        public CultureInfo Language { get; }

        /// <summary>
        /// Is the queue monitored by agents?
        /// </summary>
        public bool IsMonitored { get; }

        /// <summary>
        /// The agents currently on the queue and there subscription type / queue role
        /// </summary>
        public IEnumerable<AgentMembership> Agents { get; }

        /// <summary>
        /// The channel currently in queue
        /// </summary>
        public IEnumerable<Guid> WaitingConversations { get; }

        /// <summary>
        /// Reasons for the queue to activate standby agents
        /// </summary>
        public IEnumerable<StandbyActiveReason> StandbyActiveReasons { get; }

        /// <summary>
        /// The description of the queue.e.g. "Technical Support"
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The hexadecimal color code of the queue.
        /// </summary>
        public string ColorHex { get; }

        /// <summary>
        /// Create new contact center queue
        /// </summary>
        /// <param name="id"> The unique id of the queue </param>
        /// <param name="name"> The display name of the queue </param>
        /// <param name="type"> The type of queue</param>
        /// <param name="endpoint"> The endpoint of the queue </param>
        /// <param name="state"> The state of the queue </param>
        /// <param name="wrapupTime"> The wrap up time of the queue </param>
        /// <param name="serviceGoal"> The service goal of the queue </param>
        /// <param name="conversationCapacity"> The capacity of the queue </param>
        /// <param name="language"> The language of the queue </param>
        /// <param name="isMonitored"> Is the queue monitored </param>
        /// <param name="agents"> The agents monitoring the queue </param>
        /// <param name="waitingConversations"> The waiting conversations in the queue </param>
        /// <param name="standbyActiveReasons"> The reason a queue has activated standby agents </param>
        /// <param name="colorHex"> The color of the queue as defined in the config</param>
        /// <param name="description"> The description of the queue as defined in the config</param>
        public Queue(Guid id, string name, QueueType type, Endpoint endpoint, QueueState state, TimeSpan? wrapupTime, TimeSpan? serviceGoal, int? conversationCapacity, CultureInfo language, bool isMonitored, IEnumerable<AgentMembership> agents, IEnumerable<Guid> waitingConversations, IEnumerable<StandbyActiveReason> standbyActiveReasons, string colorHex, string description)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            State = state;
            WrapupTime = wrapupTime;
            ServiceGoal = serviceGoal;
            ConversationCapacity = conversationCapacity;
            Language = language ?? throw new ArgumentNullException(nameof(language));
            IsMonitored = isMonitored;
            Agents = agents ?? throw new ArgumentNullException(nameof(agents));
            WaitingConversations = waitingConversations ?? throw new ArgumentNullException(nameof(waitingConversations));
            StandbyActiveReasons = standbyActiveReasons ?? throw new ArgumentNullException(nameof(standbyActiveReasons));
            ColorHex = colorHex;
            Description = description;
        }
    }
}