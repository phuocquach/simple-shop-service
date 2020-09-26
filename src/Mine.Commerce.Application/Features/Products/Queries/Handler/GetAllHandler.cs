using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;
using Mine.Commerce.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Products.Query
{
    public class GetAllHandler : BaseHandler, IRequestHandler<GetAllRequest, IEnumerable<ProductDto>>
    {
        private IQueryRepository<Product> _productRepository { get; set; }
        private readonly MineCommerceContext _dbContext;
        private IMapper _mapper {get; set;}
        public GetAllHandler(MineCommerceContext dbcontext, 
                            IQueryRepository<Product> productRepository,
                                    IMapper mapper )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllRequest request, CancellationToken cancellation)
        {
            return _mapper.Map<IEnumerable<ProductDto>>((await _productRepository.GetAll(cancellation)).items);
        }

        public async Task<ProductDto> Handle(GetById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDto>(await _productRepository.Get(request.Id));
        }

    }
}