namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Queries;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Domain;

    public static class BuilderConfigurationExtensions
    {
        public static LimitRoutesToConfiguration ConfigureRouteInspectorServer(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterCommandHandlersFromAssemblyOf<LogCommandProcessingCommandHandler>())
                .RegisterBuildAction(c => c.RegisterQueryHandlersFromAssemblyOf<LogCommandProcessingCommandHandler>())
                .RegisterBuildAction(c => c.RegisterProjectionsFromAssemblyOf<LogCommandProcessingCommandHandler>());

            return new LimitRoutesToConfiguration(config);
        }
    }
}