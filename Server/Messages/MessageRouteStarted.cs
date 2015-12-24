namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageRouteStarted
    {
        public Guid Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string MachineName { get; private set; }

        public int Thread { get; private set; }

        public MessageRouteStarted(Guid id, DateTime createdOn, string machineName, int thread)
        {
            Id = id;
            CreatedOn = createdOn;
            MachineName = machineName;
            Thread = thread;
        }
    }
}