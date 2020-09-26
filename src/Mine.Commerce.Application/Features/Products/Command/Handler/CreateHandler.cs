using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;
using Mine.Commerce.Domain.Core.Services.StorageService;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Products.Command
{
    public class CreateHandler : IRequestHandler<CreateRequest, ProductDto>
    {
        private readonly ICommandRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        public CreateHandler(ICommandRepository<Product> productRepository, 
                                IMapper mapper,
                                IUnitOfWork unitOfWork,
                                IStorageService storageService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }
        public async Task<ProductDto> Handle(CreateRequest request, CancellationToken cancellationtoken)
        {
            var imageUrl = $"ProductImage/{request.ProductCode}/{Guid.NewGuid()}";

            await _storageService.UploadFile(request.ProductImage.OpenReadStream(), imageUrl);

            var product = Product.Create(request.Name, 
                request.Price, 
                request.InStock, 
                request.ProductCode, 
                new List<Guid>{request.Category}, 
                imageUrl, 
                request.BrandId,
                request.Description);
            
            await _productRepository.AddAsync(product);
            await _unitOfWork.Commit();

            return _mapper.Map<ProductDto>(product);
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