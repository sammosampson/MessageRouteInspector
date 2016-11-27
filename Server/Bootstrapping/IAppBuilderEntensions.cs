namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.MessageRouteInspector.Server.Web;
    using Owin;

    public static class IAppBuilderEntensions
    {
        public static IAppBuilder UseMessageRouteInspector(this IAppBuilder builder, GraphQlExecuter executer)
        {
            return builder
                .MapSignalR()
                .Use<GraphQLServerMiddleware>(executer);
        }
    }
}