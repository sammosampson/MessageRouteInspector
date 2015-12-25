namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageBranchCompleted
    {
        public Guid RouteId { get; private set; }

        public Guid MessageId { get; private set; }

        public string MessageName { get; private set; }

        public MessageType MessageType { get; private set; }

        public int CloseBranchCount { get; private set; }

        public MessageBranchCompleted(Guid routeId, Guid messageId, string messageName, MessageType messageType, int closeBranchCount)
        {
            RouteId = routeId;
            MessageId = messageId;
            MessageName = messageName;
            MessageType = messageType;
            CloseBranchCount = closeBranchCount;
        }
    }
}