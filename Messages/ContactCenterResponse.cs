using Messages.DataTypes;

namespace Messages
{
    /// <summary>
    /// The base class for contact center request reponses
    /// </summary>
    public abstract class ContactCenterResponse : ResponseMessageBase
    {
        /// <summary>
        /// Response code
        /// </summary>
        public ContactCenterResponseCode ContactCenterResponseCode { get; }

        /// <summary>
        /// Response description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Create new contact center response
        /// </summary>
        /// <param name="contactCenterResponseCode">The response code</param>
        /// <param name="description">The response decription</param>
        /// <param name="requestMessageId">The request message id</param>
        /// <param name="finalResponse">Is it a final response</param>
        public ContactCenterResponse(ContactCenterResponseCode contactCenterResponseCode, string description, Guid requestMessageId, bool finalResponse = true)
            : base(requestMessageId, finalResponse)
        {
            ContactCenterResponseCode = contactCenterResponseCode;
            Description = description;
        }
    }
}
