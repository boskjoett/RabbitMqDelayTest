namespace Messages.DataTypes
{
    /// <summary>
    /// Possible endpoint address types.
    /// The type indicates how to interpret and validate an endpoint address string.
    /// </summary>
    public enum EndpointAddressType
    {
        /// <summary>
        /// The endpoint address is a phone number in E164 format.
        /// </summary>
        /// <remarks>
        /// The phone number should comply with the E.164 international telephone numbering plan.
        /// Example +1 555-123-4567. E164 numbers are international numbers with a country dial prefix,
        /// usually an area code and a subscriber number. A valid E.164 phone number must include a country calling code.
        /// </remarks>
        PhoneNumberInE164Format,

        /// <summary>
        /// The endpoint address is a phone number that is not in E164 format. For example a local extension like 621.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// The endpoint address is an email address.
        /// </summary>
        EmailAddress,

        /// <summary>
        /// The endpoint address is a SIP URI, like sip:john.doe@zylinc.com or sip:1-999-123-4567@voip-provider.example.net.
        /// </summary>
        SipUri,

        /// <summary>
        /// Jabber Identifier, used in XMPP chat.
        /// See https://xmpp.org/extensions/xep-0029.html
        /// </summary>
        Jid,

        /// <summary>
        /// PBX ID used by call managers (Cisco, Avaya, ...). This can e.g. be a number for Avaya (1234) or initials for Cisco (kjo).
        /// In the Zylinc legacy database this is called pbx_id.
        /// </summary>
        PbxId
    }
}