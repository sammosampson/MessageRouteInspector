using System;
using SystemDot.MessageRouteInspector.Server.Messages;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class Route : ReceiveActor
    {
        private Guid routeId;
        private MessageBranch currentMessage;

        protected override void PreStart()
        {
            routeId = Guid.NewGuid();
            Become(Unstarted);
        }

        private void Unstarted()
        {
            Receive<LogCommandProcessing>(command =>
            {
                PublishLogEventProcessing(command);
                currentMessage = command.ToMessageBranch();
                Become(BranchOpen);
            });

            Receive<LogEventProcessing>(command =>
            {
                PublishLogEventProcessing(command);
                currentMessage = command.ToMessageBranch();
                Become(BranchOpen);
            });
        }

        private void BranchOpen()
        {
            Receive<LogMessageProcessed>(command =>
            {
                PublishMessageBranchCompleted();
                currentMessage = null;
                Become(BranchClosed);
            });
        }

        private void BranchClosed()
        {
            Receive<LogCommandProcessing>(command =>
            {
                currentMessage = command.ToMessageBranch();
                Become(BranchOpen);
            });

            Receive<LogEventProcessing>(command =>
            {
                currentMessage = command.ToMessageBranch();
                Become(BranchOpen);
            });
        }

        private void PublishLogEventProcessing(LogMessageProcessing command)
        {
            Publish(new MessageRouteStarted(
                routeId,
                command.CreatedOn,
                command.Machine,
                command.Thread));
        }

        private void PublishMessageBranchCompleted()
        {
            Publish(new MessageBranchCompleted(
                routeId,
                currentMessage.Id,
                currentMessage.Name,
                currentMessage.Type,
                1));
        }

        private void Publish(object @event)
        {
            Context.System.EventStream.Publish(@event);
        }
    }
}