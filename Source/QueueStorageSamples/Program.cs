using System;
using System.Threading.Tasks;

namespace QueueStorageSamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Azure Queues World!");

            //QueueStorageSamples samples = new QueueStorageSamples("UseDevelopmentStorage=true");
            QueueStorageSamples samples = new QueueStorageSamples("DefaultEndpointsProtocol=https;AccountName=beststudentsever;AccountKey=eWK1RGlbTpEth/zvCI3aXZAAwyDkBkngZ5zRhY7k4h3yzWRo2r3oG1KqWZ8GPzN+Fax4fEx7rAvV+AStD3Dglw==;EndpointSuffix=core.windows.net");

            await samples.CreateQueue();

            await samples.SendMessages();

            await samples.ReceiveMessages();

            await samples.SendReceiveMessagesAdvanced();

            await samples.DeleteQueue();

            await samples.SendManyMessages();

            await samples.ReceiveManyMessages();

        }
    }
}
