using System.IO;
using System.Threading.Tasks;

namespace Mine.Commerce.Domain.Core.Services.StorageService
{
    public interface IStorageService
    {
        Task<bool> UploadFile(Stream fileStream, string fileName);
        Task<Stream> DownloadFile(string fileName);
    }
}