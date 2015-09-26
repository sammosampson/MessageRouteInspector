namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using SystemDot.EventSourcing.Aggregation;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRoute : AggregateRoot
    {
        MessageRouteHierarchy hierarchy;
        ProcessId processId;

        public static MessageRoute Start(string machineName, int thread, DateTime createdOn)
        {
            return new MessageRoute(machineName, thread, createdOn, new MessageRouteId());
        }

        public MessageRoute()
        {
            
        }

        MessageRoute(string machineName, int thread, DateTime createdOn, MessageRouteId id) : base(id)
        {
            AddEvent(new MessageRouteStarted
            {
                Id = id.Id,
                MachineName = machineName,
                Thread = thread,
                CreatedOn = createdOn
            });
        }

        public void LogMessageProcessing(string message)
        {
            hierarchy.StartBranch(message);
        }

        void ApplyEvent(MessageRouteStarted @event)
        {
            hierarchy = new MessageRouteHierarchy(this, new MessageRouteId(@event.Id));
            processId = new ProcessId(@event.MachineName, @event.Thread);
        }

        public void LogMessageProcessed()
        {
            hierarchy.EndBranch();

            if (!hierarchy.IsComplete())
            {
                return;
            }

            AddEvent(new MessageRouteEnded
            {
                MachineName = processId.MachineName,
                Thread = processId.Thread
            });
        }

        
    }
}