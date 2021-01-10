using System;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Features.Carts
{
    public interface ICartServices
    {
        Task<bool> GetCart(Guid customerId);
        Task<bool> AddCartItem(CartItem cartItem);
        Task<bool> RemoveCartItem(Guid cartItemId);
        Task<bool> CheckOut(Cart cart);
    }
}