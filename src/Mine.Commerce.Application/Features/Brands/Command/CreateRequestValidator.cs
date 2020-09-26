using System;
using System.Threading;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Mine.Commerce.Application.Brands;
using Mine.Commerce.Infrastructure.Validator;

namespace Mine.Commerce.Application.Features.Brands
{
    public class CreateRequestValidator : BaseValidator<CreateRequest>, IPipelineBehavior<CreateRequest, Guid>
    {
        private readonly ILogger _logger;
        public CreateRequestValidator(ILogger<CreateRequest> logger)
        {
            _logger = logger;
            RuleFor(x => x.Name).NotEmpty(); 
        }

        public System.Threading.Tasks.Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Guid> next)
        {
            _logger.LogInformation("123");
           return next();
        }
    }
}