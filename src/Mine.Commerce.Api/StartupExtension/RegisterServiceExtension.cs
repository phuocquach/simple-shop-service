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
            if (assemblies.Length == 0)
            {
                assemblies = new[] {Assembly.GetCallingAssembly()};
            }
            var allPublicTypes = assemblies.SelectMany(x => x.GetExportedTypes()
                .Where(y => !y.IsAbstract && y.IsClass && y.Name.EndsWith("Repository"))).ToHashSet();

            foreach (var item in allPublicTypes)
            {
                var implementedInteface = item.GetTypeInfo().ImplementedInterfaces.FirstOrDefault();
                services.Add(new ServiceDescriptor(implementedInteface, item, ServiceLifetime.Scoped ));
            }
        }
    }
}