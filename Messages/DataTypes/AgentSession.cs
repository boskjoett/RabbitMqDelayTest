using System;
using System.Collections.Generic;

namespace Messages.DataTypes
{
    /// <summary>
    /// The agent's login session
    /// </summary>
    public class AgentSession
    {
        /// <summary>
        /// Unique user id for the agent
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// The display name of the agent.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Agent status
        /// </summary>
        public AgentStatus AgentStatus { get; }

        /// <summary>
        /// A date time when the agent status changed last
        /// </summary>
        public DateTime AgentStatusChangedAtUtc { get; }

        /// <summary>
        /// The agent's voice state dictated by the agent's voice converstion handling
        /// </summary>
        public AgentState VoiceState { get; }

        /// <summary>
        /// The agent's federated presence state dictated by the agent's presence state
        /// /// </summary>
        public AgentState? FederatedState { get; }

        /// <summary>
        /// The agent's desired work mode. Selected by agent (Active, Inactive, Standby or Monitor). 
        /// </summary>
        public WorkMode WorkMode { get; }

        /// <summary>
        /// Agents work mode reason
        /// </summary>
        public string? WorkModeReason { get; }

        /// <summary>
        /// Name of configured work mode reason to select from
        /// </summary>
        /// <remarks>
        /// Only set if enabled for agent
        /// </remarks>
        public string? WorkModeReasonsConfigReference { get; }

        /// <summary>
        /// The agent's distribution mode, how are channel routed to the agents. Automatic/Manual
        /// </summary>
        public DistributionMode DistributionMode { get; }

        /// <summary>
        /// Is the agent's client type
        /// </summary>
        public ClientType ClientType { get; }

        /// <summary>
        /// The unique id for the client session associated with the agent session
        /// </summary>
        public Guid ClientSessionId { get; }

        /// <summary>
        /// The current event subscription scope for this agent session
        /// </summary>
        public SubscriptionScope SubscriptionScope { get; }

        /// <summary>
        /// What type of device is the agent using?
        /// </summary>
        public AudioEndpoint AudioEndpoint { get; }

        /// <summary>
        /// Has the agent overridden the default audio endpoint?
        /// </summary>
        public bool IsAudioEndpointOverridden { get; }

        /// <summary>
        /// Agent's caller ID
        /// </summary>
        public string CallerId { get; }

        /// <summary>
        /// Has the agent overridden the default caller ID?
        /// </summary>
        public bool IsCallerIdOverridden { get; }

        /// <summary>
        /// The queue memberships of the agents
        /// </summary>
        public IEnumerable<QueueMembership> QueueMemberships { get; }

        /// <summary>
        /// The agents waiting conversations
        /// </summary>
        public IEnumerable<Guid> WaitingConversations { get; set; }

        /// <summary>
        /// The agents offering conversations
        /// </summary>
        public IEnumerable<Guid> OfferingConversations { get; set; }

        /// <summary>
        /// The conversations the agent is currently handling
        /// </summary>
        public IEnumerable<Guid> HandlingConversations { get; set; }

        /// <summary>
        /// The agents held conversations
        /// </summary>
        public IEnumerable<Guid> HeldConversations { get; set; }

        /// <summary>
        /// The agents parked conversations
        /// </summary>
        public IEnumerable<Guid> ParkedConversations { get; set; }

        /// <summary>
        /// The agents camped conversations
        /// </summary>
        public IEnumerable<Guid> CampedConversations { get; set; }

        /// <summary>
        /// The agents transferring conversations
        /// </summary>
        public IEnumerable<Guid> TransferringConversations { get; set; }

        /// <summary>
        /// Agents wrap up details
        /// </summary>
        public WrapUpDetails WrapUpDetails { get; private set; }

