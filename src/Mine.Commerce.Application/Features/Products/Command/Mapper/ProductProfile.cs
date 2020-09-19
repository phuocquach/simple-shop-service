using AutoMapper;
using Mine.Commerce.Domain;

namespace Mine.Commerce.Application.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Command.CreateRequest, Product>();
            CreateMap<Command.UpdateRequest, Product>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        }
    }
}