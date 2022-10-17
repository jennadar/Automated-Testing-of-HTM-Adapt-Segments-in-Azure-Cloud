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
            QueueStorageSamples samples = new QueueStorageSamples("DefaultEndpointsProtocol=https;AccountName=cloudproject2022;AccountKey=nZRb5dLImtjBQxAMKY41w2ks13f2D39nqMaAhTW8ct1OC5RWHtvQUSfC53W2uD+ho1saM/LZcNuaELuDMfGm0g==;EndpointSuffix=core.windows.net");

            //await samples.CreateQueue();

            //await samples.SendMessages();

            //await samples.ReceiveMessages();

            //await samples.SendReceiveMessagesAdvanced();

            //await samples.DeleteQueue();

            //await samples.SendManyMessages();

            await samples.ReceiveManyMessages();

        }
    }
}
