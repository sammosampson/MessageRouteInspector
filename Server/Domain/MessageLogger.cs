

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Collections.Generic;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using global::Akka.Actor;

    internal class MessageLogger : ReceiveActor
    {
        private readonly Dictionary<MachineThreadId, IActorRef> routes;
        private readonly Dictionary<CorrelationId, IActorRef> routesWithCorrelation;

        public MessageLogger()
        {
            routes = new Dictionary<MachineThreadId, IActorRef>();
            routesWithCorrelation = new Dictionary<CorrelationId, IActorRef>();

            Receive<LogCommandProcessing>(command => RouteMessage(command));
            Receive<LogEventProcessing>(command => RouteMessage(command));
            Receive<LogMessageProcessingFailure>(command => RouteMessage(command));
            Receive<LogMessageProcessed>(command => RouteMessage(command));
        }

        private void RouteMessage<TMessage>(TMessage message) where TMessage: LogMessage
        {
            if (string.IsNullOrEmpty(message.CorrelationId))
            {
                RouteMessageWithoutCorrelation(message);
            }
            else
            {
                RouteMessageWithCorrelation(message);
            }
        }

        private void RouteMessageWithCorrelation<TMessage>(TMessage message) where TMessage : LogMessage
        {
            var id = CorrelationId.Parse(message.CorrelationId);
            CreateCorrelatedRouteIfNotFound(id);
            routesWithCorrelation[id].Tell(message);
        }

        private void CreateCorrelatedRouteIfNotFound(CorrelationId id)
        {
            if (!routesWithCorrelation.ContainsKey(id))
            {
                routesWithCorrelation.Add(id, Context.ActorOf(Props.Create(() => new RouteProcess())));
            }
        }

        private void RouteMessageWithoutCorrelation<TMessage>(TMessage message) where TMessage : LogMessage
        {
            var processId = MachineThreadId.Parse(message.Machine, message.Thread);
            CreateRouteIfNotFound(processId);
            routes[processId].Tell(message);
        }

        private void CreateRouteIfNotFound(MachineThreadId machineThreadId)
        {
            if (!routes.ContainsKey(machineThreadId))
            {
                routes.Add(machineThreadId, Context.ActorOf(Props.Create(() => new RouteProcess())));
            }
        }
    }
}