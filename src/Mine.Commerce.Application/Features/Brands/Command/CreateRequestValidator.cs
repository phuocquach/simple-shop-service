using FluentValidation;
using Mine.Commerce.Application.Brands;
using Mine.Commerce.Infrastructure.Validator;
namespace Mine.Commerce.Application.Features.Brands
{
    public class CreateRequestValidator : BaseValidator<CreateRequest>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            
        }
        
    }
}