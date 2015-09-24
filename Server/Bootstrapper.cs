namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Bootstrapping;
    using SystemDot.Domain;
    using SystemDot.Domain.Bootstrapping;
    using SystemDot.Domain.Commands;
    using SystemDot.Environment;
    using SystemDot.EventSourcing.Bootstrapping;
    using SystemDot.EventSourcing.InMemory.Bootstrapping;
    using SystemDot.Ioc;

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
                .UseEventSourcing().PersistToMemory()
                .InitialiseAsync();

            return iocContainer.Resolve<MessageLoggingClient>();
        }
    }
}