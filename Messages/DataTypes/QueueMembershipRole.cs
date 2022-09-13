namespace Messages.DataTypes
{
    /// <summary>
    /// The agents queue membership role
    /// </summary>
    public enum QueueMembershipRole
    {
        /// <summary>
        /// Primary means these agents are priorities for conversations before agents with roles Secondary and Standby.
        /// </summary>
        Primary,

        /// <summary>
        /// Secondary means these agents are priorities for conversations after agents with roles Primary but before Standby.
        /// </summary>
        Secondary,

        /// <summary>
        /// Standby means these agents are priorities for conversations if the queue has entered a active standby state.
        /// </summary>
        Standby,

        /// <summary>
        /// Supervisor can monitor queue without having a active role
        /// </summary>
        Supervisor
    }
}