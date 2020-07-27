using System.IO;
using System.Threading.Tasks;
using Mine.Commerce.Domain.Core.Services.StorageService;

namespace Mine.Commerce.Infrastructure.Services.Storage
{
    public class LocalStorage : IStorageService
    {
        private readonly string _rootFoler;
        public LocalStorage(){
            _rootFoler = "./Dev";
            if (!Directory.Exists(_rootFoler)){
                Directory.CreateDirectory(_rootFoler);
            }
        }

        public Task<Stream> DownloadFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UploadFile(Stream fileStream, string fileName)
        {
            var file = new FileStream($"{_rootFoler}/{fileName}", FileMode.Create);
            await fileStream.CopyToAsync(file);
            return true;
        }
    }
}