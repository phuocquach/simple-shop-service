using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mine.Commerce.Domain.Features.Carts;

namespace Mine.Commerce.Application.Features.Carts.Command
{
    public class CheckoutCartHandler : IRequestHandler<CheckoutCartRequest, Unit>
    {
        private readonly ICartServices _cartServices;
        public CheckoutCartHandler(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        public Task<Unit> Handle(CheckoutCartRequest request, CancellationToken cancellationToken)
        {
            _cartServices.CheckOut(request.Id);
            throw new System.NotImplementedException();
        }
    }
}