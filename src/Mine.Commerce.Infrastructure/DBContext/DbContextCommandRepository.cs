using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.DBContext
{
    public abstract class DbContextCommandRepository<T> : ICommandRepository<T>
        where T: Entity
    {
        protected readonly DbSet<T> _dbSet;
        protected DbContext _dbContext;
        protected DbContextCommandRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public virtual async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
        public async virtual Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _dbSet.FirstAsync(x => x.Id == id);

            if(item is null)
            {
                return false;
            }
             _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public virtual async Task UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(item);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}