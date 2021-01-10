using System;

namespace Mine.Commerce.Domain.Features.Orders
{
    public class Customer : Entity
    {
        public string Email { get; set;} 
        public Address address { get; set;} //TODO: refactor to multiple address
    }
}