namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using System;

    public interface IMessageRouteHub
    {
        void MessageRouteStarted(Guid id, DateTime createdOn, string machineName, int thread);

        void MessageRouteEnded(Guid id, DateTime createdOn);

        void MessageBranchCompleted(Guid routeId, Guid messageId, string messageName, MessageType messageType, int closeBranchCount);
    }
}