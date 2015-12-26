using System;
using System.Threading.Tasks;
using SystemDot.Akka;
using SystemDot.MessageRouteInspector.Server.Messages;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Messages;

    public class RoutesView : ViewActor
    {
        private readonly List<Route> routes;

        public RoutesView()
        {
            routes = new List<Route>();

            Receive<GetRoutes>(request => RespondWithRoutes());

            ProjectEvent<MessageRouteStarted>(AddRoute);
            ProjectEvent<MessageBranchCompleted>(AddMessageToRoute);
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