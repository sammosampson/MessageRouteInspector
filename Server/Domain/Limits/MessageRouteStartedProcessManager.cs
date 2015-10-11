namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteStartedProcessManager : IProjection<MessageRouteStarted>
    {
        readonly ICommandBus bus;

        public MessageRouteStartedProcessManager(ICommandBus bus)
        {
            this.bus = bus;
        }

        public async Task Handle(MessageRouteStarted message)
        {
            await bus.SendCommandAsync(new CheckRouteLimit
            {
                RouteId = message.Id,
                CreatedOn = message.CreatedOn
            });
        }
    }
}