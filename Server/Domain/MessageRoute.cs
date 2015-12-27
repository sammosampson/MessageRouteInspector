using System;
using SystemDot.MessageRouteInspector.Server.Messages;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MessageRoute : ReceiveActor
    {
        private Guid routeId;
        private MessageBranch currentMessage;
        private int branchesToClose;
        private int openBranches;

        protected override void PreStart()
        {
            routeId = Guid.NewGuid();
            Become(Unstarted);
        }

        private void Unstarted()
        {
            Receive<LogCommandProcessing>(command =>
            {
                StartRoute(command);
                OpenBranch(command, MessageType.Command);
            });

            Receive<LogEventProcessing>(command =>
            {
                StartRoute(command);
                OpenBranch(command, MessageType.Event);
            });
        }
        
        private void BranchOpen()
        {
            Receive<LogMessageProcessed>(command => CloseBranch());
        }

        private void BranchClosed()
        {
            Receive<LogCommandProcessing>(command => OpenBranch(command, MessageType.Command));
            Receive<LogEventProcessing>(command => OpenBranch(command, MessageType.Event));
        }

        private void StartRoute(LogMessageProcessing command)
        {
            Publish(new MessageRouteStarted(
                routeId,
                command.CreatedOn,
                command.Machine,
                command.Thread));
        }

        private void OpenBranch(LogMessageProcessing command, MessageType type)
        {
            branchesToClose++;
            openBranches++;
            currentMessage = command.ToMessageBranch(type);
            Become(BranchOpen);
        }

        private void CloseBranch()
        {
            openBranches--;

            int closedBranchCount = 0;

            if (openBranches == 0)
            {
                closedBranchCount = branchesToClose;
                branchesToClose = 0;
            }

            PublishMessageBranchCompleted(closedBranchCount);
            currentMessage = null;
            Become(BranchClosed);
        }

        private void PublishMessageBranchCompleted(int closedBranchCount)
        {
            Publish(new MessageBranchCompleted(
                routeId,
                currentMessage.Id,
                currentMessage.Name,
                currentMessage.Type,
                closedBranchCount));
        }

        private void Publish(object @event)
        {
            Context.System.EventStream.Publish(@event);
        }
    }
}