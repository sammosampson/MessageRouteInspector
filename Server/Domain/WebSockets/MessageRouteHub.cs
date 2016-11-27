namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using System;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("messageRouteHub")]
    public class MessageRouteHub : Hub<IMessageRouteHub>, IMessageRouteHub
    {
        public void MessageRouteStarted(Guid id, DateTime createdOn, string machineName, int thread)
        {
            Clients.All.MessageRouteStarted(id, createdOn, machineName, thread);
        }

        public void MessageRouteEnded(Guid id, DateTime createdOn)
        {
            Clients.All.MessageRouteEnded(id, createdOn);
        }

        public void MessageBranchCompleted(Guid routeId, Guid messageId, string messageName, MessageType messageType, int closeBranchCount)
        {
            Clients.All.MessageBranchCompleted(routeId, messageId, messageName, messageType, closeBranchCount);

        }
    }
}