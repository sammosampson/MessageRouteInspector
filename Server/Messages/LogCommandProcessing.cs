using System;

namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogCommandProcessing : LogMessageProcessing
    {
        public LogCommandProcessing(string messageName, DateTime createdOn, string machine, int thread) 
            : base(messageName, createdOn, machine, thread)
        {
        }
    }
}