namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogEventProcessingCommandHandler : LogMessageProcessingCommandHandler<LogEventProcessing>
    {
        public LogEventProcessingCommandHandler(MessageRouteLookup lookup)
            : base(lookup)
        {
        }

        protected override MessageType MessageType
        {
            get
            {
                return MessageType.Event;
            }
        }
    }
}