namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using Akka.Actor;

    public class RoutesView : ReceiveActor
    {
        private readonly List<Route> routes;

        public RoutesView()
        {
            routes = new List<Route>();
            Context.System.EventStream.Subscribe(Self, typeof(MessageRouteStarted));
            Receive<GetRoutes>(request => RespondWithRoutes());
            Receive<MessageRouteStarted>(request => AddRoute());
        }

        private void RespondWithRoutes()
        {
            Sender.Tell(routes.ToArray());
        }

        private void AddRoute()
        {
            routes.Add(new Route());
        }
    }
}