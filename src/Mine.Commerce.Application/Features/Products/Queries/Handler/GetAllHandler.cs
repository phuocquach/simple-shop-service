using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Products.Query
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<ProductDto>>
    {
        private IQueryRepository<Product> _productRepository { get; set; }
        public GetAllHandler(IQueryRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllRequest request, CancellationToken cancellation)
        {
            return (await _productRepository.GetAll(cancellation)).items.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<ProductDto> Handle(GetById request, CancellationToken cancellationToken)
        {
            return (await _productRepository.Get(request.Id)).Adapt<ProductDto>();
        }

    }
}