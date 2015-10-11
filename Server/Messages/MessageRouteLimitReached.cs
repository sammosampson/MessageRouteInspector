namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageRouteLimitReached
    {
        public Guid ToRemove { get; set; }
    }
}