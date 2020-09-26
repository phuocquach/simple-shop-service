using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Domain.Core.Handler;

namespace Mine.Commerce.Application.Products.Command.Handler
{
    public class DeleteHandler : BaseHandler, IRequestHandler<DeleteRequest>
    {
        private readonly ICommandRepository<Product> _commandRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteHandler (ICommandRepository<Product> commandRepository,

                            IMapper mapper,
                            IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
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