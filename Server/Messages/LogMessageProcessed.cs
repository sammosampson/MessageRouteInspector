namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogMessageProcessed : LogMessage
    {
        public LogMessageProcessed(string machine, int thread) : base(machine, thread)
        {
        }

        public LogMessageProcessed(string machine, int thread, string correlationId)
            : base(machine, thread, correlationId)
        {
        }
    }
}