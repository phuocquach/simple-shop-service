using AutoMapper;
using Mine.Commerce.Domain;

namespace Mine.Commerce.Application.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<UpdateRequest, Category>().ReverseMap();
        }
    }
}