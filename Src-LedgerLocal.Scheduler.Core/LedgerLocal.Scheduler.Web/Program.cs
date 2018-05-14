using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;

namespace Quartz.Web
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

        var a1 = new ConfigurationBuilder().AddCommandLine(args).Build();
            MainConfig = a1;

        return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o1 => o1.Listen(IPAddress.Any, 5544, listenOptions =>
                {
                }))
                .UseConfiguration(a1)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
        }
           
    }
}

