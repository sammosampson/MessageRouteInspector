namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System.Linq;
    using SystemDot.MessageRouteInspector.Server.Specifications.Steps;
    using GraphQL;
    using GraphQL.Types;

    public class App : ObjectGraphType
    {
        public App()
        {
            Field<ListGraphType<MessageRoute>>("routes", resolve: obj => obj.Source.As<MessageLogger>().GetRoutesAsync());
            Field<MessageRoute>(
                "route", 
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                }),
                resolve: ctx => ctx.Source.As<MessageLogger>().GetRouteAsync(ctx.Arguments.Values.First().ToString()));
        }
    }
}