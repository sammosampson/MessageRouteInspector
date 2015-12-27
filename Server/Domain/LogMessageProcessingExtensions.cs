using SystemDot.MessageRouteInspector.Server.Messages;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public static class LogMessageProcessingExtensions
    {   public static MessageBranch ToMessageBranch(this LogMessageProcessing @from, MessageType type)
        {
            return new MessageBranch(type, from.MessageName);
        }
    }
}