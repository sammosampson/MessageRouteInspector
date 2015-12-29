using SystemDot.Akka;
using SystemDot.MessageRouteInspector.Server.Messages;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    internal class MessageRouteBranch : AggregateEntity
    {
        readonly MessageId messageId;
        readonly MessageRouteId routeId;
        readonly MessageType messageType;
        readonly string messageName;
        int branchClosedCount;

        public MessageRouteBranch(AggregateRootActor root, MessageRouteId routeId, string messageName, MessageType messageType) 
            : base(root)
        {
            messageId = new MessageId();
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
            Publish(new MessageBranchCompleted(
                routeId,
                messageId,
                messageName,
                messageType,
                branches));
        }

        public void End()
        {
            branchClosedCount++;
        }
    }
}