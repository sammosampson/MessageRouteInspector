namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogEventProcessingCommandHandler 
        : LogMessageProcessingCommandHandler<LogEventProcessing>,
        IAsyncCommandHandler<LogEventProcessing>
        
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