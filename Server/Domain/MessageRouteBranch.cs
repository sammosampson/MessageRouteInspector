namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteBranch : PublishingEntity
    {
        readonly MessageId id;
        readonly MessageRouteId routeId;
        readonly MessageType messageType;
        readonly string messageName;
        int branchClosedCount;

        public MessageRouteBranch(MessageRoute route, MessageRouteId routeId, string messageName, MessageType messageType)
            : base(route)
        {
            id = new MessageId();
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
            PublishEvent(new MessageBranchCompleted
            {
                MessageId = id,
                MessageName = messageName,
                CloseBranchCount = branches,
                MessageType = messageType,
                RouteId = routeId
            });
        }

        public void End()
        {
            branchClosedCount++;
        }
    }
}