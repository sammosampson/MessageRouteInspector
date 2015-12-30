
namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using System;
    using Microsoft.Owin.Hosting;
    using Owin;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8081/", builder => builder.Use<GraphQLServerMiddleware>(InspectorGraphQlExecuterBuilder.Build(10))))
            {
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
