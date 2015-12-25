namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    
    public static class BuilderConfigurationExtensions
    {
        public static RouteInspectorServerConfiguration ConfigureRouteInspectorServer(this BootstrapBuilderConfiguration config)
        {
            return new RouteInspectorServerConfiguration(config);
        }
    }
}