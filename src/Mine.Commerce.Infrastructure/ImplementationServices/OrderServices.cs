using System.Threading.Tasks;
using Mine.Commerce.Domain.Features.Orders.Services;

namespace Mine.Commerce.Infrastructure.ImplementationServices
{
    public class OrderServices : IOrderServices
    {
        public Task CreateOrder(OrderDto orderDto)
        {
            throw new System.NotImplementedException();
        }
    }
}