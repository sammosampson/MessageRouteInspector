namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using System;

    public interface IMessageRouteHubClient
    {
        void MessageRouteStarted(string id, long createdOn, string machineName, int thread);

        void MessageRouteEnded(string id, long createdOn);

        void MessageBranchCompleted(string routeId, string messageId, string messageName, int messageType, int closeBranchCount);
    }
}