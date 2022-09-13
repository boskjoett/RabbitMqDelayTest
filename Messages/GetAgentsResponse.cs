using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// Get agents request response.
    /// </summary>
    public sealed class GetAgentsResponse : ContactCenterResponse
    {
        /// <summary>
        /// The HashSet containing the requested agent sessions
        /// </summary>
        public IEnumerable<AgentSession> AgentSessions { get; }

        /// <summary>
        /// Create new get agent session response
        /// </summary>
        /// <param name="contactCenterResponseCode">The response code</param>
        /// <param name="description">The response decription</param>
        /// <param name="agentSessions">The agent sessions</param>
        /// <param name="requestMessageId">The request message id</param>
        /// <param name="finalResponse">Is it a final response</param>
        public GetAgentsResponse(ContactCenterResponseCode contactCenterResponseCode, string description, IEnumerable<AgentSession> agentSessions, Guid requestMessageId, bool finalResponse = true)
            : base(contactCenterResponseCode, description, requestMessageId, finalResponse)
        {
            AgentSessions = agentSessions ?? throw new ArgumentNullException(nameof(agentSessions));
        }
    }
}
