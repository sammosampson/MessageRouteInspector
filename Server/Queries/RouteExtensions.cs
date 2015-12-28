using System.Collections.Generic;
using System.Linq;
using SystemDot.MessageRouteInspector.Server.Queries.Messages;

namespace SystemDot.MessageRouteInspector.Server.Queries
{
    public static class RouteExtensions
    {
        public static Route AddMessage(this Route route, string messageId, string messageName, int closeBranchCount,
            MessageType messageType)
        {
            var messages = new List<Message>(route.Messages)
            {
                AddMessage(messageId, messageName, closeBranchCount, messageType)
            }.ToArray();

            var newRoute = new Route(
                route.Id,
                messages.Count() == 1 ? messages.First() : route.Root,
                messages,
                route.CreatedOn,
                route.MachineName);

            return newRoute;
        }

        static Message AddMessage(string messageId, string messageName, int closeBranchCount, MessageType messageType)
        {
            return new Message(
                messageId,
                messageName,
                closeBranchCount,
                messageType);
        }
    }
}