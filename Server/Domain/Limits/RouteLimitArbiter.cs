using SystemDot.Akka;

namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using System.Collections.Generic;
    using System.Linq;
    using Messages;

    internal class RouteLimitArbiter : AggregateRootActor
    {
        readonly List<Route> routes;
        readonly RouteLimit limit;

        public RouteLimitArbiter(RouteLimit limit)
        {
            this.limit = limit;
            routes = new List<Route>();
            Receive<CheckRouteLimit>(e => Handle(e));
        }

        private void Handle(CheckRouteLimit message)
        {
            while (routes.Count >= limit)
            {
                var toRemove = routes.OrderByDescending(r => r.CreatedOn).Last();
                routes.Remove(toRemove);
                Publish(new MessageRouteLimitReached(toRemove.RouteId));
            }

            routes.Add(new Route(message.RouteId, message.CreatedOn));
        }
    }
}