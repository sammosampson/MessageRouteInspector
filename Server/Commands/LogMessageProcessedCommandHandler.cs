namespace SystemDot.MessageRouteInspector.Server.Commands
{
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;

    public class LogMessageProcessedCommandHandler : IAsyncCommandHandler<LogMessageProcessed>
    {
        readonly RouteCollection routes;

        public LogMessageProcessedCommandHandler(RouteCollection routes)
        {
            this.routes = routes;
        }

        public async Task Handle(LogMessageProcessed message)
        {
            routes.CurrentMessage().CloseBranchCount++;
            await Task.FromResult(false);
        }
    }
}