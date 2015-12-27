using System.Collections.Generic;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using Messages;

    public class MessageLogger : ReceiveActor
    {
        private readonly Dictionary<MessageRouteKey, IActorRef> routes;

        public MessageLogger()
        {
            routes = new Dictionary<MessageRouteKey, IActorRef>();

            Receive<LogCommandProcessing>(command =>
            {
                RouteMessageProcessing(command);
            });

            Receive<LogEventProcessing>(command =>
            {
                RouteMessageProcessing(command);
            });

            Receive<LogMessageProcessed>(command =>
            {
                var key = MessageRouteKey.Parse(command.Machine, command.Thread);
                FindRoute(key).Tell(command);
            });
        }

        private void RouteMessageProcessing(LogMessageProcessing command)
        {
            var key = MessageRouteKey.Parse(command.Machine, command.Thread);
            CreateRouteIfNotFound(key);
            FindRoute(key).Tell(command);
        }

        private void CreateRouteIfNotFound(MessageRouteKey key)
        {
            if (!routes.ContainsKey(key))
            {
                routes.Add(key, Context.ActorOf<MessageRoute>());
            }
        }

        private IActorRef FindRoute(MessageRouteKey key)
        {
            return routes[key];
        }
    }
}