using Microsoft.Extensions.DependencyInjection;
using Mine.Commerce.Domain.Features.Carts;
using Mine.Commerce.Infrastructure.ImplementationServices;
using System;
using System.Linq;
using System.Reflection;

namespace Mine.Commerce.Api.ServiceExtension
{
    public static class RegisterServiceExtension
    {
        [Obsolete]
        public static void RegisterRepository(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }
            var allPublicTypes = assemblies.SelectMany(x => x.GetExportedTypes()
                .Where(y => !y.IsAbstract && y.IsClass && y.Name.EndsWith("Repository"))).ToHashSet();

            foreach (var item in allPublicTypes)
            {
                var implementedInteface = item.GetTypeInfo().ImplementedInterfaces.FirstOrDefault();
                services.Add(new ServiceDescriptor(implementedInteface, item, ServiceLifetime.Scoped));
            }
        }
        [Obsolete]
        public static void RegisterDomainServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }

            if (assemblies.Length == 0)
            {
                assemblies = new[] { Assembly.GetCallingAssembly() };
            }
            services.AddScoped<ICartServices, CartServices>();
            //TODO: register domain service by querie all and register
        }

        public static void RegisterServicesAsScoped(this IServiceCollection services, params Assembly[] assemblies)
        {
            var allPublicTypes = assemblies.SelectMany(x => x.GetExportedTypes()
                .Where(y => !y.IsAbstract && y.IsClass)).ToHashSet();
            foreach (var item in allPublicTypes)
            {
                var implementedInteface = item.GetTypeInfo().ImplementedInterfaces.FirstOrDefault();
                services.Add(new ServiceDescriptor(implementedInteface, item, ServiceLifetime.Scoped));
            }
        }
    }
}