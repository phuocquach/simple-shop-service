using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core
{
    public interface ICommandRepository<T> where T: Entity
    {
        Task AddAsync(T item, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(T item, CancellationToken cancellationToken = default);
    }
}