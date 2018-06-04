using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LedgerLocal.IdentityServer.FullNode.Web
{
    public class Program
    {

        public static IConfigurationRoot MainConfig;

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var a1 = new ConfigurationBuilder().AddCommandLine(args).Build();
            MainConfig = a1;

            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o1 => o1.Listen(IPAddress.Loopback, 4444, listenOptions =>
                {
                    listenOptions.UseHttps(a1["pfxpath"], a1["pfxpass"]);
                }))
            .UseConfiguration(a1)
            .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
        }

    }
}
