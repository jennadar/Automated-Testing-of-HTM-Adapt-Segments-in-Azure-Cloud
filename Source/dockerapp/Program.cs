using System;
using System.Threading;

namespace dockerapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dockerapp!");

            int n = 100;
            while (--n > 0)
            {
                Console.WriteLine("Working...");
                Thread.Sleep(1000);
            }
        }

    }
}
