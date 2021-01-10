using System;

namespace Mine.Commerce.Domain.Features.Customers.Services
{
    public class CustomerDto
    {
        public Guid AccountId { get; set; }
        public Guid CartId { get; set; }
        public Guid AddressId { get; set; }
    }
}