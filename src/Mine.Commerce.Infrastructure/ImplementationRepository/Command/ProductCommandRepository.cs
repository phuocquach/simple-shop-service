using Mine.Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Mine.Commerce.Infrastructure.DBContext;
using Mine.Commerce.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class ProductCommandRepository : DbContextCommandRepository<Product>,
                                            ICommandRepository<Product>
                                        
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<ProductImage> _productImageDbset;
        private DbSet<ProductCategory> _productCategoryDbSet;
        private DbSet<Product> _dbsetProduct;
        public ProductCommandRepository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
            _productImageDbset = _dbContext.Set<ProductImage>();
            _productCategoryDbSet = _dbContext.Set<ProductCategory>();
            _dbsetProduct = _dbContext.Set<Product>();
        }
        public override async Task AddAsync(Product item, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.AddAsync(item);
            // item.ProductCategories?.Select(async x => await _productCategoryDbSet.AddAsync(new ProductCategory()
            // {
            //     ProductId = item.Id,
            //     CategoryId = x.CategoryId
            // }));
            item.ProductCategories?.Select(async x => await _productCategoryDbSet.AddAsync(x));
            item.ProductImages.Select(async x => await _productImageDbset.AddAsync(x));
            await _dbContext.SaveChangesAsync();
        }

        public async override Task UpdateAsync(Product item, CancellationToken cancellationToken = default(CancellationToken))
        {
            //var product = _dbsetProduct.FirstAsync(x => x.Id == item.Id);
            _dbsetProduct.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
