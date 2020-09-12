using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Mine.Commerce.Domain.Core
{
    public abstract class DbContextQueryRepository<T> : IQueryRepository<T>
        where T: Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public DbContextQueryRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> Get(Guid id, CancellationToken cancellation = default)
        {
            return await _dbSet.SingleAsync(x => x.Id == id);
        }

        public virtual async Task<(IEnumerable<T>, int)> GetAll(CancellationToken cancellation = default)
        {
            return (await _dbSet.Where(x => !x.IsDeleted).ToListAsync(), await _dbSet.Where(x => !x.IsDeleted).CountAsync(cancellation));
        }
        public virtual async Task<IEnumerable<T>> FindByAsync(Func<T, bool> selector , CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(x => !x.IsDeleted).Where(selector);
        }
        public abstract Task<IEnumerable<T>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default);
    }
}