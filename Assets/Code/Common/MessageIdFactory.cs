namespace Code.Common
{
    public static class MessageIdFactory
    {
        private static uint lastMessageId;
        public static uint GetMessageId()
        {
            return lastMessageId++;
        }
    }
}