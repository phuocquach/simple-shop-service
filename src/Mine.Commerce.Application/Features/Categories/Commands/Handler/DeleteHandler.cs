using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;

namespace Mine.Commerce.Application.Categories.Commands.Handler
{
    public class DeleteHandler : IRequestHandler<DeleteRequest>
    {
        private readonly ICommandRepository<Category> _commandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteHandler (ICommandRepository<Category> commandRepository,
                            IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.Commit();
            return new Unit();
        }
    }
}