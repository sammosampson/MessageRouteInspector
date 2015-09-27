namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class LogMessageProcessingFailure
    {
        public string FailureName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Machine { get; set; }
        public int Thread { get; set; }
    }
}