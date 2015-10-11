namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class PublishingEntity
    {
        readonly PublishingRoot root;

        public PublishingEntity(PublishingRoot root)
        {
            this.root = root;
        }

        protected void PublishEvent<TEvent>(TEvent @event)
        {
            root.PublishEvent(@event);
        }
    }
}