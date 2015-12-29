namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class LogMessageProcessingFailure
    {
        public string FailureName { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string Machine { get; private set; }

        public int Thread { get; private set; }

        public LogMessageProcessingFailure(string failureName, DateTime createdOn, string machine, int thread)
        {
            FailureName = failureName;
            CreatedOn = createdOn;
            Machine = machine;
            Thread = thread;
        }
    }
}