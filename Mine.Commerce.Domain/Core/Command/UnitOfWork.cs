using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mine.Commerce.Domain.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}