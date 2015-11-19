namespace SystemDot.MessageRouteInspector.Server.Web.Bootstrapping
{
    using System.Web.Http.Controllers;
    using SystemDot.Ioc;
    using SystemDot.MessageRouteInspector.Server.Web.Logging;

    public static class IocContainerExtensions
    {
        public static void RegisterControllers(this IIocContainer container)
        {
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<LogCommandProcessingController>()
                .ThatImplementType<IHttpController>()
                .ByClass(DependencyLifecycle.InstancePerDependency);
        }
    }
}