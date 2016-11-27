namespace SystemDot.MessageRouteInspector.Server.Web
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Owin;

    public class GraphQLServerMiddleware : OwinMiddleware
    {
        private readonly GraphQlExecuter executer;

        public GraphQLServerMiddleware(OwinMiddleware next, GraphQlExecuter executer)
            : base(next)
        {
            this.executer = executer;
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.ContentType != "application/json" && context.Request.ContentType != "application/graphql")
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;;
                return;
            }

            string result;

            try
            {
                string query = await context.Request.Body.ReadAsString();
                result = await executer.ExecuteQueryAsync(query);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            
            await context.Response.WriteAsync(result);
            await Next.Invoke(context);
        }
    }
}