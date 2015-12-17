
namespace SystemDot.MessageRouteInspector.Server.GraphQl.Web
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Owin.Hosting;

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
}
