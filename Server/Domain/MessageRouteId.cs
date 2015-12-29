using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    internal class MessageRouteId
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