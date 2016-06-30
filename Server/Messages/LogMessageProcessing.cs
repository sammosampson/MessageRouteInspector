namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public abstract class LogMessageProcessing : LogMessage
    {
        public string MessageName { get; private set; }
        public DateTime CreatedOn { get; private set; }

        protected LogMessageProcessing(string messageName, DateTime createdOn, string machine, int thread)
            : base(machine, thread)
        {
            MessageName = messageName;
            CreatedOn = createdOn;
        }

        protected LogMessageProcessing(string messageName, DateTime createdOn, string machine, int thread, string correlationId) 
            : base(machine, thread, correlationId)
        {
            MessageName = messageName;
            CreatedOn = createdOn;
        }
    }
}