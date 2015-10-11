namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using System.Collections.Generic;
    using SystemDot.Domain.Events;

    public class MessageRouteLookup
    {
        readonly Dictionary<ProcessId, MessageRoute> currentRoutes;
        readonly IEventBus bus; 

        public MessageRouteLookup(IEventBus bus)
        {
            this.bus = bus;
            currentRoutes = new Dictionary<ProcessId, MessageRoute>();
        }

        public bool MessageRouteExists(string machine, int thread)
        {
            return currentRoutes.ContainsKey(new ProcessId(machine, thread));
        }

        public MessageRoute LookupMessageRoute(string machine, int thread)
        {            
            return currentRoutes[new ProcessId(machine, thread)];
        }

        public MessageRoute OpenRoute(string machine, int thread, DateTime createdOn)
        {
            var processId = new ProcessId(machine, thread);
            MessageRoute messageRoute = MessageRoute.Open(bus, processId, createdOn);
            currentRoutes.Add(processId, messageRoute);

            return messageRoute;
        }

        public void CloseRoute(string machine, int thread)
        {
            currentRoutes.Remove(new ProcessId(machine, thread));
        }
    }
}