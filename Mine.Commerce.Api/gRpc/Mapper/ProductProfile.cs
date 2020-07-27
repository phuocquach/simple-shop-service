using AutoMapper;
using Mine.Commerce.Application.Products;
using Mine.Commerce.V1;

namespace Mine.Commerce.Api.gRpc.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile(){
            CreateMap<ProductDto, ProductResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            CreateMap<Application.Features.Brands.BrandDto, BrandResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            CreateMap<Application.Categories.CategoryDto, CategoryResponse>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}