using System;
using SystemDot.Akka;
using SystemDot.MessageRouteInspector.Server.Messages;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Linq;
    using Messages;

    public class RoutesView : ViewActor
    {
        private readonly RouteCollection routes;

        public RoutesView()
        {
            routes = new RouteCollection();

            Receive<GetRoutes>(request => RespondWithRoutes());
            Receive<GetRoute>(request => RespondWithRoute(request.RouteId));

            ProjectEvent<MessageRouteStarted>(Handle);
            ProjectEvent<MessageBranchCompleted>(Handle);
            ProjectEvent<MessageRouteLimitReached>(Handle);
        }
        
        private void RespondWithRoute(string routeId)
        {
            Sender.Tell(GetRoute(routeId));
        }

        private Route GetRoute(string routeId)
        {
            Route route;

            try
            {
                route = routes[routeId];
            }
            catch (Exception)
            {
                route = Route.Empty;
            }
            return route;
        }

        private void RespondWithRoutes()
        {
            Sender.Tell(routes.OrderByDescending(r => r.CreatedOn).ToArray());
        }

        private void Handle(MessageRouteStarted message)
        {
            routes.AddRoute(message.Id.ToString(), message.CreatedOn, message.MachineName);
        }

        private void Handle(MessageBranchCompleted message)
        {
            routes.AddMessage(message.RouteId.ToString(), message);
        }

        private void Handle(MessageRouteLimitReached message)
        {
            routes.RemoveRoute(message.ToRemove.ToString());
        }
    }
}