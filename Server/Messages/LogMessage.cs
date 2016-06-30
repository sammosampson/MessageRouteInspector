namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public abstract class LogMessage
    {
        public string Machine { get; }
        public int Thread { get; }
        public string CorrelationId { get; }

        protected LogMessage(string machine, int thread)
        {
            Machine = machine;
            Thread = thread;
            CorrelationId = string.Empty;
        }

        protected LogMessage(string machine, int thread, string correlationId)
        {
            Machine = machine;
            Thread = thread;
            CorrelationId = correlationId;
        }
    }
}