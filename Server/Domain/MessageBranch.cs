using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public abstract class MessageBranch
    {
        public MessageType Type { get; private set; }

        public string Name { get; private set; }

        public Guid Id { get; private set; }

        protected MessageBranch(MessageType type, string name)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
        }


    }
}