namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class Route
    {
        public string Id { get; set; }
        public Message Root { get; set; }
        public Message[] Messages { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}