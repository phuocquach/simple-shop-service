using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core
{
    public interface IQueryRepository<T> where T: Entity
    {
        Task<(IEnumerable<T> items, int total)> GetAll(CancellationToken cancellation = default);
        Task<T> Get(Guid id, CancellationToken cancellation = default);
        Task<IEnumerable<T>> FindByAsync(Func<T, bool> selector , CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default);
    }
}