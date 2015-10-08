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
        }

        public void AddRoute(string id, DateTime createdOn)
        {
            var route = new Route
            {
                Id = id,
                CreatedOn = createdOn, 
                Messages = new Message[0]
            };
            routes = routes.Add(id, route);
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
            routes = routes.SetItem(routeId, routes[routeId].AddMessage(message.MessageId, message.MessageName, message.CloseBranchCount, message.MessageType));
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