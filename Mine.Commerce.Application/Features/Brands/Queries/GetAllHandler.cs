using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Application.Features.Brands;

namespace Mine.Commerce.Application.Brands.Queries
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<BrandDto>>
    {
        private IQueryRepository<Brand> _brandRepository { get; set; }
        private IMapper _mapper {get; set;}
        public GetAllHandler(IQueryRepository<Brand> brandRepository, 
                                    IMapper mapper )
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrandDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var (brands, total) = await _brandRepository.GetAll();
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }
    }
}