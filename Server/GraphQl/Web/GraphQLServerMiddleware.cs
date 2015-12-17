namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using System.Threading.Tasks;
    using Microsoft.Owin;


    public class GraphQLServerMiddleware : OwinMiddleware
    {
        private readonly GraphQlExecuter executer;

        public GraphQLServerMiddleware(OwinMiddleware next)
            : base(next)
        {
            executer = Bootstrapper.Bootstrap(10);
        }

        public override async Task Invoke(IOwinContext context)
        {
            if(context.Request.ContentType != "application/graphql")
            {
                context.Response.StatusCode = 415;
                return;
            }

            string query = await context.Request.Body.ReadAsString();
            string result = await executer.ExecuteQueryAsync(query);
            await context.Response.WriteAsync(result);
            await Next.Invoke(context);
        }
    }
}