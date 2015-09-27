namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    [HydrateProjectionAtStartup]
    public class MessageRouteLookupProjection : 
        IProjection<MessageRouteStarted>, 
        IProjection<MessageRouteEnded>
    {
        readonly MessageRouteLookup lookUp;

        public MessageRouteLookupProjection(MessageRouteLookup lookUp)
        {
            this.lookUp = lookUp;
        }

        public async Task Handle(MessageRouteStarted message)
        {
            lookUp.OpenRoute(message.MachineName, message.Thread, new MessageRouteId(message.Id));
            await Task.FromResult(false);
        }

        public async Task Handle(MessageRouteEnded message)
        {
            lookUp.CloseRoute(message.MachineName, message.Thread);
            await Task.FromResult(false);
        }
    }
}