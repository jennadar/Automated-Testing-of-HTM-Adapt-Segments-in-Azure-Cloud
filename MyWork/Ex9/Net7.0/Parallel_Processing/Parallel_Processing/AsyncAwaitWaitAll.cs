using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Function
{
    public class AsyncAwaitWaitAll
    {

        public int numThreads = 10;
        public AsyncAwaitWaitAll()
        {
            StartWithTaskAwaitAsync(numThreads, WorkerFunctionAsync);
        }


        public void StartWithTaskAwaitAsync(int numberofTasks, Func<object, Task> func)
        {
            List<Task> tList = new List<Task>();

            for (int i = 0; i < numberofTasks; i++)
            {
                var t = func(String.Empty);
                tList.Add(t);
            }

            //foreach (var t in tList)
            //{
            //    t.Start();
            //}

            Task.WaitAll(tList.ToArray());
        }


        private static Task WorkerFunctionAsync(object onFinishDelegate)
        {
            return Task.Run(() => {
                WorkerFunction(onFinishDelegate);
            });
        }


        private static void WorkerFunction(object onFinishDelegate)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Started thread: {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

            double r = 202020203030442;
            for (int i = 0; i < 35000000; i++)
            {
                r = r * 1.94536;
            }

            //if (onFinishDelegate != null)
            //{
            //    ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
            //}

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
        }
    }
}