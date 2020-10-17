using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core.Events
{
    public interface IEventManager
    {
        Task AddDomainEvent<T>(T domainEvent)
            where T : DomainEvent;
    }
}