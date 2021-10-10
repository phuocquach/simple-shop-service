using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Brands
{
    public class CreateHandler : IRequestHandler<CreateRequest, Guid>
    {
        private readonly ICommandRepository<Brand> _brandRepository;
        public CreateHandler(ICommandRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var brand = request.Adapt<Brand>();

            await _brandRepository.AddAsync(brand);

            return brand.Guid;
        }
    }
}