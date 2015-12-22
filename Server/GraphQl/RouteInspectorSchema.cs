namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using GraphQL.Types;

    public class RouteInspectorSchema : Schema
    {
        public RouteInspectorSchema()
        {
            Query = new RouteInspectorQuery();
            Mutation = new RouteInspectorMutation();
        }
    }
}