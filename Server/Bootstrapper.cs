namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Bootstrapping;
    using SystemDot.Domain;
    using SystemDot.Domain.Bootstrapping;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Queries;
    using SystemDot.Environment;
    using SystemDot.EventSourcing.Bootstrapping;
    using SystemDot.EventSourcing.InMemory.Bootstrapping;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.Ioc;
    using SystemDot.MessageRouteInspector.Server.Domain;

    public static class Bootstrapper
    {
        public static async Task<MessageLoggingClient> InitialiseAsync()
        {
            var iocContainer = new IocContainer();

            await Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .UseDomain()
                    .WithSimpleMessaging()
                    .RegisterBuildAction(c => c.RegisterCommandHandlersFromAssemblyOf<LogMessageProcessingCommandHandler>())
                    .RegisterBuildAction(c => c.RegisterQueryHandlersFromAssemblyOf<LogMessageProcessingCommandHandler>())
                    .RegisterBuildAction(c => c.RegisterProjectionsFromAssemblyOf<LogMessageProcessingCommandHandler>())
                .UseEventSourcing().PersistToMemory()
                .InitialiseAsync();

            return iocContainer.Resolve<MessageLoggingClient>();
        }
    }
}