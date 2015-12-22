
namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Owin.Hosting;
    using Owin;

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8081/", builder => builder.Use<GraphQLServerMiddleware>(Bootstrapper.Bootstrap(10))))
            {
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
