namespace SystemDot.MessageRouteInspector.Client.Bootstrapping
{
    using SystemDot.Bootstrapping;

    public static class BootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration SetupMessageRouteInspectorClient(this BootstrapBuilderConfiguration config)
        {
            return config
                .RegisterBuildAction(c => c.RegisterInstance(() => GraphQlServerUri.Parse("http://localhost:8081")))
                .RegisterBuildAction(c => c.RegisterInstance<IGraphQlServer, GraphQlServer>())
                .RegisterBuildAction(c => c.RegisterInstance<IMessageLoggingClient, MessageLoggingClient>());
        }
    }
}
