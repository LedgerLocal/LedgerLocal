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
        public static IConfigurationRoot MainConfig;

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {

            var a3 = new ConfigurationBuilder().AddCommandLine(args).Build();
            MainConfig = a3;

            return WebHost.CreateDefaultBuilder(args)
                 .UseKestrel(o1 => o1.Listen(IPAddress.Any, 2132, listenOptions =>
                 {
                     listenOptions.UseHttps(a3["pfxpath"], a3["pfxpass"]);
                 }))
             .UseConfiguration(a3)
             .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseIISIntegration()
                 .UseStartup<Startup>()
                 .Build();
        }
    }
}
