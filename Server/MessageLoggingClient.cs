namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;

    public class MessageLoggingClient
    {
        private readonly CommandBus bus;

        public MessageLoggingClient(CommandBus bus)
        {
            this.bus = bus;
        }

        public async Task LogMessageProcessingAsync(string messageName)
        {
            await bus.SendCommandAsync(new LogMessageProcessing { MessageName = messageName });
        }
    }
}