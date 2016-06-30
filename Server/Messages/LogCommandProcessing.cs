using System;

namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogCommandProcessing : LogMessageProcessing
    {
        public LogCommandProcessing(string messageName, DateTime createdOn, string machine, int thread) 
            : base(messageName, createdOn, machine, thread)
        {
        }

        public LogCommandProcessing(string messageName, DateTime createdOn, string machine, int thread, string correlationId)
            : base(messageName, createdOn, machine, thread, correlationId)
        {
        }
    }
}