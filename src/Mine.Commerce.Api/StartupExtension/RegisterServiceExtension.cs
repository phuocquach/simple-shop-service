using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mine.Commerce.Application.Features.Brands;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core.Handler;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.ImplementationRepository;

namespace Mine.Commerce.Api.ServiceExtension
{
    public static class RegisterServiceExtension
    {
        public static void RegisterHanlder(this IServiceCollection services)
        {
            //RegisterQueryhandler(services);
            //ReqgisterCommandHandler(services);
            services.AddScoped(typeof(IRequestHandler<,>), typeof(BaseHandler));
        }
        private static void RegisterQueryhandler(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<Application.Categories.GetByIdRequest, Application.Categories.CategoryDto>, Application.Categories.Queries.Handler.RequestHandler>(); 
            services.AddScoped<IRequestHandler<Application.Categories.GetListRequest, IEnumerable<Application.Categories.CategoryDto>>, Application.Categories.Queries.Handler.RequestHandler>(); 
            services.AddScoped<IRequestHandler<Application.Products.GetAllRequest, IEnumerable<Application.Products.ProductDto>>, Application.Products.Query.GetAllHandler>(); 
            services.AddScoped<IRequestHandler<Application.Brands.GetAllRequest, IEnumerable<BrandDto>>, Application.Brands.Queries.GetAllHandler>(); 
            services.AddScoped<IRequestHandler<Application.Products.GetImageByProductId, string>, Application.Products.Queries.GetImageByProductIdHandler>(); 
        }

        private static void ReqgisterCommandHandler(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<Application.Categories.CreateRequest, System.Guid>, Application.Categories.Commands.Handler.CreateHandler>(); 
            services.AddScoped<IRequestHandler<Application.Categories.UpdateRequest, Application.Categories.CategoryDto>, Application.Categories.Commands.Handler.UpdateHandler>(); 
            services.AddScoped<IRequestHandler<Application.Categories.DeleteRequest, Unit>, Application.Categories.Commands.Handler.DeleteHandler>(); 
            services.AddScoped<IRequestHandler<Application.Products.CreateRequest, Application.Products.ProductDto>, Application.Products.Command.CreateHandler>(); 
            services.AddScoped<IRequestHandler<Application.Products.Command.UpdateRequest, Application.Products.ProductDto>, Application.Products.Command.UpdateHandler>();
            services.AddScoped<IRequestHandler<Application.Products.Command.DeleteRequest, Unit>, Application.Products.Command.Handler.DeleteHandler>();
            services.AddScoped<IRequestHandler<Application.Brands.CreateRequest, Guid>, Application.Brands.CreateHandler>(); 
        }
        public static void RegisterRepository(this IServiceCollection services)
        {            
            services.AddScoped<ICommandRepository<Product>, ProductCommandRepository>();
            services.AddScoped<ICommandRepository<Category>, CategoryCommandRepository>();
            services.AddScoped<ICommandRepository<Brand>, BrandCommandRepository>();

            services.AddScoped<IQueryRepository<Product>, ProductQueryRepository>();
            services.AddScoped<IQueryRepository<Category>, CategoryQueryRepository>();
            services.AddScoped<IQueryRepository<Brand>, BrandQueryRepository>();

        }
    }
}