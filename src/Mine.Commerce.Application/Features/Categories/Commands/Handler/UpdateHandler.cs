using Mapster;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Categories.Commands.Handler
{
    public class UpdateHandler : IRequestHandler<UpdateRequest, CategoryDto>
    {
        private readonly ICommandRepository<Category> _categoryRepository;
        public UpdateHandler(ICommandRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();
            await _categoryRepository.UpdateAsync(category, cancellationToken);
            return category.Adapt<CategoryDto>();
        }
    }
}