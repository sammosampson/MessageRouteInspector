namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class CheckRouteLimit
    {
        public Guid RouteId { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public CheckRouteLimit(Guid routeId, DateTime createdOn)
        {
            RouteId = routeId;
            CreatedOn = createdOn;
        }
    }
}