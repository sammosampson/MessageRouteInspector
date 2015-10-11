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
    using SystemDot.MessageRouteInspector.Server.Domain.Limits;

    public class LimitRoutesToConfiguration
    {
        readonly int routeLimit;

        public LimitRoutesToConfiguration(int routeLimit)
        {
            this.routeLimit = routeLimit;
        }

        public async Task<MessageLogger> InitialiseAsync()
        {
            var iocContainer = new IocContainer();

            // useful for attaching to the node process and debugging..
            //await Task.Delay(TimeSpan.FromSeconds(60));

            await Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .UseDomain()
                .WithSimpleMessaging()
                .RegisterBuildAction(c => c.RegisterInstance(() => new RouteLimit(routeLimit)))
                .RegisterBuildAction(c => c.RegisterCommandHandlersFromAssemblyOf<LogMessageProcessingCommandHandler>())
                .RegisterBuildAction(c => c.RegisterQueryHandlersFromAssemblyOf<LogMessageProcessingCommandHandler>())
                .RegisterBuildAction(c => c.RegisterProjectionsFromAssemblyOf<LogMessageProcessingCommandHandler>())
                .UseEventSourcing().PersistToMemory()
                .InitialiseAsync();

            return iocContainer.Resolve<MessageLogger>();
        }
    }
}