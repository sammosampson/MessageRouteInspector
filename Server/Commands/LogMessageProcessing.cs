namespace SystemDot.MessageRouteInspector.Server.Commands
{
    using System;

    public class LogMessageProcessing
    {
        public string MessageName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Machine { get; set; }
        public int Thread { get; set; }
    }
}