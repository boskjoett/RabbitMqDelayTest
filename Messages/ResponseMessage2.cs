namespace Messages
{
    public class ResponseMessage2
    {
        public DateTime SendTime { get; }
        
        public DateTime ReplyTime { get; }

        public int SequenceNumber { get; }

        public string SenderName { get; }

        public ResponseMessage2(DateTime sendTime, DateTime replyTime, int sequenceNumber, string senderName)
        {
            SendTime = sendTime;
            ReplyTime = replyTime;
            SequenceNumber = sequenceNumber;
            SenderName = senderName;
        }
    }
}
