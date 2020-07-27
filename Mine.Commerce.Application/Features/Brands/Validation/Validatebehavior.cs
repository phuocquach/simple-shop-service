using MediatR;
using Mine.Commerce.Application.Brands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Features.Brands.Validation
{
    public class Validatebehavior : IPipelineBehavior<CreateRequest, Guid>
    {
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Guid> next)
        {
            var response = await next();
            return response;
        }
    }
}
