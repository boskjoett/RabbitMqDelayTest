namespace Messages.DataTypes
{
    /// <summary>
    /// Contact Center Response Codes
    /// </summary>
    public enum ContactCenterResponseCode
    {
        /// <summary>
        /// Request handled
        /// </summary>
        Ok,

        /// <summary>
        /// Requesting user has no agent session
        /// </summary>
        AgentNotFound,

        /// <summary>
        /// Agent unable to perform request
        /// </summary>
        AgentUnableToPerformRequest,

        /// <summary>
        /// Conversation not found
        /// </summary>
        ConversationNotFound,

        /// <summary>
        /// Conversation not available, incorrect state or owned by different agent
        /// </summary>
        ConversationNotAvailable,

        /// <summary>
        /// Queue not found
        /// </summary>
        QueueNotFound,

        /// <summary>
        /// Invalid arguments to perform request
        /// </summary>
        InvalidArguments,

        /// <summary>
        /// Cross client request, the agent session is associated with a different client
        /// </summary>
        CrossClientRequest,

        /// <summary>
        /// The operation is not supported
        /// </summary>
        OperationNotSupported,

        /// <summary>
        /// Service failed to perform request (Internal server error)
        /// </summary>
        ErrorPerformingRequest,
    }
}
