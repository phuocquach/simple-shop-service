using Mine.Commerce.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class BrandQueryRepository : DbContextQueryRepository<Brand>,
                                         IQueryRepository<Brand>
    {
        private readonly DbSet<Brand> _dbSet;
        public BrandQueryRepository(DbContext context) : base(context)
        {
            _dbSet = context.Set<Brand>();
        }

        public override async Task<IEnumerable<Brand>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(x=>!x.IsDeleted).ToListAsync();
        }
    }
}