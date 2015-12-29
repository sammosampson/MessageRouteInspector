using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    internal class MessageId
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