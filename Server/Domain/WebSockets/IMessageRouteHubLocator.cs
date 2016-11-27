namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    public interface IMessageRouteHubLocator
    {
        IMessageRouteHub Locate();
    }
}