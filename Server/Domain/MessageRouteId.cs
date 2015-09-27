namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System;
    using SystemDot.Domain;

    public class MessageRouteId : MultiSiteId
    {
        public MessageRouteId() : this(Guid.NewGuid().ToString())
        {
        }

        public MessageRouteId(string id) : base(id , "")
        {
        }
    }
}