using System;
using SystemDot.Akka;
using SystemDot.MessageRouteInspector.Server.Messages;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MachineThreadProcess : AggregateRootActor
    {
        private MessageRoute currentRoute;

        protected override void PreStart()
        {
            Become(RouteNotYetStarted);
        }

        private void RouteNotYetStarted()
        {
            currentRoute = new MessageRoute(this);
            Receive<LogCommandProcessing>(command => StartRoute(command, MessageType.Command));
            Receive<LogEventProcessing>(command => StartRoute(command, MessageType.Event));
        }

        private void StartRoute(LogMessageProcessing command, MessageType messageType)
        {
            currentRoute.Start(
                command.MessageName, 
                messageType, 
                command.CreatedOn, 
                command.Machine,
                command.Thread);

            Become(RouteStarted);
        }

        private void RouteStarted()
        {
            Receive<LogMessageProcessed>(command => CloseBranch());
            Receive<LogMessageProcessingFailure>(command => FailRoute(command.FailureName));
            Receive<LogCommandProcessing>(command => currentRoute.OpenBranch(command.MessageName, MessageType.Command));
            Receive<LogEventProcessing>(command => currentRoute.OpenBranch(command.MessageName, MessageType.Event));
        }

        private void FailRoute(string failureName)
        {
            currentRoute.Fail(failureName);
            ResetIfRouteComplete();
        }

        private void CloseBranch()
        {
            currentRoute.CloseBranch();
            ResetIfRouteComplete();
        }

        private void ResetIfRouteComplete()
        {
            if (currentRoute.IsComplete())
            {
                Become(RouteNotYetStarted);
            }
        }
    }
}