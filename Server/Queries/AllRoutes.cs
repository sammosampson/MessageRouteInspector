namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class AllRoutes : IEnumerable<Route>
    {
        ImmutableDictionary<string, Route> routes;

        public AllRoutes()
        {
            routes = ImmutableDictionary<string, Route>.Empty;
            var message = new Message
            {
                CloseBranchCount = 0, 
                Id = "0", 
                Name = "No route", 
                Type = MessageType.Command
            };
            routes.Add("0", new Route
            {
                Id = "0", 
                CreatedOn = DateTime.Now.ToJavaString(),
                Messages = new[] { message }, 
                Root = message,
                MachineName = string.Empty
            });
        }

        public void AddRoute(string id, DateTime createdOn, string machineName)
        {
            var route = new Route
            {
                Id = id,
                CreatedOn = createdOn.ToJavaString(),
                Messages = new Message[0],
                MachineName = machineName
            };
            routes = routes.Add(id, route);
        }

        public void RemoveRoute(string id)
        {
            routes = routes.Remove(id);
        }

        public IEnumerator<Route> GetEnumerator()
        {
            return routes.Values.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddMessage(string routeId, MessageBranchCompleted message)
        {
            routes = routes
                .SetItem(routeId, routes[routeId]
                    .AddMessage(message.MessageId.ToString(), message.MessageName, message.CloseBranchCount, message.MessageType));
        }

        public Route this[string routeId]
        {
            get
            {
                return routes[routeId];
            }
        }
    }
} 