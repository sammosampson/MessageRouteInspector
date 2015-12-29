using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using SystemDot.MessageRouteInspector.Server.Messages;
using SystemDot.MessageRouteInspector.Server.Queries.Messages;

namespace SystemDot.MessageRouteInspector.Server.Queries
{
    internal class RouteCollection : IEnumerable<Route>
    {
        ImmutableDictionary<string, Route> routes;

        public RouteCollection()
        {
            routes = ImmutableDictionary<string, Route>.Empty;
            routes.Add(Route.Empty.Id, Route.Empty);
        }

        public void AddRoute(string id, DateTime createdOn, string machineName)
        {
            routes = routes.Add(id, new Route(
                id,
                null,
                new Message[0],
                createdOn.ToJavaString(),
                machineName));
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