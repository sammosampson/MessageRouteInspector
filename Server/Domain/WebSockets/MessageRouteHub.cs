namespace SystemDot.MessageRouteInspector.Server.Domain.WebSockets
{
    using System;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("messageRouteHub")]
    public class MessageRouteHub : Hub
    {
    }
}