        /// <summary>
        /// Create a new agent session
        /// </summary>
        /// <param name="userId"> The unique id of the user assosited with the agent session </param>
        /// <param name="displayName"></param>
        /// <param name="agentStatus">The agents status</param>
        /// <param name="agentStatusChangedAtUtc">Date time when agent status changed</param>
        /// <param name="voiceState"> The agents voice state</param>
        /// <param name="federatedState"> The agents federated presence state</param>
        /// <param name="workMode"> The agents work mode </param>
        /// <param name="workModeReason"> Agents current selected work mode reason </param>
        /// <param name="workModeReasonsConfigReference"> Work mode reasons configuration name </param>
        /// <param name="distributionMode"> The agents work mode </param>
        /// <param name="clientType"> The client type </param>
        /// <param name="clientSessionId"> The client session id </param>
        /// <param name="subscriptionScope"> The current event subscription scope for this agent session </param>
        /// <param name="audioEndpoint"> The audio endpoint of the agent </param>
        /// <param name="isAudioEndpointOverridden">Has the agent overridden the default audio endpoint?</param>
        /// <param name="callerId">Agent's caller ID</param>
        /// <param name="isCallerIdOverridden">Has the agent overridden the default caller ID?</param>
        /// <param name="queueMemberships"> The agents queue memberships </param>
        /// <param name="waitingConversations"> The agents waiting conversation (private conversations) </param>
        /// <param name="offeringConversations"> The current offering conversations of the agent if any </param>
        /// <param name="handlingConversations"> The agents handling conversations if any </param>
        /// <param name="heldConversations"> The agents held conversations </param>
        /// <param name="parkedConversations"> The agents parked conversations </param>
        /// <param name="campedConversations"> The agents camped conversations </param>
        /// <param name="transferringConversations"> The agents transferring conversations </param>
        /// <param name="wrapUpDetails"> Additional wrapup information</param>
        public AgentSession(
            Guid userId,
            string displayName,
            AgentStatus agentStatus,
            DateTime agentStatusChangedAtUtc,
            AgentState voiceState,
            AgentState? federatedState,
            WorkMode workMode,
            string? workModeReason,
            string? workModeReasonsConfigReference,
            DistributionMode distributionMode,
            ClientType clientType,
            Guid clientSessionId,
            SubscriptionScope subscriptionScope,
            AudioEndpoint audioEndpoint,
            bool isAudioEndpointOverridden,
            string callerId,
            bool isCallerIdOverridden,
            IEnumerable<QueueMembership> queueMemberships,
            IEnumerable<Guid> waitingConversations,
            IEnumerable<Guid> offeringConversations,
            IEnumerable<Guid> handlingConversations,
            IEnumerable<Guid> heldConversations,
            IEnumerable<Guid> parkedConversations,
            IEnumerable<Guid> campedConversations,
            IEnumerable<Guid> transferringConversations,
            WrapUpDetails wrapUpDetails)
        {
            UserId = userId;
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            AgentStatus = agentStatus;
            AgentStatusChangedAtUtc = agentStatusChangedAtUtc;
            VoiceState = voiceState;
            FederatedState = federatedState;
            WorkMode = workMode;
            WorkModeReason = workModeReason;
            WorkModeReasonsConfigReference = workModeReasonsConfigReference;
            DistributionMode = distributionMode;
            ClientType = clientType;
            ClientSessionId = clientSessionId;
            SubscriptionScope = subscriptionScope;
            AudioEndpoint = audioEndpoint;
            IsAudioEndpointOverridden = isAudioEndpointOverridden;
            CallerId = callerId;
            IsCallerIdOverridden = isCallerIdOverridden;
            QueueMemberships = queueMemberships;
            WaitingConversations = waitingConversations;
            OfferingConversations = offeringConversations;
            HandlingConversations = handlingConversations;
            HeldConversations = heldConversations;
            ParkedConversations = parkedConversations;
            CampedConversations = campedConversations;
            TransferringConversations = transferringConversations;
            WrapUpDetails = wrapUpDetails;
        }
    }
}
