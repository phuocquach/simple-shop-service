using AutoMapper;
using Mine.Commerce.Domain;

namespace Mine.Commerce.Application.Features.Brands
{
    public class BrandProfile: Profile
    {
        public BrandProfile(){
            CreateMap<BrandDto, Brand>().ReverseMap();
        }
    }
}