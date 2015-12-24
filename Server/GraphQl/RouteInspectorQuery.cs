namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using SystemDot.Core;
    using GraphQL.Types;

    public class RouteInspectorQuery : ObjectGraphType
    {
        public RouteInspectorQuery()
        {
            Field<App>("viewer", resolve: (obj) => obj.Source.As<RouteInspectorService>());
        }
    }
}