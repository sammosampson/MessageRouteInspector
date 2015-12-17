namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<GraphQLServerMiddleware>();
        }
    }
}