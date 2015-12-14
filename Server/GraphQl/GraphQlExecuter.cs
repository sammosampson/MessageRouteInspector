namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using GraphQL;
    using GraphQL.Http;
    using GraphQL.Types;

    public class GraphQlExecuter
    {
        private readonly DocumentExecuter executer;
        private readonly DocumentWriter writer;

        public GraphQlExecuter()
        {
            executer = new DocumentExecuter();
            writer = new DocumentWriter();
        }

        public async Task<string> ExecuteQueryAsync(string query)
        {
            
            ExecutionResult result = await executer.ExecuteAsync(new RouteInspectorSchema(), new object(), query, null);
            return writer.Write(result);
        }
    }

    public class RouteInspectorSchema : Schema
    {
        public RouteInspectorSchema()
        {
            Query = new RouteInspectorQuery();
        }
    }

    public class RouteInspectorQuery : ObjectGraphType
    {
        public RouteInspectorQuery()
        {
            Field<AppType>("App", resolve: (obj) => new object());
        }
    }

    public class AppType : ObjectGraphType
    {
        public AppType()
        {
            Field<ListGraphType<RouteType>>("Routes", resolve: (obj) => new List<Route>());
        }
    }

    public class RouteType : ObjectGraphType
    {
    }
}