namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessingFailureCommandHandler : IAsyncCommandHandler<LogMessageProcessingFailure>
    {
        readonly MessageRouteLookup lookup;

        public LogMessageProcessingFailureCommandHandler(MessageRouteLookup lookup)
        {
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessingFailure message)
        {
            if (lookup.MessageRouteExists(message.Machine, message.Thread))
            {
                lookup.LookupMessageRoute(message.Machine, message.Thread).LogMessageProcessingFailure(message.FailureName);
            }

            await Task.FromResult(false);
        }
    }
}