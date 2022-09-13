using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// Base information about a end-user client
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// The unique identifier for the client session
        /// </summary>
        public Guid ClientSessionId { get; private set; }

        /// <summary>
        /// The client type
        /// </summary>
        public ClientType ClientType { get; private set; }

        /// <summary>
        /// Create new client info
        /// </summary>
        /// <param name="clientSessionId"></param>
        /// <param name="clientType"></param>
        public ClientInfo(Guid clientSessionId, ClientType clientType)
        {
            ClientSessionId = clientSessionId != Guid.Empty ? clientSessionId : throw new ArgumentException(nameof(clientSessionId));
            ClientType = clientType;
        }
    }
}
