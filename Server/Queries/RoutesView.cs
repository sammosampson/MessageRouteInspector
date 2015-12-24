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
            Receive<MessageRouteStarted>(@event => AddRoute(@event));
        }

        private void RespondWithRoutes()
        {
            Sender.Tell(routes.ToArray());
        }

        private void AddRoute(MessageRouteStarted @event)
        {
            routes.Add(new Route(
                @event.Id.ToString(),
                new Message(), 
                new Message[0],
                @event.CreatedOn.ToJavaString(), 
                @event.MachineName ));
        }
    }
}