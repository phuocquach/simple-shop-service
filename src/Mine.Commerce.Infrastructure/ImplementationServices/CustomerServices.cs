using System;
using System.Threading.Tasks;
using Mine.Commerce.Domain.Features.Customers.Services;

namespace Mine.Commerce.Infrastructure.ImplementationServices
{
    public class CustomerServices : ICustomerServices
    {
        public Task AddCustomer(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> GetCustomer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}