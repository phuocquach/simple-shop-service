using System;
using System.Collections.Generic;
using Mine.Commerce.Domain.Common;

namespace Mine.Commerce.Domain.Features.Orders.Services
{
    public class OrderDto: GuidCodeName
    {
        public GuidCodeName Customer {get; set; }
        public int OrderStatus { get; set; }
        public ICollection<OrderItem> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address DeliverAddress { get; set; }
    }
}