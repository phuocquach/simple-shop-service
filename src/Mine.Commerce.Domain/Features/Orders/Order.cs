using System;
using System.Collections.Generic;
using Mine.Commerce.Domain.Common;
using Mine.Commerce.Domain.Core;

namespace Mine.Commerce.Domain
{
    public class Order: Entity, IAggregateRoot
    {
        public string Code { get; set; }
        public Guid CustomerId {get; set; }
        public int OrderStatus { get; set; }
        public ICollection<OrderItem> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address DeliverAddress { get; set; }
    }
}