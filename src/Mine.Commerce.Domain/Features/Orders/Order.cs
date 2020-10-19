using System;
using System.Collections.Generic;
using Mine.Commerce.Domain.Common;

namespace Mine.Commerce.Domain
{
    public class Order: Entity
    {
        public string Code { get; set; }
        public Guid CustomerId {get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address DeliverAddress { get; set; }
    }
}