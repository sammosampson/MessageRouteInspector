namespace SystemDot.MessageRouteInspector.Server.Messages
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