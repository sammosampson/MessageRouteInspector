
namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Microsoft.Owin.Hosting;
    using Owin;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:5000/"))
            {
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class GraphQLServerMiddleware : OwinMiddleware
    {
        private GraphQlExecuter executer;

        public GraphQLServerMiddleware(OwinMiddleware next)
            : base(next)
        {
            executer = Bootstrapper.Bootstrap(10);
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Request.Body.
            Console.WriteLine("Begin Request");
            await Next.Invoke(context);
            Console.WriteLine("End Request");
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<GraphQLServerMiddleware>();
        }
    }
}
