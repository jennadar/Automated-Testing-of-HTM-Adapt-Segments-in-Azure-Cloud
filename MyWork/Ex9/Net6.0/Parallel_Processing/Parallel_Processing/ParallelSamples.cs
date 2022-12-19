using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSample
{
    public class ParallelSamples
    {
        private long m_FinishCounter = 0;

        /// <summary>
        /// Starts all jobs in a single sequence.
        /// </summary>
        /// <param name="sequences"></param>
        /// <param name="func"></param>
        public void StartSequenced(int sequences, Action<object> func)
        {
            Thread.CurrentThread.Name = "SingleThread";

            for (int i = 0; i < sequences; i++)
            {
                func(null);
            }
        }


        /// <summary>
        /// Starts all job in parallel.
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="func"></param>
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


        private void OnThreadFinished(string threadName)
        {
            Interlocked.Increment(ref m_FinishCounter);
        }


        /// <summary>
        /// First creates all threads and the run them.
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="func"></param>
        public void StartMultithreadedNativeV2(int threads, Action<object> func)
        {
            List<Thread> tList = new List<Thread>();

            for (int i = 0; i < threads; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(func));
                thread.Name = i.ToString();
                tList.Add(thread);
            }

            foreach (var item in tList)
            {
                item.Start(new Action<string>(OnThreadFinished));
            }

            while (true)
            {
                if (Interlocked.Read(ref m_FinishCounter) == threads)
                    break;
                else
                    Thread.Sleep(500);
            }
        }


        /// <summary>
        /// Creates Tasks, then starts tasks with waiting on all of them to complete.
        /// TPL: Task Parallel Library
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="func"></param>
        public void StartWithTpl(int threads, Action<object> func)
        {
            List<Task> tList = new List<Task>();

            for (int i = 0; i < threads; i++)
            {
                var t = new Task(func, new Action<string>(OnThreadFinished));
                tList.Add(t);
            }

            foreach (var t in tList)
            {
                t.Start();
            }

            Task.WaitAll(tList.ToArray());
        }


        /// <summary>
        /// Creates and executes tasks
        /// TPL: Task Parallel Library
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="func"></param>
        public void StartWithTaskAwaitAsync(int threads, Func<object, Task> func)
        {
            List<Task> tList = new List<Task>();

            for (int i = 0; i < threads; i++)
            {
                var t = func(String.Empty);
                tList.Add(t);
            }

            foreach (var t in tList)
            {
                t.Start();
            }

            Task.WaitAll(tList.ToArray());
        }


        /// <summary>
        /// Demonstrate invocation in sequnce.
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="func"></param>
        public async Task StartWithTaskAwaitAsync2(int threads, Func<object, Task> func)
        {
            List<Task> tList = new List<Task>();

            for (int i = 0; i < threads; i++)
            {
                await func(String.Empty);
            }
        }
    }
}

