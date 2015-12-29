namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageRouteEnded
    {
        public Guid Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public MessageRouteEnded(Guid id, DateTime createdOn)
        {
            Id = id;
            CreatedOn = createdOn;
        }
    }
}