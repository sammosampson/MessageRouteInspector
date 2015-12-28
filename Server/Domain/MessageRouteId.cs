using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MessageRouteId
    {
        readonly Guid value;

        public MessageRouteId()
        {
            value = Guid.NewGuid();
        }

        public static implicit operator Guid(MessageRouteId from)
        {
            return from.value;
        }
    }
}