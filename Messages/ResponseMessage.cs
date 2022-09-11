namespace Messages
{
    public class ResponseMessage
    {
        public DateTime SendTime { get; }
        public DateTime ReplyTime { get; }

        public ResponseMessage(DateTime sendTime, DateTime replyTime)
        {
            SendTime = sendTime;
            ReplyTime = replyTime;
        }
    }
}
