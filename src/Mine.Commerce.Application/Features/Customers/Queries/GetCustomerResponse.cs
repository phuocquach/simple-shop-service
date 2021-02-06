using System;

namespace Mine.Commerce.Application.Features.Customers
{
    public class GetCustomerResponse
    {
        public Guid CustomerId { get; set; }
        public Guid CartId { get; set; }
        public string UserName { get; set; }
        
    }
}