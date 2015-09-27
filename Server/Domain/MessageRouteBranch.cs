namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteBranch : AggregateEntity<MessageRoute>
    {
        readonly MessageRouteId routeId;
        readonly MessageType messageType;
        readonly string messageName;
        int branchClosedCount;

        public MessageRouteBranch(MessageRoute root, MessageRouteId routeId, string messageName, MessageType messageType) : base(root)
        {
            this.routeId = routeId;
            this.messageName = messageName;
            this.messageType = messageType;
        }

        public void Complete()
        {
            Complete(branchClosedCount);
        }

        public void Complete(int branches)
        {
            AddEvent(new MessageBranchCompleted
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageName = messageName,
                CloseBranchCount = branches,
                MessageType = messageType,
                RouteId = routeId.Id
            });
        }

        public void End()
        {
            branchClosedCount++;
        }
    }
}