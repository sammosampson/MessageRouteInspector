namespace SystemDot.MessageRouteInspector.Server.Web.Bootstrapping
{
    using SystemDot.Bootstrapping;

    public static class BuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration ConfigureRouteInspectorWeb(this BootstrapBuilderConfiguration config)
        {
            return config.RegisterBuildAction(c => c.RegisterControllers());
        }
    }
}