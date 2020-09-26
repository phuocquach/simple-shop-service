using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mine.Commerce.Application.Features.Brands;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core.Handler;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.ImplementationRepository;
using System.Reflection;
using System.Linq;

namespace Mine.Commerce.Api.ServiceExtension
{
    public static class RegisterServiceExtension
    {
        public static void RegisterRepository(this IServiceCollection services, params Assembly[] assemblies)
        {            
            //services.AddScoped(typeof(IRequestHandler<,>), typeof(BaseHandler));
            // if (assemblies.Length == 0)
            // {
            //     assemblies = new[] {Assembly.GetCallingAssembly()};
            // }
            // var allPublicTypes = assemblies.SelectMany(x => x.GetExportedTypes()
            //     .Where(y => y.BaseType == typeof(BaseHandler))).ToHashSet();

            // foreach (var item in allPublicTypes)
            // {
            //     var implementedInteface = item.GetTypeInfo().ImplementedInterfaces.FirstOrDefault();
            //     //implementedInteface.MakeGenericType(implementedInteface.GetGenericArguments());
            //     services.Add(new ServiceDescriptor(implementedInteface.m, item, ServiceLifetime.Scoped ));
            // }
            services.AddScoped<ICommandRepository<Product>, ProductCommandRepository>();
            services.AddScoped<ICommandRepository<Category>, CategoryCommandRepository>();
            services.AddScoped<ICommandRepository<Brand>, BrandCommandRepository>();
            services.AddScoped<IQueryRepository<Product>, ProductQueryRepository>();
            services.AddScoped<IQueryRepository<Category>, CategoryQueryRepository>();
            services.AddScoped<IQueryRepository<Brand>, BrandQueryRepository>();

        }
    }
}