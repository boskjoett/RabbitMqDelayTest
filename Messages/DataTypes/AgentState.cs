namespace Messages.DataTypes
{
    /// <summary>
    /// The agent's state. This is dictated by the agent's current activity.
    /// </summary>
    public enum AgentState
    {
        /// <summary> 
        /// The agent is idle, available to handle a channel (customer request). 
        /// </summary>
        Available,

        /// <summary> 
        /// The agent is currently in wrap up. A grace period after handling a channel (customer request). 
        /// </summary>
        WrapUp,

        /// <summary> 
        /// The agent is in state active (a chat busy state). Agent is handling a chat, but has capacity to handle more chats. 
        /// </summary>
        Busy,

        /// <summary> 
        /// The agent is unavailable/unreachable. Set unavailable by the system due to offer timeout or device could not be reached. 
        /// </summary>
        Unreachable,

        /// <summary> 
        /// The agent is offline. 
        /// </summary>
        Offline
    }
}
