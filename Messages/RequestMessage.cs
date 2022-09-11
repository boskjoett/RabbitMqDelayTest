namespace Messages
{
    public class RequestMessage
    {
        public DateTime SendTime { get; }

        public int SequenceNumber { get; }

        public string SenderName { get; }

        public RequestMessage(DateTime sendTime, int sequenceNumber, string senderName)
        {
            SendTime = sendTime;
            SequenceNumber = sequenceNumber;
            SenderName = senderName;
        }
    }
}