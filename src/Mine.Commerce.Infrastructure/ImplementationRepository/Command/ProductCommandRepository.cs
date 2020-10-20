using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.DBContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class ProductCommandRepository : DbContextCommandRepository<Product>,
                                            ICommandRepository<Product>
                                        
    {
        private readonly DbSet<ProductImage> _productImageDbset;
        private readonly DbSet<ProductCategory> _productCategoryDbSet;
        private readonly DbSet<Product> _dbsetProduct;
        public ProductCommandRepository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productImageDbset = _dbContext.Set<ProductImage>();
            _productCategoryDbSet = _dbContext.Set<ProductCategory>();
            _dbsetProduct = _dbContext.Set<Product>();
        }
        public override async Task AddAsync(Product item, CancellationToken cancellationToken = default)
        {
            await base.AddAsync(item, cancellationToken);
            item.ProductCategories?.Select(async x => await _productCategoryDbSet.AddAsync(x));
            _ = item.ProductImages.Select(async x => await _productImageDbset.AddAsync(x, cancellationToken));
            await _dbContext.SaveChangesAsync();
        }

        public async override Task UpdateAsync(Product item, CancellationToken cancellationToken = default)
        {
            _dbsetProduct.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
