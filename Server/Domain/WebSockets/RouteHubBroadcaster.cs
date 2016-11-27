namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using SystemDot.Akka;
    using SystemDot.MessageRouteInspector.Server.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class RouteHubBroadcaster : ViewActor
    {
        private readonly IMessageRouteHubLocator hubLocator;

        public RouteHubBroadcaster(IMessageRouteHubLocator hubLocator)
        {
            this.hubLocator = hubLocator;
            ProjectEvent<MessageRouteStarted>(Handle);
            ProjectEvent<MessageRouteEnded>(Handle);
            ProjectEvent<MessageBranchCompleted>(Handle);
        }

        private void Handle(MessageRouteStarted message)
        {
            hubLocator.Locate().MessageRouteStarted(message.Id, message.CreatedOn, message.MachineName, message.Thread);
        }

        private void Handle(MessageRouteEnded message)
        {
            hubLocator.Locate().MessageRouteEnded(message.Id, message.CreatedOn);
        }

        private void Handle(MessageBranchCompleted message)
        {
            hubLocator.Locate().MessageBranchCompleted(message.RouteId, message.MessageId, message.MessageName, message.MessageType, message.CloseBranchCount);
        }
    }
}