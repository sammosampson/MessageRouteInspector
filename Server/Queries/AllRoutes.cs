namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class AllRoutes : IEnumerable<Route>
    {
        readonly Dictionary<string, Route> routes;

        public AllRoutes()
        {
            routes = new Dictionary<string, Route>();
        }

        public void AddRoute(string id, DateTime createdOn)
        {
            routes.Add(id, new Route
            {
                CreatedOn = createdOn, 
                Messages = new Message[0]
            });
        }

        public IEnumerator<Route> GetEnumerator()
        {
            return routes.Values.GetEnumerator();
        }

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