using System;
using System.Threading.Tasks;
using Mine.Commerce.Domain.Features.Carts;

namespace Mine.Commerce.Infrastructure.ImplementationServices
{
    public class CartServices : ICartServices
    {
        public Task<bool> AddCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckOut(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetCart(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCartItem(Guid cartItemId)
        {
            throw new NotImplementedException();
        }
    }
}