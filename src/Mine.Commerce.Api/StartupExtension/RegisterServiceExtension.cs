using Microsoft.Extensions.DependencyInjection;
using Mine.Commerce.Domain.Features.Carts;
using Mine.Commerce.Infrastructure.ImplementationServices;
using System.Linq;
using System.Reflection;

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

        public static void RegisterDomainServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
            {
                assemblies = new[] {Assembly.GetCallingAssembly()};
            }

            if (assemblies.Length == 0)
            {
                assemblies = new[] {Assembly.GetCallingAssembly()};
            }
            services.AddScoped<ICartServices, CartServices>();
            //TODO: register domain service by querie all and register
        }
    }
}