namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using System.Collections;
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRoute : AggregateRoot
    {
        MessageRouteHierarchy hierarchy;

        public void LogMessageProcessing(string message, DateTime createdOn)
        {
            StartRouteIfNotYetStarted(createdOn);
            hierarchy.StartBranch(message);
        }

        void StartRouteIfNotYetStarted(DateTime createdOn)
        {
            if (hierarchy == null)
            {
                AddEvent(new MessageRouteStarted {CreatedOn = createdOn});
            }
        }

        void ApplyEvent(MessageRouteStarted @event)
        {
            hierarchy = new MessageRouteHierarchy(this);
        }

        public void LogMessageProcessed()
        {
            hierarchy.EndBranch();
        }
    }
}