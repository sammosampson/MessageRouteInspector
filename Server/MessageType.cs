namespace SystemDot.MessageRouteInspector.Server
{
    public class MessageType
    {
        public static MessageType Command { get{ return new MessageType(0); }}
        public static MessageType Event { get{ return new MessageType(1); }}
        public static MessageType Failure { get{ return new MessageType(2); }}

        public static implicit operator int(MessageType from)
        {
            return from.value;
        }

        private readonly int value;

        private MessageType(int value)
        {
            this.value = value;
        }
    }
}