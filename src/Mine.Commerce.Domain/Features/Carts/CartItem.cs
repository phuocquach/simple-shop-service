using System;

namespace Mine.Commerce.Domain.Features.Carts
{
    public class CartItem : Entity
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public long Number { get; set; }
    }
}