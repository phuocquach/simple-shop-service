using FluentValidation;
using Mine.Commerce.Application.Products.Command;

namespace Mine.Commerce.Application.Features.Products.Command
{
    public class CreateRequestValidator : AbstractValidator<CreateRequest> 
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.InStock).Equals(true);
            RuleFor(x => x.IsActive).Equals(true);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}