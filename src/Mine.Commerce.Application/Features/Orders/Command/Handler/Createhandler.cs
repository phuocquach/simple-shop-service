using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mine.Commerce.Domain.Core.Handler;

namespace Mine.Commerce.Application.Orders
{
    public class Createhandler : BaseHandler, IRequestHandler<CreateRequest, Guid>
    {
        public Createhandler()
         : base()
        {
        }

        public Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}