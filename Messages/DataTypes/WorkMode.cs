namespace Messages.DataTypes
{
    /// <summary>
    /// The agent's work mode. Set by agent.
    /// See: https://help.zylinc.com/partner/6.5/en/Content/_Admin/_Routing/CallDistribution.htm (Sub section 'Agent user work state')
    /// </summary>
    public enum WorkMode
    {
        /// <summary> 
        /// The agent is in work mode active (active on queues / channels will automatically be routed dependent on distribution mode). 
        /// </summary>
        Active,

        /// <summary> 
        /// The agent is in work mode inactive (inactive on queues / channels will not automatically be routed). 
        /// </summary>
        Inactive,

        /// <summary> 
        /// The agent is in work mode standby (standby on queues / channels will only be automatically routed from queues that have activated standby agents.)  
        /// </summary>
        Standby,
    }
}
