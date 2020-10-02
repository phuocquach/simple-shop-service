using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mine.Commerce.Application.Products;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;
using Mine.Commerce.Domain.Core.Services.StorageService;

namespace Mine.Commerce.Application.Products.Queries
{
    public class GetImageByProductIdHandler : IRequestHandler<GetImageByProductId, string>
    {
        private readonly IStorageService _storageService;
        private readonly IQueryRepository<Product> _productRepository;
        public GetImageByProductIdHandler(IStorageService storageService,
                                            IQueryRepository<Product> productRepository)
        {
            _storageService = storageService;
            _productRepository = productRepository;
        }

        public async Task<string> Handle(GetImageByProductId request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.ProductId);
            var imageUrl = product.ProductImages.FirstOrDefault()?.StorageUrl;
            
            if (string.IsNullOrEmpty(imageUrl)){
                return imageUrl;
            }

            var content = await _storageService.DownloadFile(imageUrl);
            
            MemoryStream ms = new MemoryStream();
            content.CopyTo(ms);
            return String.Format("data:image/*;base64,{0}", Convert.ToBase64String(ms.ToArray()));
        }
    }
}