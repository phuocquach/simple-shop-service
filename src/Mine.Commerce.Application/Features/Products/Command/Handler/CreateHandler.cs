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
        private readonly IStorageService _storageService;
        public CreateHandler(ICommandRepository<Product> productRepository,
                                IStorageService storageService)
        {
            _productRepository = productRepository;
            _storageService = storageService;
        }
        public async Task<ProductDto> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            //TODO: refactor to let upload service decide where to store image
            var imageUrl = $"ProductImage/{request.ProductCode}/{Guid.NewGuid()}";
            await _storageService.UploadFile(request.ProductImage.OpenReadStream(), imageUrl);
            var product = request.Adapt<Product>();
            product.Guid = Guid.NewGuid();

            product.ProductCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    CategoryId = request.Category,
                    ProductId = product.Guid
                }
            };
            product.ProductImages = new List<ProductImage>
            {
                new ProductImage
                {
                    IsPrimary = true,
                    ProductId = product.Guid,
                    Id = Guid.NewGuid(),
                    StorageUrl = imageUrl
                }
            };
            await _productRepository.AddAsync(product);

            return product.Adapt<ProductDto>();
        }

        public async Task<ProductDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await _productRepository.UpdateAsync(product);
            return product.Adapt<ProductDto>();
        }
    }
}