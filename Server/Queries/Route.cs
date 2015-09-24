namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;

    public class Route
    {
        public int Id { get; set; }
        public Message Root { get; set; }
        public Message[] Messages { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}