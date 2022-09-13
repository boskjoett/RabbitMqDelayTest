namespace Messages.DataTypes
{
    /// <summary>
    /// The way the conversation are distributed to the agent
    /// </summary>
    public enum DistributionMode
    {
        /// <summary> 
        /// The agent is in offer mode, conversations will be offered to the agent if available. 
        /// </summary>
        Offer,

        /// <summary> 
        /// The agent is in manual mode, conversations will not be automatically offered to agent, agent need to manually accept the conversations. 
        /// </summary>
        Manual,

        /// <summary> 
        /// The agent is in auto accept mode, conversations will automatically be routed to agent if available
        /// </summary>
        AutoAccept
    }
}
