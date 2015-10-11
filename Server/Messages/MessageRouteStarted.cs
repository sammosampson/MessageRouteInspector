namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageRouteStarted
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string MachineName { get; set; }
        public int Thread { get; set; }
    }
}