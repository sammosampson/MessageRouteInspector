namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System.Linq;
    using GraphQL;
    using GraphQL.Types;

    public class App : ObjectGraphType
    {
        public App()
        {
            Field<ListGraphType<MessageRoute>>("routes", resolve: obj => obj.Source.As<RouteInspectorService>().GetRoutesAsync());
            Field<MessageRoute>(
                "route", 
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                }),
                resolve: ctx => ctx.Source.As<RouteInspectorService>().GetRouteAsync(ctx.Arguments.Values.First().ToString()));
        }
    }
}