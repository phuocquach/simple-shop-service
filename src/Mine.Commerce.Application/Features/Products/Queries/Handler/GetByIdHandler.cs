using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Products.Query
{
    public class GetByIdHandler : IRequestHandler<GetById, ProductDto>
    {
        private IQueryRepository<Product> _productRepository { get; set; }
        public GetByIdHandler(IQueryRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllRequest request, CancellationToken cancellation) 
            => (await _productRepository.GetAll(cancellation)).Adapt<IEnumerable<ProductDto>>();

        public async Task<ProductDto> Handle(GetById request, CancellationToken cancellationToken)
        {
            return (await _productRepository.Get(request.Id)).Adapt<ProductDto>();
        }
    }
}