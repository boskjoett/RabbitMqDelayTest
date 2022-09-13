namespace Messages
{
    public class RequestMessage3
    {
        public DateTime SendTime { get; }

        public int SequenceNumber { get; }

        public string SenderName { get; }

        public RequestMessage3(DateTime sendTime, int sequenceNumber, string senderName)
        {
            SendTime = sendTime;
            SequenceNumber = sequenceNumber;
            SenderName = senderName;
        }
    }
}