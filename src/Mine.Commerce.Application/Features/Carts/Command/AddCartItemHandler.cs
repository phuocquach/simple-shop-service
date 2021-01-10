using MediatR;
using Mine.Commerce.Domain.Features.Carts;
using System.Threading;
using System.Threading.Tasks;
using Mapster;

namespace Mine.Commerce.Application.Features.Carts
{
    public class AddCartItemHandler : IRequestHandler<AddCartItemRequest, Unit>
    {
        private ICartServices _cartServices;
        public AddCartItemHandler(ICartServices cartServices )
        {
            _cartServices = cartServices;
        }
        public async Task<Unit> Handle(AddCartItemRequest request, CancellationToken cancellationToken)
        {
            await _cartServices.AddCartItem(request.Adapt<CartItem>());

            return new Unit();
        }
    }
}