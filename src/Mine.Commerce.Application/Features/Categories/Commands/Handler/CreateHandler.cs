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
    public class CreateHandler : IRequestHandler<CreateRequest,Guid>
    {
        private readonly ICommandRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateHandler(ICommandRepository<Category> categoryRepository,
                            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var category = Category.Create(request.Name);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.Commit();

            return category.Id;
        }
    }
}