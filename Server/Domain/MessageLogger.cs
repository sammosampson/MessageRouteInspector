using System;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using Messages;
    using Akka.Actor;

    public class MessageLogger : ReceiveActor
    {
        public MessageLogger()
        {
            Receive<LogCommandProcessing>(command => PublishMessageRouteStarted(command));
        }

        private static void PublishMessageRouteStarted(LogCommandProcessing command)
        {
            Context.ActorOf(Props.Create(() => new CommandRoute()));
            Context.System.EventStream.Publish(new MessageRouteStarted(
                Guid.NewGuid(), 
                command.CreatedOn, 
                command.Machine, 
                command.Thread));
        }
    }

    internal class CommandRoute : ReceiveActor
    {
    }
}