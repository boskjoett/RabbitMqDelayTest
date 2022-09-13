namespace Messages.DataTypes
{
    /// <summary>
    /// Event Subscription indicating the subscription level.
    /// </summary>
    public enum SubscriptionScope
    {
        /// <summary>
        /// Subscription to all things.
        /// </summary>
        All,
        /// <summary>
        /// Subscription to things relevant to the agent.
        /// </summary>
        AgentRelevant,      
        /// <summary>
        /// Subscribe to nothing.
        /// </summary>
        None
    }
}
