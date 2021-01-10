using System;

namespace Mine.Commerce.Domain.Features.Orders
{
    public class Customer: Entity
    {
        public Guid AccountId { get; set; }
        public Guid CartId { get; set; }
        public Guid AddressId { get; set; }
    }
}