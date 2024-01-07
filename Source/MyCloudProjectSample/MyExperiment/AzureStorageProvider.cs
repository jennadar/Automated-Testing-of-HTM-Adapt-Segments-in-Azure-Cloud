using Azure;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyExperiment
{
    public class AzureStorageProvider : IStorageProvider
    {
        private MyConfig config;

        public AzureStorageProvider(IConfigurationSection configSection)
        {
            config = new MyConfig();
            configSection.Bind(config);
        }

        public async Task<string> DownloadInputFile(string fileName)
        {
            var StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=ccprojectsd;AccountKey=iFIo1wiye4/5h3AuXhYV/DQEFNhEQJjfMB01LKk7g2lFLfshFMebotpPSen00fTUFj6YWYQg7CT2+AStchEFjQ==;EndpointSuffix=core.windows.net";
            await Console.Out.WriteLineAsync("Ensuring I am in DownloadInputFile class");
            BlobContainerClient container = new BlobContainerClient(StorageConnectionString, fileName);
            await container.CreateIfNotExistsAsync();

            // Get a reference to a blob named "sample-file"
            BlobClient blob = container.GetBlobClient(fileName);

            //throw if not exists:
            //blob.ExistsAsync

            // return "../myinputfilexy.csv"
            throw new NotImplementedException();
        }



        public async Task UploadExperimentResult(IExperimentResult result)
        {
            var experimentLabel = result.ExperimentName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(this.config.StorageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("adaptsegmentsunittests-teamas");

            // Write encoded data to Excel file
            byte[] excelData = result.excelData;

            // Generate a unique blob name (you can customize this logic)
            string blobName = $"Test_data_{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.xlsx";

            // Upload the Excel data to the blob container
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (MemoryStream memoryStream = new MemoryStream(excelData))
            {
                await blobClient.UploadAsync(memoryStream);
            }
        }




        async Task<byte[]> UploadResultFile(string fileName, byte[] data) => throw new NotImplementedException();

        Task<byte[]> IStorageProvider.UploadResultFile(string fileName, byte[] data)
        {
            throw new NotImplementedException();
        }
    }


}
