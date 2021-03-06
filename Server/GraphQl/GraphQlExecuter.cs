namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Specifications.Steps;
    using GraphQL;
    using GraphQL.Http;
    
    public class GraphQlExecuter
    {
        private readonly DocumentExecuter executer;
        private readonly DocumentWriter writer;
        private readonly MessageLogger logger;

        public GraphQlExecuter(MessageLogger logger)
        {
            this.logger = logger;
            executer = new DocumentExecuter();
            writer = new DocumentWriter();
        }

        public async Task<string> ExecuteQueryAsync(string query)
        {
            query = query
                .Replace("{\"query\":\"", string.Empty)
                .Replace("\",\"variables\":{}}", string.Empty);

            ExecutionResult result = await executer.ExecuteAsync(new RouteInspectorSchema(), logger, query, null);
            return writer.Write(result);
        }
    }
}