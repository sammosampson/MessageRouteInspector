namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Queries;

    public class MessageLoggingClient
    {
        private readonly CommandBus commandBus;
        IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler;
        
        public MessageLoggingClient(CommandBus commandBus, IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler)
        {
            this.commandBus = commandBus;
            this.getRoutesQueryHandler = getRoutesQueryHandler;
        }

        public async Task LogMessageProcessingAsync(string messageName)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessing { MessageName = messageName });
        }

        public async Task<Route[]> GetRoutesAsync()
        {
            var response =  await getRoutesQueryHandler.Handle(new GetRoutesQuery());
            return response.Routes;
        }
    }
}