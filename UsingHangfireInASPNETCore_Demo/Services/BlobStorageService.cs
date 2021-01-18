using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;

namespace UsingHangfireInASPNETCore_Demo.Services
{
    // uses Azure.Storage.Blobs 
    public class BlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        

        public BlobStorageService(
            BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public void CreateContainerIfNotExists(string containerName)
        {
            var container = this.blobServiceClient.GetBlobContainerClient(containerName);

            if (!container.Exists())
            {
                this.blobServiceClient.CreateBlobContainer(containerName);
            }         
        }

        public async Task UploadItemAsync(string containerName, string fileName, Stream stream)
        {
            var container = this.blobServiceClient.GetBlobContainerClient(containerName);

            if (!container.Exists())
            {
                throw new Exception($"Cannot find container {containerName}");
            }

            BlobClient blobClient = container.GetBlobClient(fileName);

            await blobClient.UploadAsync(stream);
        }
    }
}
