
namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.MessageRouteInspector.Server.Domain.WebSockets;
    using Microsoft.AspNet.SignalR;

    public class MessageRouteHubClient : IMessageRouteHubClient
    {
        public void MessageRouteStarted(string id, long createdOn, string machineName, int thread)
        {
            GetHubContext().Clients.All.MessageRouteStarted(id, createdOn, machineName, thread);

        }

        public void MessageRouteEnded(string id, long createdOn)
        {
            GetHubContext().Clients.All.MessageRouteEnded(id, createdOn);
        }

        public void MessageBranchCompleted(string routeId, string messageId, string messageName, int messageType, int closeBranchCount)
        {
            GetHubContext().Clients.All.MessageBranchCompleted(routeId, messageId, messageName, messageType, closeBranchCount);
        }

        private static IHubContext<IMessageRouteHubClient> GetHubContext()
        {
            return GlobalHost.ConnectionManager.GetHubContext<MessageRouteHub, IMessageRouteHubClient>();
        }

    }
}