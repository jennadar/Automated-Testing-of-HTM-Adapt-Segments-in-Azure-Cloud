using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageSamples
{
    class Program 
    {
       // private const string _connectionString = "DefaultEndpointsProtocol=https;AccountName=beststudentsever;AccountKey=eWK1RGlbTpEth/zvCI3aXZAAwyDkBkngZ5zRhY7k4h3yzWRo2r3oG1KqWZ8GPzN+Fax4fEx7rAvV+AStD3Dglw==;EndpointSuffix=core.windows.net";

        private const string _connectionString = "DefaultEndpointsProtocol=https;AccountName=mybeststudents;AccountKey=exGnIGN5+MEv9lFPzYNgs7op+Go8zbdH5jd5t3TKAoaGS9hC8SpBF2svKQDwYxEHkJwdwrF/PqYw+AStNv9yGQ==;EndpointSuffix=core.windows.net";
            
            //private const string _connectionString = "UseDevelopmentStorage=true";
        
    
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Blob Storage!");

            await UploadAsync();

            await DownloadAsync();

            await AppendToBlobAsync();
        }

        /// <summary>
        /// Upload a file to a blobClient].
        /// </summary>
        public static async Task UploadAsync()
        {

            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = _connectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, "sample-container");
            
            await container.CreateIfNotExistsAsync();
            
            try
            {
                // Get a reference to a blobClient]
                BlobClient blobClient = container.GetBlobClient("Azure Storage.pptx");
               
                // Upload file data
                await blobClient.UploadAsync("Azure Storage.pptx");


                // Verify we uploaded some content
                BlobProperties properties = await blobClient.GetPropertiesAsync();
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();

            }
        }


        /// <summary>
        /// Download a blobClient] to a file.
        /// </summary>

        public static async Task DownloadAsync()
        {

            // Get a connection string to our Azure Storage account.
            string connectionString = _connectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, "sample-container");
            await container.CreateIfNotExistsAsync();
            try
            {
                // Get a reference to a blobClient] named "sample-file"
                BlobClient blob = container.GetBlobClient("Azure Storage.pptx");


                // Download the blobClient]'s contents and save it to a file
                BlobDownloadInfo download = await blob.DownloadAsync();
                using (FileStream file = File.OpenWrite("Azure Storage Downloaded.pptx"))
                {
                    download.Content.CopyTo(file);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }

        }

        static async Task AppendToBlobAsync ()
        {
         
            BlobContainerClient containerClient = new BlobContainerClient(_connectionString, "sample-container");
            containerClient.CreateIfNotExists();

            AppendBlobClient appendBlobClient = containerClient.GetAppendBlobClient("largeblob.csv");

            appendBlobClient.CreateIfNotExists();           

            for (int i = 0; i < 1000; i++)
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Create a StreamWriter to write to the MemoryStream using UTF-8 encoding
                    using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
                    {
                        for (int y = 0; y < 100; y++)
                        {
                            writer.Write($"{DateTime.Now.ToString()};\r\n");
                        }

                        if (memoryStream.Length < appendBlobClient.AppendBlobMaxAppendBlockBytes)
                        {
                            writer.Flush();
                            memoryStream.Flush();
                            memoryStream.Position = 0;
                            await appendBlobClient.AppendBlockAsync(memoryStream);
                        }
                        else
                            throw new NotImplementedException();
                    }

                   
                }
            }
        }
    }
}
