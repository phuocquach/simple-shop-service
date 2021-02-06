using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mine.Commerce.Domain.Features.Carts;
using Mapster;
namespace Mine.Commerce.Application.Features.Carts
{
    public class GetCarthandler : IRequestHandler<GetCartRequest, GetCartResponse>
    {
        private readonly ICartServices _cartServices;
        public GetCarthandler(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        public async Task<GetCartResponse> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            var  cartDto = await _cartServices.GetCart(request.Id);
            return cartDto.Adapt<GetCartResponse>();
        }
    }
}