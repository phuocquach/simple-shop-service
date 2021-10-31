using System;
using System.Collections.Generic;
using Mine.Commerce.Domain.Common;

namespace Mine.Commerce.Domain.Features.Carts
{
    public class CartDto
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public string PromotionCode { get; set; }
        public int CartStatus { get; set; }
    }
}