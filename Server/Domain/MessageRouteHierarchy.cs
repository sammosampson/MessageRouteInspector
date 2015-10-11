namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Collections.Generic;

    public class MessageRouteHierarchy : PublishingEntity
    {
        readonly MessageRoute route;
        readonly MessageRouteId routeId;
        readonly Stack<MessageRouteBranch> hierarchy = new Stack<MessageRouteBranch>();
        int openBranchCount;

        public MessageRouteHierarchy(MessageRoute route, MessageRouteId routeId) : base(route)
        {
            this.route = route;
            this.routeId = routeId;
        }

        public void StartBranch(string messageName, MessageType messageType)
        {
            CompletePreviousBranch();

            openBranchCount++;

            if (hierarchy.Count > 0)
            {
                hierarchy.Pop();
            }

            hierarchy.Push(new MessageRouteBranch(route, routeId, messageName, messageType));
        }

        public void Fail(string failureName)
        {
            StartBranch(failureName, MessageType.Failure);
            CompleteAllBranches();
        }

        void CompletePreviousBranch()
        {
            if (hierarchy.Count > 0)
            {
                CompleteBranch();
            }
        }

        public void EndBranch()
        {
            openBranchCount--;
            hierarchy.Peek().End();

            if (IsComplete())
            {
                CompleteBranch();
            }
        }

        public bool IsComplete()
        {
            return openBranchCount == 0;
        }
        
        void CompleteBranch()
        {
            hierarchy.Peek().Complete();
        }

        void CompleteAllBranches()
        {
            hierarchy.Peek().Complete(openBranchCount);
            openBranchCount = 0;
        }
    }
}