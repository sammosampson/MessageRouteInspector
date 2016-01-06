namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System.Threading.Tasks;
    using GraphQL;
    using GraphQL.Http;
    
    public class GraphQlExecuter
    {
        private readonly DocumentExecuter executer;
        private readonly DocumentWriter writer;
        private readonly RouteInspectorService logger;

        public GraphQlExecuter(RouteInspectorService logger)
        {
            this.logger = logger;
            executer = new DocumentExecuter();
            writer = new DocumentWriter();
        }

        public async Task<string> ExecuteQueryAsync(string query)
        {
            query = query
                .Replace("{\"query\":\"", string.Empty)
                .Replace("\",\"variables\":{}}", string.Empty)
                .Replace("\\\"", "\"");

            ExecutionResult result = await executer.ExecuteAsync(new RouteInspectorSchema(), logger, query, null);
            return writer.Write(result);
        }
    }
}