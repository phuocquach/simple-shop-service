using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;

namespace Mine.Commerce.Application.Products.Command
{
    public class UpdateHandler : IRequestHandler<UpdateRequest, ProductDto>
    {
        private readonly ICommandRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateHandler(ICommandRepository<Product> productRepository, 
                                IMapper mapper,
                                IUnitOfWork unitOfWork )
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            
            await _productRepository.UpdateAsync(product);
            
            await _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(product);
        }
    }
}