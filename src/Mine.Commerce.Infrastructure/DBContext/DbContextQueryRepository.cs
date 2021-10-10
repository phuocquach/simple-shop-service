using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.DBContext
{
    public abstract class DbContextQueryRepository<T> : IQueryRepository<T>
        where T : Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        protected DbContextQueryRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> Get(Guid guid, CancellationToken cancellation = default)
        {
            return await _dbSet.AsQueryable().SingleAsync(x => x.Guid == guid);
        }

        public virtual async Task<(IEnumerable<T>, int)> GetAll(CancellationToken cancellation = default)
        {
            return (await _dbSet.AsQueryable().Where(x => !x.IsDeleted).ToListAsync(),
                await _dbSet.AsQueryable().Where(x => !x.IsDeleted).CountAsync(cancellation));
        }
        public virtual async Task<IEnumerable<T>> FindByAsync(Func<T, bool> selector, CancellationToken cancellationToken = default)
        {
            return _dbSet.AsQueryable().Where(x => !x.IsDeleted).Where(selector);
        }
        public abstract Task<IEnumerable<T>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default);
    }
}