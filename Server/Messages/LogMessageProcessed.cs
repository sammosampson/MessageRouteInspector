namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class LogMessageProcessed
    {
        public string Machine { get; set; }
        public int Thread { get; set; }
    }
}