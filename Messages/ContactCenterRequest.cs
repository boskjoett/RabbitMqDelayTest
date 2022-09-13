using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// The base class for contact center requests
    /// </summary>
    public abstract class ContactCenterRequest : RequestMessageBase
    {
        /// <summary>
        /// The user making the request
        /// </summary>
        public RequestingUser RequestingUser { get; }

        /// <summary>
        /// Create a new Contact Center request
        /// </summary>
        /// <param name="requestingUser">How is requesting to accept the conversation</param>
        /// <param name="requestMessageId">request id</param>
        /// <param name="returnAddress">request return address</param>
        public ContactCenterRequest(RequestingUser requestingUser, Guid requestMessageId, string returnAddress)
            : base(requestMessageId, returnAddress)
        {
            RequestingUser = requestingUser ?? throw new ArgumentNullException(nameof(requestingUser));
        }
    }
}
