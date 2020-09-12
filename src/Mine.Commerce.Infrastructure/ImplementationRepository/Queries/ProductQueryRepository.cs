using Mine.Commerce.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System;

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
            return await _dbSet.Where(x=>!x.IsDeleted).Include(x => x.ProductCategories)
                                .Include(x => x.ProductImages).ToListAsync();
        }
        public override async Task<(IEnumerable<Product>, int)> GetAll(CancellationToken cancellation = default)
        {
            return (await _dbSet.Where(x=>!x.IsDeleted).Include(x => x.ProductCategories)
                                .Include(x => x.ProductImages)
                                .ToListAsync(), await _dbSet.CountAsync(cancellation));
        }
         public override async Task<Product> Get(Guid id, CancellationToken cancellation = default)
         {
             return (await _dbSet.Where(x=>!x.IsDeleted && x.Id == id).Include(x => x.ProductCategories)
                                .Include(x => x.ProductImages).FirstOrDefaultAsync());
         }
    }
}