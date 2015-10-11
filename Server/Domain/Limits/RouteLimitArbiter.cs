namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SystemDot.Domain.Events;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class RouteLimitArbiter 
    {
        readonly List<Route> routes;
        readonly RouteLimit limit;
        readonly IEventBus bus;

        public RouteLimitArbiter(RouteLimit limit, IEventBus bus)
        {
            this.limit = limit;
            this.bus = bus;
            routes = new List<Route>();
        }

        public void CheckLimit(Guid routeId, DateTime createdOn)
        {
            if (routes.Count == limit)
            {
                var toRemove = routes.OrderByDescending(r => r.CreatedOn).Last();
                routes.Remove(toRemove);
                bus.PublishEvent(new MessageRouteLimitReached { ToRemove = toRemove.RouteId});
            }
            routes.Add(new Route(routeId, createdOn));
        }
    }
}