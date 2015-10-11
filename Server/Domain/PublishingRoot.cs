namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.Domain.Events;

    public abstract class PublishingRoot
    {
        readonly IEventBus bus;

        protected PublishingRoot(IEventBus bus)
        {
            this.bus = bus;
        }

        protected internal void PublishEvent<TEvent>(TEvent @event)
        {
            bus.PublishEvent(@event);
        }
    }
}