using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LedgerLocal.IdentityServer.FullNode.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o1 => o1.Listen(IPAddress.Loopback, 4444, listenOptions =>
                {
                    Console.WriteLine(args[1]);
                    listenOptions.UseHttps(args[1], args[2]);
                }))   
            .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
    }
}
