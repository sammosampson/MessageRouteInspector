using System.Collections.Generic;
using SystemDot.MessageRouteInspector.Server.Messages;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    internal class MessageLogger : ReceiveActor
    {
        private readonly Dictionary<MachineThreadId, IActorRef> routes;

        public MessageLogger()
        {
            routes = new Dictionary<MachineThreadId, IActorRef>();

            Receive<LogCommandProcessing>(command => RouteMessage(command, command.Machine, command.Thread));
            Receive<LogEventProcessing>(command => RouteMessage(command, command.Machine, command.Thread));
            Receive<LogMessageProcessingFailure>(command => RouteMessage(command, command.Machine, command.Thread));
            Receive<LogMessageProcessed>(command => RouteMessage(command, command.Machine, command.Thread));
        }

        private void RouteMessage<TMessage>(TMessage message, string machine, int thread)
        {
            var processId = MachineThreadId.Parse(machine, thread);
            CreateRouteIfNotFound(processId);
            routes[processId].Tell(message);
        }

        private void CreateRouteIfNotFound(MachineThreadId machineThreadId)
        {
            if (!routes.ContainsKey(machineThreadId))
            {
                routes.Add(machineThreadId, Context.ActorOf(Props.Create(() => new MachineThreadProcess())));
            }
        }
    }
}