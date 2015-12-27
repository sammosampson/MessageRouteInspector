using System.Collections.Generic;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using Messages;

    public class MessageLogger : ReceiveActor
    {
        private readonly Dictionary<RouteKey, IActorRef> routes;

        public MessageLogger()
        {
            routes = new Dictionary<RouteKey, IActorRef>();

            Receive<LogCommandProcessing>(command =>
            {
                var key = RouteKey.Parse(command.Machine, command.Thread);
                CreateRouteIfNotFound(key);
                FindRoute(key).Tell(command);
            });

            Receive<LogEventProcessing>(command =>
            {
                var key = RouteKey.Parse(command.Machine, command.Thread);
                CreateRouteIfNotFound(key);
                FindRoute(key).Tell(command);
            });

            Receive<LogMessageProcessed>(command =>
            {
                var key = RouteKey.Parse(command.Machine, command.Thread);
                FindRoute(key).Tell(command);
            });
        }

        private void CreateRouteIfNotFound(RouteKey key)
        {
            if (!routes.ContainsKey(key))
            {
                routes.Add(key, Context.ActorOf<Route>());
            }S
        }

        private IActorRef FindRoute(RouteKey key)
        {
            return routes[key];
        }
    }
}