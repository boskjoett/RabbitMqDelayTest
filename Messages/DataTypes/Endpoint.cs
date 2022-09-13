using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// Endpoint base class with a unique address
    /// that is used to establish a communication channel.
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// The type of endpoint address, e.g. phone number, email, SIP URI
        /// </summary>
        public EndpointAddressType AddressType { get; }

        /// <summary>
        /// Endpoint address.
        /// Based on endpoint address type, it can be phone number, email address, SIP URI, etc.
        /// </summary>
        /// <remarks>
        /// The address is considered case-insensitive when compared to another endpoint address.
        /// </remarks>
        public string Address { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressType">Endpoint address type</param>
        /// <param name="address">Endpoint address.Based on endpoint type, it can be phone number,  email address, chat address, etc.</param>
        public Endpoint(EndpointAddressType addressType, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException("Address cannot be null or empty", nameof(address));

            Address = address;
            AddressType = addressType;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// Performs deep comparison.
        /// Address is case-insensitive.
        /// </summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>
        /// True if the specified object is equal to the current object; otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj is Endpoint endpoint)
            {
                if (AddressType != endpoint.AddressType)
                    return false;
                if (Address == null)
                {
                    if (endpoint.Address != null)
                        return false;
                }
                else
                {
                    if (!Address.Equals(endpoint.Address, StringComparison.OrdinalIgnoreCase))
                        return false;
                }
                return true;
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
            return HashCode.Combine(AddressType, Address);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Type: {AddressType}, Address: {Address}";
        }
    }
}