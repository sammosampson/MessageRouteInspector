namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    public class MessageRouteHubLocator : IMessageRouteHubLocator
    {
        public IMessageRouteHub Locate()
        {
            return new DefaultHubManager(GlobalHost.DependencyResolver).ResolveHub("messageRouteHub") as IMessageRouteHub;
        }
    }
}