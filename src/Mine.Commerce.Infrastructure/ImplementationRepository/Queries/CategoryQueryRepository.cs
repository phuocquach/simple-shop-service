using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class CategoryQueryRepository : DbContextQueryRepository<Category>, IQueryRepository<Category>
    {
        private readonly DbContext _dbContext;
        private DbSet<Category> _dbSet;
        public CategoryQueryRepository(DbContext dbContext)
        : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Category>();
        }

        public override async Task<IEnumerable<Category>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsQueryable().Where(x => !x.IsDeleted).ToListAsync();
        }
    }
}
