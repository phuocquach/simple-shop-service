using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Infrastructure.Scheduler
{
    public interface IScheduledTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
