using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;

namespace Mine.Commerce.Application.Products.Command
{
    public class UpdateHandler : IRequestHandler<UpdateRequest, ProductDto>
    {
        private readonly ICommandRepository<Product> _productRepository;
        public UpdateHandler(ICommandRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            
            await _productRepository.UpdateAsync(product);
            
            return product.Adapt<ProductDto>();
        }
    }
}