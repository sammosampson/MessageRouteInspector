namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class LogMessageProcessing
    {
        public string MessageName { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string Machine { get; private set; }

        public int Thread { get; private set; }

        public LogMessageProcessing(string messageName, DateTime createdOn, string machine, int thread)
        {
            MessageName = messageName;
            CreatedOn = createdOn;
            Machine = machine;
            Thread = thread;
        }
    }
}