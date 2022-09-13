namespace Messages.DataTypes
{
    /// <summary>
    /// The type of the audio platform.
    /// </summary>
    public enum AudioPlatform
    {
        /// <summary>
        /// Platform is unspecified, for example in incoming calls.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Softphone (SIP)
        /// </summary>
        Softphone,

        /// <summary>
        /// Mobile
        /// </summary>
        Mobile,

        /// <summary>
        /// BroadWorks / BroadSoft
        /// </summary>
        BroadWorks,

        /// <summary>
        /// Cisco
        /// </summary>
        Cisco,

        /// <summary>
        /// Avaya
        /// </summary>
        Avaya,

        /// <summary>
        /// Microsoft Teams
        /// </summary>
        MicrosoftTeams
    }
}