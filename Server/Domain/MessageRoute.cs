namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using SystemDot.Domain.Events;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRoute : PublishingRoot
    {
        readonly MessageRouteHierarchy hierarchy;
        readonly ProcessId processId;

        public static MessageRoute Open(IEventBus bus, ProcessId processId, DateTime createdOn)
        {
            return new MessageRoute(bus, processId, createdOn);
        }

        MessageRoute(IEventBus bus, ProcessId processId, DateTime createdOn)
            : base(bus)
        {
            var id = new MessageRouteId();
            hierarchy = new MessageRouteHierarchy(this, id);
            this.processId = processId;

            PublishEvent(new MessageRouteStarted
            {
                Id = id,
                MachineName = processId.MachineName,
                Thread = processId.Thread,
                CreatedOn = createdOn
            });
        }

        public void LogMessageProcessing(string message, MessageType messageType)
        {
            hierarchy.StartBranch(message, messageType);
        }

        public void LogMessageProcessingFailure(string failureName)
        {
            hierarchy.Fail(failureName);
            EndRouteIfHierachyComplete();
        }

        public void LogMessageProcessed()
        {
            hierarchy.EndBranch();
            EndRouteIfHierachyComplete();
        }

        private void EndRouteIfHierachyComplete()
        {
            if (!hierarchy.IsComplete())
            {
                return;
            }

            PublishEvent(new MessageRouteEnded
            {
                MachineName = processId.MachineName,
                Thread = processId.Thread
            });
        }

    }
}