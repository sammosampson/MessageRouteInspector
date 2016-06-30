namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.Core;

    internal class CorrelationId : Equatable<CorrelationId>
    {
        private readonly string correlationId;

        private CorrelationId(string correlationId)
        {
            this.correlationId = correlationId;
        }

        public static CorrelationId Parse(string correlationId)
        {
            return new CorrelationId(correlationId);
        }

        public override bool Equals(CorrelationId other)
        {
            return other.correlationId == correlationId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return correlationId.GetHashCode();
            }
        }
    }
}