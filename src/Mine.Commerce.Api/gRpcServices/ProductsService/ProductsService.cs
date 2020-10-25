using Grpc.Core;
using Mapster;
using MediatR;
using Mine.Commerce.Application.Products;
using Mine.Commerce.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.Services.gRpc.ProductsService
{
    public class ProductsService : Products.ProductsBase
    {
        private readonly IMediator _mediator;
        public ProductsService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async override Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(request.Adapt<CreateRequest>());
            return result.Adapt<CreateOrderResponse>();

        }
        public async override Task<GetOrderResponse> GetOrder(GetOrderRequest request, ServerCallContext context) 
        {
            return new GetOrderResponse();
            //var result = await _mediator.Send(request.Adapt<CreateRequest>());
            //return result.Adapt<CreateOrderResponse>();
        }
 
        public async override Task<GetAllBrandsResponse> GetAllBrands(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            var result = await _mediator.Send(new Application.Brands.GetAllRequest());
            var response = new GetAllBrandsResponse
            {
                StatusCode = 0,
                Message = string.Empty,
                ResponseData = new GetAllBrandsResponse.Types.ResponseData
                {
                    ListBrand = 
                    {
                        result.Adapt<IEnumerable<BrandResponse>>()
                    }
                }
            };
            return response;
        }
        public async override Task<GetAllCategoriesResponse> GetAllCategories(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            var result = await _mediator.Send(new Application.Categories.GetListRequest());
            var response = new GetAllCategoriesResponse
            {
                StatusCode = 0,
                Message = string.Empty,
                ResponseData = new GetAllCategoriesResponse.Types.ResponseData
                {
                    ListCategory  = 
                    {
                        result.Adapt<IEnumerable<CategoryResponse>>()
                    }
                }
            };

            return response;
        }


        public async override Task<GetProductResponse> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            var result =  await _mediator.Send(new GetById 
            {
                Id = Guid.Parse(request.Id)
            });

            var response = new GetProductResponse
            {
                StatusCode = 0,
                Message = string.Empty,
                ResponseData = new GetProductResponse.Types.ResponseData
                {
                    Product = result.Adapt<ProductResponse>()
                }
            };

            return response;
        }
        public async override Task<GetProductListResponse> GetProductList(GetProductListRequest request, ServerCallContext context)
        {
            var result =  (await _mediator.Send(new GetAllRequest())).ToList();
            var listProduct = await GetProductResponses(result).ToListAsync();
            var response = new GetProductListResponse{
                StatusCode = 0,
                Message = string.Empty,
                ResponseData = new GetProductListResponse.Types.ResponseData
                {
                    ListProduct = 
                    {
                        listProduct
                    }
                }

            };

            return response;
        }

        private async IAsyncEnumerable<ProductResponse> GetProductResponses(IEnumerable<ProductDto> result)
        {
            foreach(var x in result){
                yield return new ProductResponse
                { 
                    Name = x.Name,
                    Id = x.Id.ToString(),
                    Description = (await _mediator.Send(new GetImageByProductId
                    {
                        ProductId = x.Id
                    })),
                    InStock = x.InStock,
                    IsActive = x.IsActive,
                    Price = x.Price,
                    ProductCode = x.ProductCode,
                    
                    Brand = new BrandResponse
                    {
                        Id = x.BrandId.ToString()
                    },
                    Category = new CategoryResponse
                    {
                        Id =x.Category.ToString()
                    }
                };
            }
        }
    }
}