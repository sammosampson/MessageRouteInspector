namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageRouteLimitReached
    {
        public Guid ToRemove { get; private set; }

        public MessageRouteLimitReached(Guid toRemove)
        {
            ToRemove = toRemove;
        }
    }
}