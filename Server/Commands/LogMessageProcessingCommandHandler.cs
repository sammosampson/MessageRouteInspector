namespace SystemDot.MessageRouteInspector.Server.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;

    public class LogMessageProcessingCommandHandler : IAsyncCommandHandler<LogMessageProcessing>
    {
        readonly RouteCollection routes;

        public LogMessageProcessingCommandHandler(RouteCollection routes)
        {
            this.routes = routes;
        }

        public async Task Handle(LogMessageProcessing message)
        {
            if (!routes.RouteExists())
            {
                routes.AddRoute(message.MessageName, message.CreatedOn);
            }
            else
            {
                routes.AddMessageToRoute(message.MessageName);
            }
            await Task.FromResult(false);
        }
    }
}