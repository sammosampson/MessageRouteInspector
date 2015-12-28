namespace SystemDot.Akka
{
    public abstract class AggregateEntity
    {
        protected AggregateRootActor Root { get; }

        protected AggregateEntity(AggregateRootActor root)
        {
            Root = root;
        }

        protected void Publish<TEvent>(TEvent @event)
        {
            Root.Publish(@event);
        }
    }
}