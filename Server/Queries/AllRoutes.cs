namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class AllRoutes : IEnumerable<Route>
    {
        readonly Dictionary<string, Route> routes;

        public AllRoutes()
        {
            routes = new Dictionary<string, Route>();
        }

        public bool ContainsRoute(string routeId)
        {
            return routes.ContainsKey(routeId);
        }

        public void AddRoute(string id, DateTime createdOn)
        {
            routes.Add(id, new Route
            {
                Id = id,
                CreatedOn = createdOn, 
                Messages = new Message[0]
            });
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

        public Route this[string routeId]
        {
            get { return routes[routeId]; }
        }
    }
} 