using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Function
{

    public class MultiThreadApp
    {

        public int numThreads = 10;
        private long m_FinishCounter = 0;

        public MultiThreadApp()  // Constructor
        {
            StartMultithreadedNative(numThreads, WorkerFunction);
        }

        public void StartMultithreadedNative(int threads, Action<object> func)
        {
            for (int i = 0; i < threads; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(func));
                t.Name = i.ToString();
                t.Start(new Action<string>(OnThreadFinished));
            }

            while (true)

            {
                if (Interlocked.Read(ref m_FinishCounter) == threads)
                    break;
                else
                    Thread.Sleep(500);
            }
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

            if (onFinishDelegate != null)
            {
                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
        }


        private void OnThreadFinished(string threadName)
        {
            Interlocked.Increment(ref m_FinishCounter);
        }


    }
}
