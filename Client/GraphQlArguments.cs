namespace SystemDot.MessageRouteInspector.Client
{
    using System.Collections.Immutable;
    using System.Text;

    public class GraphQlArguments
    {
        private readonly ImmutableList<GraphQlArgument> inner;

        private GraphQlArguments() : this(ImmutableList<GraphQlArgument>.Empty)
        {
        }

        private GraphQlArguments(ImmutableList<GraphQlArgument> inner)
        {
            this.inner = inner;
        }

        public GraphQlArguments AddArgument<TValue>(string name, TValue value)
        {
            return new GraphQlArguments(inner.Add(new GraphQlArgument(name, value)));       
        }

        public static GraphQlArguments Empty { get { return new GraphQlArguments(); } }

        public override string ToString()
        {
            bool isFirst = true;
            StringBuilder builder = new StringBuilder();
            
            foreach (GraphQlArgument arg in inner)
            {
                if (!isFirst) builder.Append(", ");
                isFirst = false;
                builder.Append(arg);
            }

            return builder.ToString();
        }
    }
}