namespace SystemDot.MessageRouteInspector.Client
{
    using System.Text;

    public class GraphQlArgument
    {
        private readonly string name;
        private readonly object value;

        public GraphQlArgument(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}: ", name);
            if (value is string)
            {
                builder.AppendFormat("\"{0}\"", value);    
            }
            else
            {
                builder.AppendFormat("{0}", value);
            }
            return builder.ToString();
        }
    }
}