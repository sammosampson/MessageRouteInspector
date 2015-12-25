using System;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using Messages;

    public class MessageLogger : ReceiveActor
    {
        public MessageLogger()
        {
            Receive<LogCommandProcessing>(command => PublishMessageRouteStarted(command));
        }

        private static void PublishMessageRouteStarted(LogCommandProcessing command)
        {
            Guid routeId = Guid.NewGuid();

            Context.System.EventStream.Publish(new MessageRouteStarted(
                routeId, 
                command.CreatedOn, 
                command.Machine, 
                command.Thread));

            Context.System.EventStream.Publish(new MessageBranchCompleted(
                routeId, 
                Guid.NewGuid(), 
                command.MessageName, 
                MessageType.Command, 
                1));
        }
    }
}