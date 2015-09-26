namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Commands;
    using SystemDot.MessageRouteInspector.Server.Queries;

    public class MessageLoggingClient
    {
        private readonly CommandBus commandBus;
        readonly IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler;
        
        public MessageLoggingClient(CommandBus commandBus, IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler)
        {
            this.commandBus = commandBus;
            this.getRoutesQueryHandler = getRoutesQueryHandler;
        }

        public async Task LogMessageProcessingAsync(string messageName, string machine, int thread, DateTime dated)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessing
            {
                MessageName = messageName, 
                CreatedOn = dated,
                Machine = machine,
                Thread = thread
            });
        }

        public async Task LogMessageProcessedAsync(string machine, int thread)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessed
            {
                Machine = machine, 
                Thread = thread
            });
        }

        public async Task<Route[]> GetRoutesAsync()
        {
            var response =  await getRoutesQueryHandler.Handle(new GetRoutesQuery());
            return response.Routes;
        }
    }
}