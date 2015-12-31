namespace SystemDot.MessageRouteInspector.Client.Bootstrapping
{
    using SystemDot.Bootstrapping;

    public static class BootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration SetupMessageRouteInspectorClient(this BootstrapBuilderConfiguration config, string serverUrl)
        {
            return config
                .RegisterBuildAction(c => c.RegisterInstance(() => GraphQlServerUri.Parse(serverUrl)))
                .RegisterBuildAction(c => c.RegisterInstance<IGraphQlServer, GraphQlServer>())
                .RegisterBuildAction(c => c.RegisterInstance<IMessageLoggingClient, MessageLoggingClient>());
        }
    }
}
