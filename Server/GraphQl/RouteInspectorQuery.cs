namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using SystemDot.Core;
    using SystemDot.MessageRouteInspector.Server.Specifications.Steps;
    using GraphQL.Types;

    public class RouteInspectorQuery : ObjectGraphType
    {
        public RouteInspectorQuery()
        {
            Field<App>("viewer", resolve: (obj) => obj.Source.As<MessageLogger>());
        }
    }
}