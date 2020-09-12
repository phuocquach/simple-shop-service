using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Mine.Commerce.Domain.Core.Services.StorageService;

namespace Mine.Commerce.Infrastructure.Services.Storage
{
    public class AzureblobStorage : IStorageService
    {
        private readonly string _endpoint = "";
        private readonly string _sharedKey = "";
        private readonly string _rootFolder = "";
        private readonly string _accountName = "";
        //private readonly string _connectionStr ="DefaultEndpointsProtocol=https;AccountName=sd3540storage;AccountKey=uMKBPLcVGII0SUFVeZ1MhfQLa3lXrsnptKeXMUSLohAT7nJEKJYnKSXuKcTUsIsbepGOgGEBMVECgKtkapZK+A==;BlobEndpoint=https://sd3540storage.blob.core.windows.net/;QueueEndpoint=https://sd3540storage.queue.core.windows.net/;TableEndpoint=https://sd3540storage.table.core.windows.net/;FileEndpoint=https://sd3540storage.file.core.windows.net/;";
        public AzureblobStorage(IConfiguration config)
        {
            _endpoint = config.GetSection("AzureStorageInfor:EndpointUri").Value;
            _sharedKey = config.GetSection("AzureStorageInfor:SharedKey").Value;
            _rootFolder = config.GetSection("AzureStorageInfor:RootFolder").Value;
            _accountName = config.GetSection("AzureStorageInfor:AccountName").Value;
        }
        public async Task<bool> UploadFile(Stream fileStream, string fileName)
        {
            Uri blobUri = new Uri($"{_endpoint}{_rootFolder.ToLower()}/{fileName.ToLowerInvariant()}");

            StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(_accountName, _sharedKey);
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            await blobClient.UploadAsync(fileStream);

            return await Task.FromResult(true);

        }

        public async Task<Stream> DownloadFile(string fileName)
        {
            Uri blobUri = new Uri($"{_endpoint}{_rootFolder.ToLower()}/{fileName.ToLowerInvariant()}");

            StorageSharedKeyCredential storageCredentials = new StorageSharedKeyCredential(_accountName, _sharedKey);
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            BlobDownloadInfo blobDownload = await blobClient.DownloadAsync();
            return blobDownload.Content;
        }
    }
}