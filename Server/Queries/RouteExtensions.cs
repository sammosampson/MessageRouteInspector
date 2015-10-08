namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public static class RouteExtensions
    {
        public static Route AddMessage(this Route route, string messageId, string messageName, int closeBranchCount, MessageType messageType)
        {
            Route newRoute = new Route
            {
                Id = route.Id,
                CreatedOn = route.CreatedOn,
                Messages = new List<Message>(route.Messages) { AddMessage(messageId, messageName, closeBranchCount, messageType) }.ToArray()
            };

            if (newRoute.Messages.Count() == 1)
            {
                newRoute.Root = newRoute.Messages.First();
            }

            return newRoute;
        }

        static Message AddMessage(string messageId, string messageName, int closeBranchCount, MessageType messageType)
        {
            return new Message
            {
                Id = messageId,
                Name = messageName,
                CloseBranchCount = closeBranchCount,
                Type = messageType
            };
        }
    }
}