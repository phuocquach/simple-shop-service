using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Application.Products.Command.Handler
{
    public class DeleteHandler : IRequestHandler<DeleteRequest>
    {
        private readonly ICommandRepository<Product> _commandRepository;
        public DeleteHandler (ICommandRepository<Product> commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteAsync(request.Id, cancellationToken);
            return new Unit();
        }
    }
}