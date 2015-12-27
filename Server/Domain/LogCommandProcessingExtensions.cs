using SystemDot.MessageRouteInspector.Server.Messages;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public static class LogCommandProcessingExtensions
    {
        public static MessageBranch ToMessageBranch(this LogCommandProcessing from)
        {
            return new CommandMessageBranch(from.MessageName);
        }
    }
}