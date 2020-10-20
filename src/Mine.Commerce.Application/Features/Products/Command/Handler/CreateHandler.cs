using AutoMapper;
using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
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
        private readonly IStorageService _storageService;
        public CreateHandler(ICommandRepository<Product> productRepository, 
                                IMapper mapper,
                                IStorageService storageService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _storageService = storageService;
        }
        public async Task<ProductDto> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            //TODO: refactor to let upload service decide where to store image
            var imageUrl = $"ProductImage/{request.ProductCode}/{Guid.NewGuid()}";
            await _storageService.UploadFile(request.ProductImage.OpenReadStream(), imageUrl);
            var product = request.Adapt<Product>();
            product.Id = Guid.NewGuid();
            product.ProductCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    CategoryId = request.Category,
                    ProductId = product.Id
                }
            };
            product.ProductImages = new List<ProductImage>
            {
                new ProductImage
                {
                    IsPrimary = true,
                    ProductId = product.Id,
                    Id = Guid.NewGuid(),
                    StorageUrl = imageUrl
                }
            };
            await _productRepository.AddAsync(product);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductDto>(product);
        }
    }
}