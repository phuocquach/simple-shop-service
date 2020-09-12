using System;
using System.Collections.Generic;
using System.Threading;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Threading.Tasks;
using AutoMapper;

namespace Mine.Commerce.Application.Categories.Queries.Handler
{
    public class RequestHandler : IRequestHandler<GetByIdRequest, CategoryDto>,
                                    IRequestHandler<GetListRequest, IEnumerable<CategoryDto>>
    {
        private readonly IQueryRepository<Category> _queryRepository;
        private readonly IMapper _mapper;
        public RequestHandler(IQueryRepository<Category> queryRepository,
                                IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryDto>(await _queryRepository.Get(request.Id));
        } 

        public async Task<IEnumerable<CategoryDto>> Handle(GetListRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CategoryDto>> ((await _queryRepository.GetAll()).items);
        }
    }
}