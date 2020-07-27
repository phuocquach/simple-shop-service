using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core
{
    public interface IUnitOfWork
    {
        Task Commit();
    } 
}