namespace Messages
{
    public class RequestMessage
    {
        public DateTime SendTime { get; }

        public RequestMessage(DateTime sendTime)
        {
            SendTime = sendTime;
        }
    }
}