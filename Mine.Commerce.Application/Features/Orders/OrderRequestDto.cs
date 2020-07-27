using Mine.Commerce.Application.Common;
using System;

namespace Mine.Commerce.Application.Features.Orders
{
    public class OrderRequestDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } 
        public string CustomerId { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public AddressDto DeliverAddress { get; set; }
    }
}
