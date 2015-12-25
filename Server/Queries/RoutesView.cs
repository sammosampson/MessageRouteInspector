using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Messages;

    public class RoutesView : ReceiveActor
    {
        private readonly List<Route> routes;

        public RoutesView()
        {
            routes = new List<Route>();

            Context.System.EventStream.Subscribe(Self, typeof(MessageRouteStarted));
            Context.System.EventStream.Subscribe(Self, typeof(MessageBranchCompleted));

            Receive<GetRoutes>(request => RespondWithRoutes());
            Receive<MessageRouteStarted>(@event => AddRoute(@event));
            Receive<MessageBranchCompleted>(@event => AddMessageToRoute(@event));
        }
        
        private void RespondWithRoutes()
        {
            Sender.Tell(routes.ToArray());
        }

        private void AddRoute(MessageRouteStarted @event)
        {
            routes.Add(new Route(
                @event.Id.ToString(),
                Message.Empty, 
                new Message[0],
                @event.CreatedOn.ToJavaString(), 
                @event.MachineName ));
        }

        private void AddMessageToRoute(MessageBranchCompleted @event)
        {
            routes.Single().Root = new Message(
                @event.MessageId.ToString(),
                @event.MessageName,
                @event.CloseBranchCount,
                @event.MessageType);

            routes.Single().Messages = new[] 
            {
               routes.Single().Root
            };
        }
    }
}