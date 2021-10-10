using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class ProductQueryRepository : DbContextQueryRepository<Product>,
                                         IQueryRepository<Product>
    {
        private readonly DbSet<Product> _dbSet;
        public ProductQueryRepository(DbContext context) : base(context)
        {
            _dbSet = context.Set<Product>();
        }

        public override async Task<IEnumerable<Product>> GetListAsync(int index, int offset, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsQueryable().Where(x => !x.IsDeleted).Include(x => x.ProductCategories)
                                .Include(x => x.ProductImages).ToListAsync();
        }
        public override async Task<(IEnumerable<Product>, int)> GetAll(CancellationToken cancellation = default)
        {
            return (await _dbSet.AsQueryable().Where(x => !x.IsDeleted).Include(x => x.ProductCategories)
                                .Include(x => x.ProductImages)
                                .ToListAsync(), await _dbSet.AsQueryable().CountAsync(cancellation));
        }
        public override async Task<Product> Get(Guid id, CancellationToken cancellation = default)
        {
            return (await _dbSet.AsQueryable().Where(x => !x.IsDeleted && x.Guid == id).Include(x => x.ProductCategories)
                               .Include(x => x.ProductImages).FirstOrDefaultAsync());
        }
    }
}