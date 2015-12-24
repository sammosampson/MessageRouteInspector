using System;

namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogEventProcessing : LogMessageProcessing
    {
        public LogEventProcessing(string messageName, DateTime createdOn, string machine, int thread)
            : base(messageName, createdOn, machine, thread)
        {
        }
    }
}