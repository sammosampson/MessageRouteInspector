namespace SystemDot.MessageRouteInspector.Client
{
    using System;

    public class GraphQlServerUri
    {
        public static GraphQlServerUri Parse(string url)
        {
            return new GraphQlServerUri(url);
        }

        public static implicit operator Uri(GraphQlServerUri from)
        {
            return new Uri(from.url);
        }

        private readonly string url;

        private GraphQlServerUri(string url)
        {
            this.url = url;
        }
    }
}