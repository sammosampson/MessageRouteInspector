namespace SystemDot.MessageRouteInspector.Server.Web
{
    using System.Web.Http;
    using SystemDot.Bootstrapping;
    using SystemDot.Domain;
    using SystemDot.Domain.Bootstrapping;
    using SystemDot.Environment;
    using SystemDot.EventSourcing.Bootstrapping;
    using SystemDot.EventSourcing.InMemory.Bootstrapping;
    using SystemDot.EventSourcing.Synchronisation.Server.Bootstrapping;
    using SystemDot.Ioc;
    using SystemDot.MessageRouteInspector.Server.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Web.Bootstrapping;
    using SystemDot.Web.WebApi.Caching;
    using SystemDot.Web.WebApi.Ioc;
    using SystemDot.Web.WebApi.ModelState;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            IIocContainer iocContainer = new IocContainer();

            Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .UseDomain().WithSimpleMessaging()
                .ConfigureRouteInspectorServer().WithRouteLimitOf(10)
                .ConfigureRouteInspectorWeb()
                .UseEventSourcing().PersistToMemory()
                .Initialise();

            var configuration = new HttpConfiguration
            {
                DependencyResolver = new SystemDotDependencyResolver(iocContainer)
            };

            configuration.MapHttpAttributeRoutes();
            configuration.Filters.Add(new ModelStateContextFilterAttribute());
            configuration.Filters.Add(new NoCacheFilterAttribute());

            configuration.MapSynchronisationRoutes();

             configuration.Routes.MapHttpRoute(
                  "Default",
                  "{controller}/{id}",
                  new { id = RouteParameter.Optional });
            
            appBuilder.UseWebApi(configuration);
        }
    }
}