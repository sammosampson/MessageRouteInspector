namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class CheckRouteLimit
    {
        public Guid RouteId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}