using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Mine.Commerce.Api.StartupExtension;
using System;
using Microsoft.Extensions.Configuration;

namespace Mine.Commerce.Api.ServiceExtension
{
    public static class AddServicesExtension
    {
        public static void AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {
            var authUrl = configuration.GetValue<string>("Identity:Url");
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mine Commerce API",
                    Description = "APIs Definition"
                });
                c.OperationFilter<SwaggerFileOperationFilter>();
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"{authUrl}/connect/token", UriKind.Absolute),
                            AuthorizationUrl = new Uri($"{authUrl}/connect/authorize", UriKind.Absolute),
                            Scopes = new Dictionary<string, string> { { "api.minecommerce", "MineCommerce API" } }
                        },
                    },
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>{ "api.minecommerce" }
                    }
                });
            });
        }
    }
}