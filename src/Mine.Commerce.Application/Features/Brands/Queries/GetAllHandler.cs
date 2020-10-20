using Mapster;
using MediatR;
using Mine.Commerce.Application.Features.Brands;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Brands.Queries
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<BrandDto>>
    {
        private IQueryRepository<Brand> _brandRepository { get; set; }
        public GetAllHandler(IQueryRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IEnumerable<BrandDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var (brands, total) = await _brandRepository.GetAll();
            return brands.Adapt<IEnumerable<BrandDto>>();
        }
    }
}