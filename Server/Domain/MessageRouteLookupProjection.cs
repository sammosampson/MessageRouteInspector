namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageRouteLookupProjection : IProjection<MessageRouteEnded>
    {
        readonly MessageRouteLookup lookUp;

        public MessageRouteLookupProjection(MessageRouteLookup lookUp)
        {
            this.lookUp = lookUp;
        }

        public async Task Handle(MessageRouteEnded message)
        {
            lookUp.CloseRoute(message.MachineName, message.Thread);
            await Task.FromResult(false);
        }
    }
}