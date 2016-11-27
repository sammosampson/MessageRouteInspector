namespace SystemDot.MessageRouteInspector.Server.Web
{
    using GraphQL.Types;

    internal class RouteInspectorSchema : Schema
    {
        public RouteInspectorSchema()
        {
            Query = new RouteInspectorQuery();
            Mutation = new RouteInspectorMutation();
        }
    }
}