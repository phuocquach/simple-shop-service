using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mine.Commerce.Api;
using Mine.Commerce.Infrastructure.Services.gRpc.ProductsService;
using MineCommerceApplication.Tests.Helper;
using MineCommerceApplication.Tests.Middlewares;
using System.IO;

namespace MineCommerceApplication.Tests
{
    public class CollectionFixture : WebApplicationFactory<Startup>
    {
        public CollectionFixture()
        {
            
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                var projectDir = Directory.GetCurrentDirectory();
                var configPath = Path.Combine(projectDir, "appsettings.test.json");

                config.AddJsonFile(configPath);
                config.AddEnvironmentVariables();
            });

            builder.ConfigureServices(services =>
            {
                services.AddMvc()
                .AddApplicationPart(typeof(Startup).Assembly);

                services.AddAuthentication("Test")
               .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                   "Test", options => { });
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Test";
                    options.DefaultChallengeScheme = "Test";
                });
            });

            builder.Configure(app => Configure(app));
        }

        private void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();

            app.UseCors("AllowAllPolicy");

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseMiddleware<AddTestAuthenticationMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller}/{action}/{id?}");
                endpoints.MapFallbackToController("{area:exists}/Home/Error/{errorId?}", "Home", "Error");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapGrpcService<ProductsService>();
            });
        }
    }
}
