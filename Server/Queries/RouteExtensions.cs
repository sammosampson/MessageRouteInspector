namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public static class RouteExtensions
    {
        public static void AddMessage(this Route route, MessageBranchCompleted message)
        {
            route.Messages = new List<Message>(route.Messages)
            {
                AddMessage(message)
            }.ToArray();

            SetRootToFirstMessage(route);
        }

        static void SetRootToFirstMessage(this Route route)
        {
            if (route.Messages.Count() == 1)
            {
                route.Root = route.Messages.First();
            }
        }

        static Message AddMessage(MessageBranchCompleted message)
        {
            return new Message
            {
                Name = message.MessageName,
                CloseBranchCount = message.CloseBranchCount
            };
        }
    }
}