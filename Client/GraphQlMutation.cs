namespace SystemDot.MessageRouteInspector.Client
{
    public class GraphQlMutation
    {
        public static GraphQlMutation Named(string mutationName)
        {
            return new GraphQlMutation(mutationName);
        }

        private readonly string name;
        private readonly GraphQlArguments arguments;

        private GraphQlMutation(string name)
            : this(name, GraphQlArguments.Empty)
        {
        }

        private GraphQlMutation(string name, GraphQlArguments arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public override string ToString()
        {
            return string.Format("{{\"query\":\"mutation {0} {{ {0}({1}) }}\",\"variables\":{{}}}}", name, arguments);
        }

        public GraphQlMutation WithArgument<TValue>(string argumentName, TValue argumentValue)
        {
            return new GraphQlMutation(name, arguments.AddArgument(argumentName, argumentValue));
        }
    }
}