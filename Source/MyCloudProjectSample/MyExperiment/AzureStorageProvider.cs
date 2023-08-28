using Azure;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
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
            var StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=unitestascc1;AccountKey=+t9h+axcMrFD5n/7lM9znJziZ9Ou1xtqR0hEYpSXvhX8h9Z+x6dv5vMoqop7jFJu02fMd4IESgCh+AStNYhqVw==;EndpointSuffix=core.windows.net ";
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
            var client = new TableClient(this.config.StorageConnectionString, this.config.ResultTable);

            await client.CreateIfNotExistsAsync();
            var count = result.Input;

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Create a worksheet
                var worksheet = package.Workbook.Worksheets.Add("TestResults");

                // Adding headers
                worksheet.Cells[1, 1].Value = "TestName";
                worksheet.Cells[1, 2].Value = "ExpectedResult";
                worksheet.Cells[1, 3].Value = "ActualResult";
                worksheet.Cells[1, 4].Value = "****";



                await client.UpsertEntityAsync((ExperimentResult)result);

                // Save the Excel package to a stream
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin); // Ensure the stream position is set to the beginning

                    // Upload the Excel file to Azure Blob Storage
                    var connectionString = "DefaultEndpointsProtocol=https;AccountName=unitestascc1;AccountKey=+t9h+axcMrFD5n/7lM9znJziZ9Ou1xtqR0hEYpSXvhX8h9Z+x6dv5vMoqop7jFJu02fMd4IESgCh+AStNYhqVw==;EndpointSuffix=core.windows.net";
                    var containerName = "resultcontainer";
                    BlobClient blobClient = new BlobClient(connectionString, containerName, "test_results.xlsx");
                    await blobClient.UploadAsync(stream, true);
                }
            }

            ExperimentResult res = new ExperimentResult("damir", "123")
            {
                //Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),

                Accuracy = (float)0.5,
            };

         
            

        }

        /*  public async Task<byte[]> UploadResultFile(string fileName, byte[] data)
          {


              throw new NotImplementedException();
          }*/





        async Task<byte[]> UploadResultFile(string fileName, byte[] data) => throw new NotImplementedException();

        Task<byte[]> IStorageProvider.UploadResultFile(string fileName, byte[] data)
        {
            throw new NotImplementedException();
        }
    }


}
