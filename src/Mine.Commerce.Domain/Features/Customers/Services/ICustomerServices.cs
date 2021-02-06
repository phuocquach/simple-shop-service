using System;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Features.Customers.Services
{
    public interface ICustomerServices
    {
         Task<CustomerDto> GetCustomer(Guid id);
         Task AddCustomer(CustomerDto customerDto);
    }
}