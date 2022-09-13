using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// This class represents an endpoint for an audio call.
    /// </summary>
    public class AudioEndpoint : Endpoint
    {
        /// <summary>
        /// Audio platform
        /// </summary>
        public AudioPlatform Platform { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="platform">Audio platform</param>
        /// <param name="addressType">Endpoint address type</param>
        /// <param name="address">Endpoint address</param>
        public AudioEndpoint(AudioPlatform platform, EndpointAddressType addressType, string address)
            : base(addressType, address)
        {
            Platform = platform;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// Performs deep comparison.
        /// </summary>
        /// <param name="obj">
        ///  The object to compare with the current object.
        /// </param>
        /// <returns>
        /// true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is AudioEndpoint endpoint)
            {
                if (Platform == endpoint.Platform)
                    return base.Equals(endpoint);
            }

            return false;
        }

        /// <summary>
        /// Object's hash function.
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Platform);
        }

        /// <summary>
        /// Determines whether two specified AudioEndpoint have the same value.
        /// Uses <see cref="Equals(object)"/> method to determine equality.
        /// </summary>
        /// <param name="left">The first AudioEndpoint to compare, or null.</param>
        /// <param name="right">The second AudioEndpoint to compare, or null.</param>
        /// <returns>
        /// true if the value of a is the same as the value of b; otherwise, false.
        /// </returns>
        public static bool operator ==(AudioEndpoint? left, AudioEndpoint? right)
        {
            if (left is null || right is null)
                return Equals(left, right);

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified AudioEndpoints have different values.
        /// Uses <see cref="Equals(object)"/> method to determine inequality.
        /// </summary>
        /// <param name="left">The first AudioEndpoint to compare, or null.</param>
        /// <param name="right">The second AudioEndpoint to compare, or null.</param>
        /// <returns>
        /// true if the value of a is different from the value of b; otherwise, false.
        /// </returns>
        public static bool operator !=(AudioEndpoint? left, AudioEndpoint? right)
        {
            if (left is null || right is null)
                return !Equals(left, right);

            return !left.Equals(right);
        }
    }
}