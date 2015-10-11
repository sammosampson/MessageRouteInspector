namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class CheckRouteLimitCommandHandler : IAsyncCommandHandler<CheckRouteLimit>
    {
        readonly RouteLimitArbiter arbiter;

        public CheckRouteLimitCommandHandler(RouteLimitArbiter arbiter)
        {
            this.arbiter = arbiter;
        }

        public async Task Handle(CheckRouteLimit message)
        {
            arbiter.CheckLimit(message.RouteId, message.CreatedOn);
            await Task.FromResult(false);
        }
    }
}