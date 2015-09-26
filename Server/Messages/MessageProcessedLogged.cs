namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageProcessedLogged
    {
        public string MessageName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}