using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MessageBranch
    {
        public MessageType Type { get; private set; }

        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public MessageBranch(MessageType type, string name)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
        }


    }
}