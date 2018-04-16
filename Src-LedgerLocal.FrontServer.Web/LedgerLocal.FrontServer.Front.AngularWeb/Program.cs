using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LedgerLocal.FrontServer.Front.AngularWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o1 => o1.Listen(IPAddress.Any, 2132, listenOptions =>
                {
                    var a1 = new ConfigurationBuilder().AddCommandLine(args).Build();

                    listenOptions.UseHttps(a1["pfxpath"], a1["pfxpass"]);
                }))
            .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
