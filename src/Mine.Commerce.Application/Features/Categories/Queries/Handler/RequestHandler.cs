using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Categories.Queries.Handler
{
    public class RequestHandler : BaseHandler, IRequestHandler<GetByIdRequest, CategoryDto>,
                                    IRequestHandler<GetListRequest, IEnumerable<CategoryDto>>
    {
        private readonly IQueryRepository<Category> _queryRepository;
        public RequestHandler(IQueryRepository<Category> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<CategoryDto> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _queryRepository.Get(request.Id);
            return category.Adapt<CategoryDto>();
        } 

        public async Task<IEnumerable<CategoryDto>> Handle(GetListRequest request, CancellationToken cancellationToken)
        {
            var (items, total) = await _queryRepository.GetAll();
            return items.Adapt<IEnumerable<CategoryDto>>();
        }
    }
}