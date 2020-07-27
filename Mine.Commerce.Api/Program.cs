using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mine.Commerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) => 
            {
                // services.Configure<KestrelServerOptions>(
                //     context.Configuration.GetSection("Kestrel"));
            })
            .ConfigureWebHostDefaults(webBuilder =>
            { 
                webBuilder.ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5001, listenOptions =>
                    {
                        listenOptions.Protocols = HttpProtocols.Http2;
                        // listenOptions.UseHttps("Cert/Sd3540.pfx", 
                        //     "123");
                    });
                });
                webBuilder.UseStartup<Startup>();
            });
    }
}
