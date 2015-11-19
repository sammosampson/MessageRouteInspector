namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogCommandProcessingCommandHandler 
        : LogMessageProcessingCommandHandler<LogCommandProcessing>,
        IAsyncCommandHandler<LogCommandProcessing>
    {
        public LogCommandProcessingCommandHandler(MessageRouteLookup lookup)
            : base(lookup)
        {
        }

        protected override MessageType MessageType
        {
            get
            {
                return MessageType.Command;
            }
        }
    }
}