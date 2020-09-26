using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;

namespace Mine.Commerce.Application.Categories.Commands.Handler
{
    public class UpdateHandler : BaseHandler, IRequestHandler<UpdateRequest, CategoryDto>
    {
        private readonly ICommandRepository<Category> _categoryRepository;
        private readonly IQueryRepository<Category> _categoryQueryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateHandler(ICommandRepository<Category> categoryRepository,
                            IQueryRepository<Category> categoryQueryRepository,
                            IMapper mapper,
                            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(category, cancellationToken);
            
            await _unitOfWork.Commit();
            return _mapper.Map<CategoryDto>(category);
        }
    }
}