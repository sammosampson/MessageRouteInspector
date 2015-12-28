namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class LogMessageProcessingFailure
    {
        public string FailureName { get; }

        public DateTime CreatedOn { get; }

        public string Machine { get; }

        public int Thread { get; }

        public LogMessageProcessingFailure(string failureName, DateTime createdOn, string machine, int thread)
        {
            FailureName = failureName;
            CreatedOn = createdOn;
            Machine = machine;
            Thread = thread;
        }
    }
}