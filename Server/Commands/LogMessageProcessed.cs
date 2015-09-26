namespace SystemDot.MessageRouteInspector.Server.Commands
{
    public class LogMessageProcessed
    {
        public string Machine { get; set; }
        public int Thread { get; set; }
    }
}