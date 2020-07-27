using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Mine.Commerce.Domain.Core;

namespace Mine.Commerce.Infrastructure.ImplementationRepository
{
    public class BrandCommandRepository: DbContextCommandRepository<Brand>,
                                             ICommandRepository<Brand>   
                                                
    {
        private readonly DbSet<Brand> _dbset;
        public BrandCommandRepository(DbContext dbcontext)
        :base(dbcontext)
        {
            _dbset = dbcontext.Set<Brand>();
        }
        public async override Task UpdateAsync(Brand item, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbset.Update(item);
        }
    }
}