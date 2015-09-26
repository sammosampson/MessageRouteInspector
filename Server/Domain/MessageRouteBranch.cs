namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteBranch : AggregateEntity<MessageRoute>
    {
        readonly MessageRouteId routeId;
        readonly string messageName;
        int branchClosedCount;

        public MessageRouteBranch(MessageRoute root, MessageRouteId routeId, string messageName) : base(root)
        {
            this.routeId = routeId;
            this.messageName = messageName;
        }

        public void Complete()
        {
            AddEvent(new MessageBranchCompleted
            {
                MessageName = messageName,
                CloseBranchCount = branchClosedCount,
                RouteId = routeId.Id
            });
        }

        public void End()
        {
            branchClosedCount++;
        }
    }
}