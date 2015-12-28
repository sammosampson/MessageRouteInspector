namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using System;

    public class Route
    {
        public Guid RouteId { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public Route(Guid routeId, DateTime createdOn)
        {
            RouteId = routeId;
            CreatedOn = createdOn;
        }
    }
}