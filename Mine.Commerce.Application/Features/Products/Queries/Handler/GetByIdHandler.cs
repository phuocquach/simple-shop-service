using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Application.Products;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;

namespace Mine.Commerce.Application.Products.Query
{
    public class GetByIdHandler : IRequestHandler<GetById, ProductDto>
    {
        private IQueryRepository<Product> _productRepository { get; set; }
        private IMapper _mapper {get; set;}
        public GetByIdHandler(IQueryRepository<Product> productRepository, 
                            IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllRequest request, CancellationToken cancellation)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll(cancellation));
        }

        public async Task<ProductDto> Handle(GetById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDto>(await _productRepository.Get(request.Id));
        }
    }
}