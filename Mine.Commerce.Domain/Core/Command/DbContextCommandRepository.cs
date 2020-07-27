using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core
{
    public abstract class DbContextCommandRepository<T> : ICommandRepository<T>
        where T: Entity
    {
        protected readonly DbSet<T> _dbSet;
        protected DbContextCommandRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }
        public virtual async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(item);
        }
        public async virtual Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _dbSet.FirstAsync(x => x.Id == id);

            if(item is null)
            {
                return false;
            }
             _dbSet.Remove(item);
            return true;
        }
        public virtual async Task UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(item);
        }
        
    }
}