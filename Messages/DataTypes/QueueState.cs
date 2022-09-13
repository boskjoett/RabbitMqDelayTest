namespace Messages.DataTypes
{
    /// <summary>
    /// The state of the queue
    /// </summary>
    public enum QueueState
    {
        /// <summary> 
        /// The queue operating normally
        /// </summary>
        Open,

        /// <summary> 
        /// The queue has activated standby agents 
        /// </summary>
        StandbyActivated,

        /// <summary>
        /// The is in failover state
        /// </summary>
        Closed,
    }
}
