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
        public CategoryCommandRepository(DbContext context) 
            : base(context)
        {
            _dbsetCategory = context.Set<Category>();
        }
        public async override Task UpdateAsync(Category item, CancellationToken cancellationToken)
        {
            _dbsetCategory.Update(item);
        }
    }
}