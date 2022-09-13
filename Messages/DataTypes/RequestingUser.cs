using System;

namespace Messages.DataTypes
{
    /// <summary>
    /// The requester
    /// </summary>
    public class RequestingUser
    {
        /// <summary>
        /// The unique user id of the requesting user
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// The email of the requesting user
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Information about the requesters client
        /// </summary>
        public ClientInfo ClientInfo { get; private set; }

        /// <summary>
        /// Create new Requester
        /// </summary>
        /// <param name="userId">The unique identifier of the user</param>
        /// <param name="email">The email of the user</param>
        /// <param name="clientInfo">The requesters client info</param>
        public RequestingUser(Guid userId, string email, ClientInfo clientInfo)
        {
            UserId = userId != Guid.Empty ? userId : throw new ArgumentException(nameof(userId));
            Email = !string.IsNullOrEmpty(email) ? email : throw new ArgumentException(nameof(email));
            ClientInfo = clientInfo ?? throw new ArgumentException(nameof(clientInfo));
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Email} ({UserId}) on client {ClientInfo.ClientType} ({ClientInfo.ClientSessionId})";
        }
    }
}
