namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;

    public class MessageId
    {
        readonly Guid value;

        public MessageId()
        {
            value = Guid.NewGuid();
        }

        public static implicit operator Guid(MessageId from)
        {
            return from.value;
        }
    }
}