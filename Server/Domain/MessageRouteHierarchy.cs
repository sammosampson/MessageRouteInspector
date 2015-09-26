namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Collections.Generic;
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteHierarchy : AggregateEntity<MessageRoute>
    {
        readonly MessageRouteId rootId;
        readonly Stack<MessageRouteBranch> hierarchy = new Stack<MessageRouteBranch>();
        int openBranchCount;

        public MessageRouteHierarchy(MessageRoute root, MessageRouteId rootId)
            : base(root)
        {
            this.rootId = rootId;
        }

        public void StartBranch(string messageName)
        {
            if (hierarchy.Count > 0)
            {
                CompleteBranch();
            }

            AddEvent(new MessageBranchStarted { MessageName = messageName });
        }

        void ApplyEvent(MessageBranchStarted @event)
        {
            openBranchCount++;

            if (hierarchy.Count > 0)
            {
                hierarchy.Pop();
            }

            hierarchy.Push(new MessageRouteBranch(Root, rootId, @event.MessageName));
        }

        public void EndBranch()
        {
            AddEvent(new MessageBranchEnded());

            if (IsComplete())
            {
                CompleteBranch();
            }
        }

        void ApplyEvent(MessageBranchEnded @event)
        {
            openBranchCount--;
            hierarchy.Peek().End();
        }

        void CompleteBranch()
        {
            hierarchy.Peek().Complete();
        }

        public bool IsComplete()
        {
            return openBranchCount == 0;
        }
    }
}