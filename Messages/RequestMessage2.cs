namespace Messages
{
    public class RequestMessage2
    {
        public DateTime SendTime { get; }

        public int SequenceNumber { get; }

        public string SenderName { get; }

        public RequestMessage2(DateTime sendTime, int sequenceNumber, string senderName)
        {
            SendTime = sendTime;
            SequenceNumber = sequenceNumber;
            SenderName = senderName;
        }
    }
}