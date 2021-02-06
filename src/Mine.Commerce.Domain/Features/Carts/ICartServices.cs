using System;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Features.Carts
{
    public interface ICartServices
    {
        Task<CartDto> GetCart(Guid id);
        Task AddCartItem(CartItem cartItem);
        Task RemoveCartItem(Guid cartItemId);
        Task CheckOut(Guid id);
    }
}