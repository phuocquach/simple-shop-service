using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;
using Mine.Commerce.Infrastructure.DBContext;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class CategoryCommandRepository : DbContextCommandRepository<Category>,
                                             ICommandRepository<Category>                                  
    {
        private readonly DbSet<Category> _dbsetCategory;
        public CategoryCommandRepository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbsetCategory = dbContext.Set<Category>();
            _dbContext = dbContext;
        }
        public async override Task UpdateAsync(Category item, CancellationToken cancellationToken = default)
        {
            _dbsetCategory.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}