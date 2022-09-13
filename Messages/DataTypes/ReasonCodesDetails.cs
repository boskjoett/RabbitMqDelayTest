using System;

namespace Messages.DataTypes
{
   /// <summary>
   /// Details about which conversation and from which eueue reason codes are expected.
   /// </summary>
    public class ReasonCodesDetails
    {
        /// <summary>
        /// The ID of queue where reason codes are defined 
        /// </summary>
        public Guid QueueId { get; private set; }

        /// <summary>
        /// The ID of the conversation to set reason codes for
        /// </summary>
        public Guid ConversationId { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="queueId"></param>
        /// <param name="conversationId"></param>
        public ReasonCodesDetails(Guid queueId, Guid conversationId)
        {
            QueueId = queueId;
            ConversationId = conversationId;
        }
    }
}
