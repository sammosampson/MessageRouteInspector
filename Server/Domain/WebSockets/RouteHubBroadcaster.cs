namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using SystemDot.Akka;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class RouteHubBroadcaster : ViewActor
    {
        private readonly IMessageRouteHubClient hubClient;

        public RouteHubBroadcaster(IMessageRouteHubClient hubClient)
        {
            this.hubClient = hubClient;
            ProjectEvent<MessageRouteStarted>(Handle);
            ProjectEvent<MessageRouteEnded>(Handle);
            ProjectEvent<MessageBranchCompleted>(Handle);
        }

        private void Handle(MessageRouteStarted message)
        {
            hubClient.MessageRouteStarted(message.Id.ToString(), message.CreatedOn.Ticks, message.MachineName, message.Thread);
        }

        private void Handle(MessageRouteEnded message)
        {
            hubClient.MessageRouteEnded(message.Id.ToString(), message.CreatedOn.Ticks);
        }

        private void Handle(MessageBranchCompleted message)
        {
            hubClient.MessageBranchCompleted(message.RouteId.ToString(), message.MessageId.ToString(), message.MessageName, message.MessageType, message.CloseBranchCount);
        }
    }
}