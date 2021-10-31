using System;
using System.Collections.Generic;
using Mine.Commerce.Domain.Common;

namespace Mine.Commerce.Domain.Features.Carts
{
    public class Cart : Entity
    {
        public Guid CustomerId { get; set; }
        public HashSet<CartItem> CartItems { get; set; }
        public string PromotionCode { get; set; }
        public int CartStatus { get; set; }

    }
}