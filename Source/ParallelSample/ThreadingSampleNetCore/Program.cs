﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample
{
    class Program
    {
        static int numThreads = 100;

        static void Main(string[] args)
        {
            //int r = AddAsync(1, 2).Result;

            //var result = await AddAsync(1, 2);
               
            //await DoSomething();

            Console.WriteLine("Press any Key to start.");
            Console.ReadKey();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            ParallelSamples sample = new ParallelSamples();

            // 1. Executes all tasks sequentianally
            sample.StartSequenced(numThreads, workerFunction);

            // 2.  Executes with spaning of every worker on a single thread.
            // sample.StartMultithreadedNative(numThreads, workerFunction);

            // 3
            //sample.StartMultithreadedNativeV2(numThreads, workerFunction);

            // 4.
            //sample.StartWithTpl(numThreads, workerFunction);

            sw.Stop();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static void workerFunction(object onFinishDelegate)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Started thread: {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

            double r = 202020203030442;
            for (int i = 0; i < 35000000; i++)
            {
                r = r * 1.94536;
            }

            if (onFinishDelegate != null)
            {
                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
        }


        public static Task<int> AddAsync(int i, int j)
        {
            var result = Task<int>.Run(() =>
            {
                return i + j;
            });

            return result;
        }

        public static async Task DoSomething()
        {
            await new Task(() =>
            {
                Task.Delay(5000).Wait();
            });

            await Task.Run(() =>
            {
                Task.Delay(5000).Wait();
            });
        }
    }

}
