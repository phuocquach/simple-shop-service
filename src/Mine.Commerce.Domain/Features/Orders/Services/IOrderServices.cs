using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Features.Orders.Services
{
    public interface IOrderServices
    {
         Task CreateOrder(OrderDto orderDto);
    }
}