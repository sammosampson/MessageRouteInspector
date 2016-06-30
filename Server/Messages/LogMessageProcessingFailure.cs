namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class LogMessageProcessingFailure : LogMessage
    {
        public string FailureName { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public LogMessageProcessingFailure(string failureName, DateTime createdOn, string machine, int thread) 
            : base(machine, thread)
        {
            FailureName = failureName;
            CreatedOn = createdOn;
        }

        public LogMessageProcessingFailure(string failureName, DateTime createdOn, string machine, int thread, string correlationId)
            : base(machine, thread, correlationId)
        {
            FailureName = failureName;
            CreatedOn = createdOn;
        }
    }
}