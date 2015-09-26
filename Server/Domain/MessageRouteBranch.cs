namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteBranch : AggregateEntity<MessageRoute>
    {
        readonly string messageName;
        int branchClosedCount;

        public MessageRouteBranch(MessageRoute root, string messageName) : base(root)
        {
            this.messageName = messageName;
        }

        public void Complete()
        {
            AddEvent(new MessageBranchCompleted
            {
                MessageName = messageName,
                CloseBranchCount = branchClosedCount
            });
        }

        public void End()
        {
            branchClosedCount++;
        }
    }
}