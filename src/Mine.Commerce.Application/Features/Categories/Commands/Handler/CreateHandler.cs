using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Categories.Commands.Handler
{
    public class CreateHandler : IRequestHandler<CreateRequest, Guid>
    {
        private readonly ICommandRepository<Category> _categoryRepository;
        public CreateHandler(ICommandRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();
            await _categoryRepository.AddAsync(category);

            return category.Guid;
        }
    }
}