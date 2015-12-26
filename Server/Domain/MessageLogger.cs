using System;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using Messages;

    public class MessageLogger : ReceiveActor
    {
        private IActorRef route;

        public MessageLogger()
        {
            Receive<LogCommandProcessing>(command =>
            {
                CreateRouteIfNotFound();
                FindRoute().Tell(command);
            });

            Receive<LogMessageProcessed>(command =>
            {
                FindRoute().Tell(command);
            });
        }

        private void CreateRouteIfNotFound()
        {
            if (route == null)
            {
                route = Context.ActorOf<Route>();
            }
        }

        private IActorRef FindRoute()
        {
            return route;
        }
    }

    public class Route : ReceiveActor
    {
        private Guid routeId;
        private LogCommandProcessing currentMessage;

        protected override void PreStart()
        {
            routeId = Guid.NewGuid();
            Become(Unstarted);
        }

        private void Unstarted()
        {
            Receive<LogCommandProcessing>(command =>
            {
                Publish(new MessageRouteStarted(
                    routeId,
                    command.CreatedOn,
                    command.Machine,
                    command.Thread));

                currentMessage = command;
                Become(BranchOpen);
            });

        }

        private void BranchOpen()
        {
            Receive<LogMessageProcessed>(command =>
            {
                Publish(new MessageBranchCompleted(
                    routeId,
                    Guid.NewGuid(), 
                    currentMessage.MessageName,
                    MessageType.Command, 
                    1));

                currentMessage = null;
                Become(BranchClosed);
            });
        }

        private void BranchClosed()
        {
            Receive<LogCommandProcessing>(command =>
            {
                currentMessage = command;
                Become(BranchOpen);
            });
        }

        private void Publish(object @event)
        {
            Context.System.EventStream.Publish(@event);
        }
    }
}