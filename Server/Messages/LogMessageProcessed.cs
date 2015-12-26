namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogMessageProcessed
    {
        public string Machine { get; private set; }

        public int Thread { get; private set; }

        public LogMessageProcessed(string machine, int thread)
        {
            Machine = machine;
            Thread = thread;
        }
    }
}