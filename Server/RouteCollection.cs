namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RouteCollection : IEnumerable<Route>
    {
        readonly List<Route> routes = new List<Route>();

        public bool RouteExists()
        {
            return routes.Count > 0;
        }

        public void AddMessageToRoute(string messageName)
        {
            var messages = new List<Message>(routes.First().Messages)
            {
                CreateMessage(messageName)
            };
            routes.First().Messages = messages.ToArray();
        }

        public void AddRoute(string rootMessageName, DateTime createdOn)
        {
            routes.Add(CreateRoute(createdOn, CreateMessage(rootMessageName)));
        }

        static Message CreateMessage(string messageName)
        {
            return new Message
            {
                Id = 1,
                Name = messageName
            };
        }

        static Route CreateRoute(DateTime createdOn, Message root)
        {
            return new Route
            {
                CreatedOn = createdOn,
                Id = 1,
                Messages = new[]
                {
                    root
                },
                Root = root
            };
        }

        public Message CurrentMessage()
        {
            return routes.First().Messages.Last();
        }

        public IEnumerator<Route> GetEnumerator()
        {
            return routes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}