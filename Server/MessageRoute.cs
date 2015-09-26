namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using SystemDot.EventSourcing.Aggregation;

    public class MessageRoute : AggregateRoot
    {
        MessageProcessingLogged currentMessage;

        public void StartMessage(string message, DateTime createdOn)
        {
            AddEvent(new MessageProcessingLogged { MessageName = message, CreatedOn = createdOn });
        }

        void ApplyEvent(MessageProcessingLogged @event)
        {
            currentMessage = @event;
        }

        public void CompleteMessage()
        {
            AddEvent(new MessageProcessedLogged { MessageName = currentMessage.MessageName, CreatedOn = currentMessage.CreatedOn });
        }
    }
}