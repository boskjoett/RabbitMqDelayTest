namespace Messages.DataTypes
{
    /// <summary>
    /// Reasons for the queue to activate standby agents
    /// </summary>
    public enum StandbyActiveReason
    {
        /// <summary>
        /// There are insufficient agents monitoring the queue
        /// </summary>
        InsufficientAgents,

        /// <summary>
        /// There is a conversation in queue has been waiting too long
        /// </summary>
        ConversationDurationExceeded,

        /// <summary>
        /// There are too many conversations in queue
        /// </summary>
        ConversationCapacityExceeded
    }
}
