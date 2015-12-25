using SystemDot.Bootstrapping;
using SystemDot.Environment;
using SystemDot.Ioc;
using SystemDot.MessageRouteInspector.Server.Bootstrapping;

namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    public static class Bootstrapper
    {
        public static GraphQlExecuter Bootstrap(int limitOfStoredRoutes)
        {
            var iocContainer = new IocContainer();

            SystemDot.Bootstrapping.Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .ConfigureRouteInspectorServer().WithRouteLimitOf(limitOfStoredRoutes)
                .Initialise();

            return iocContainer.Resolve<GraphQlExecuter>();
        }
    }
}