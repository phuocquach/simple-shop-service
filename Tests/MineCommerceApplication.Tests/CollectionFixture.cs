using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Mine.Commerce.Api;
using Mine.Commerce.Api.gRpc.Mapper;
using Mine.Commerce.Api.ServiceExtension;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Services.StorageService;
using Mine.Commerce.Infrastructure.DBContext;
using Mine.Commerce.Infrastructure.Services.gRpc.ProductsService;
using Mine.Commerce.Infrastructure.Services.Storage;
using MineCommerceApplication.Tests.Helper;
using MineCommerceApplication.Tests.Middlewares;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MineCommerceApplication.Tests
{
    public class CollectionFixture : WebApplicationFactory<Startup>
    {
        public readonly Mock<IQueryRepository<Product>> MockQueryProduct = new Mock<IQueryRepository<Product>>();
        public readonly Mock<IQueryRepository<Category>> MockQueryCategory = new Mock<IQueryRepository<Category>>();
        public readonly Mock<IQueryRepository<Brand>> MockQueryBrand = new Mock<IQueryRepository<Brand>>();
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
                
                var mockContext = new Mock<DbContext>();
                mockContext.Setup(x => x.SaveChanges())
                .Returns (0);
                services.AddScoped<DbContext>(x => mockContext.Object);
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddAutoMapper(typeof(Startup).Assembly, typeof(ProductProfile).Assembly);
                services.AddMediatR(typeof(Startup));
                services.RegisterHanlder();
                //services.RegisterRepository();
                services.AddScoped<IStorageService, LocalStorage>();
                services.AddGrpc();

            });

            builder.Configure(app => Configure(app));
        }

        private void RegisterRepository(IServiceCollection services)
        {
         
            //services.AddScoped<ICommandRepository<Product>, ProductCommandRepository>();
            //services.AddScoped<ICommandRepository<Category>, CategoryCommandRepository>();
            //services.AddScoped<ICommandRepository<Brand>, BrandCommandRepository>();
            var result = (new List<Brand>
            {
                Brand.Create("AAAA", "USA")
            }, 1);
            MockQueryBrand.Setup(x => x.GetAll(It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);

            services.AddScoped<IQueryRepository<Product>>(x => MockQueryProduct.Object);
            services.AddScoped<IQueryRepository<Category>>(x => MockQueryCategory.Object);
            services.AddScoped<IQueryRepository<Brand>>(x => MockQueryBrand.Object);

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
