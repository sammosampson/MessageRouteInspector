namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using System.Collections.Generic;
    using SystemDot.Akka;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRoute : AggregateEntity
    {
        readonly MessageRouteId routeId;
        readonly Stack<MessageRouteBranch> hierarchy = new Stack<MessageRouteBranch>();
        int openBranchCount;
        DateTime createdOn;

        public MessageRoute(AggregateRootActor root) : base(root)
        {
            routeId = new MessageRouteId();
        }

        public void Start(string messageName, MessageType messageType, DateTime createdOn, string machine, int thread)
        {
            this.createdOn = createdOn;
            OpenBranch(messageName, messageType);
            Publish(new MessageRouteStarted(routeId, createdOn, machine, thread));
        }

        public void OpenBranch(string messageName, MessageType messageType)
        {
            CompletePreviousBranch();

            openBranchCount++;

            if (hierarchy.Count > 0)
            {
                hierarchy.Pop();
            }

            hierarchy.Push(new MessageRouteBranch(Root, routeId, messageName, messageType));
        }

        public void Fail(string failureName)
        {
            OpenBranch(failureName, MessageType.Failure);
            CompleteAllBranches();
        }

        void CompletePreviousBranch()
        {
            if (hierarchy.Count > 0)
            {
                CompleteBranch();
            }
        }

        public void CloseBranch()
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
            if (IsComplete())
            {
                CompleteRoute();
            }
        }

        void CompleteAllBranches()
        {
            hierarchy.Peek().Complete(openBranchCount);
            CompleteRoute();
        }

        void CompleteRoute()
        {
            openBranchCount = 0;
            Publish(new MessageRouteEnded(routeId, createdOn));
        }
    }
}