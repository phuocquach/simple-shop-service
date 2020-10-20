using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mine.Commerce.Domain.Core.Events;

namespace Mine.Commerce.Infrastructure.Events
{
    public class EventManager : IEventManager
    {
        private HashSet<DomainEvent> _domainEvents;
        public EventManager()
        {

        }

        public async Task AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public Task AddDomainEvent<T>(T domainEvent) where T : DomainEvent
        {
            throw new NotImplementedException();
        }
    }
}
