namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    
    public static class BuilderConfigurationExtensions
    {
        public static LimitRoutesToConfiguration ConfigureRouteInspectorServer(this BootstrapBuilderConfiguration config)
        {
            return new LimitRoutesToConfiguration(config);
        }
    }
}