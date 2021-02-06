using System;
using System.Threading.Tasks;
using Mine.Commerce.Domain.Features.Carts;

namespace Mine.Commerce.Infrastructure.ImplementationServices
{
    public class CartServices : ICartServices
    {
        public Task AddCartItem(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task CheckOut(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCart(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCartItem(Guid cartItemId)
        {
            throw new NotImplementedException();
        }
    }
}