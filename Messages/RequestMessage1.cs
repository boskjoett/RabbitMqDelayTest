namespace Messages
{
    public class RequestMessage1
    {
        public DateTime SendTime { get; }

        public int SequenceNumber { get; }

        public string SenderName { get; }

        public RequestMessage1(DateTime sendTime, int sequenceNumber, string senderName)
        {
            SendTime = sendTime;
            SequenceNumber = sequenceNumber;
            SenderName = senderName;
        }
    }
}