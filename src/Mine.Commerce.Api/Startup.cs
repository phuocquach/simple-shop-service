using IdentityServer4.AccessTokenValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mine.Commerce.Api.ServiceExtension;
using Mine.Commerce.Application.Products;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core.Services.StorageService;
using Mine.Commerce.Infrastructure.DBContext;
using Mine.Commerce.Infrastructure.Services.gRpc.ProductsService;
using Mine.Commerce.Infrastructure.Services.Storage;

namespace Mine.Commerce.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MineCommerceContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                     builder => { builder.MigrationsAssembly("Mine.Commerce.Api"); }
                );
            });
            services.AddSwaggerService(Configuration);
            services.AddCors(o => o.AddPolicy("AllowAllPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                // base-address of your identityserver
                options.Authority = Configuration.GetValue<string>("Identity:Url");
                // name of the API resource
                options.ApiName = "MineCommerceAPI";
                options.RequireHttpsMetadata = false;
                options.ApiSecret = "secret";
            });

            services.AddScoped<DbContext, MineCommerceContext>();
            services.AddMediatR(typeof(Startup), typeof(GetAllRequest), typeof(MineCommerceContext), typeof(Entity));
            services.RegisterRepository(typeof(Startup).Assembly, typeof(GetAllRequest).Assembly, typeof(MineCommerceContext).Assembly, typeof(Entity).Assembly);
            services.RegisterDomainServices(typeof(Startup).Assembly, typeof(GetAllRequest).Assembly, typeof(MineCommerceContext).Assembly, typeof(Entity).Assembly);
            services.AddScoped<IStorageService, AzureblobStorage>();
            services.AddGrpc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCertificateForwarding();
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var applicationDbContext = serviceScope.ServiceProvider.GetRequiredService<MineCommerceContext>();
                applicationDbContext.Database.Migrate();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.EnableFilter();
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mine.Commerce API V1");

            });

            app.UseRouting();
            app.UseCors("AllowAllPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<ProductsService>();
            });
        }
    }
}
