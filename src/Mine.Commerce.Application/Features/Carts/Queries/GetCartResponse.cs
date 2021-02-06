using System.Collections.Generic;
using Mine.Commerce.Domain.Common;
using Mine.Commerce.Domain.Features.Carts;

namespace Mine.Commerce.Application.Features.Carts
{
    public class GetCartResponse
    {
        public IEnumerable<CartItem> CartItems { get; set;}
        public CartStatus CartStatus { get; set; }
    }
}