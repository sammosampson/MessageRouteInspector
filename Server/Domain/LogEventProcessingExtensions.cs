using SystemDot.MessageRouteInspector.Server.Messages;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public static class LogEventProcessingExtensions
    {
        public static MessageBranch ToMessageBranch(this LogEventProcessing from)
        {
            return new EventMessageBranch(from.MessageName);
        }
    }
}