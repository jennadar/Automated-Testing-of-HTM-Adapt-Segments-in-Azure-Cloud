//*********************************************************** Synchronous Programming *************************************************************************************

//using System.Diagnostics;
//Console.WriteLine("*******************************************************************");
//Console.WriteLine("                  Today's Work Schedule");
//Console.WriteLine("*******************************************************************");



//var sw = new Stopwatch(); //timer
//sw.Start();



//// Methods

//#region sequentially
//GeneralMeeting();
//Presentation();
//AnsweringMail();
//PaperWork();
//#endregion

//sw.Stop();
//Console.WriteLine($"Time Elapsed  : {sw.ElapsedMilliseconds}  ms");

//void GeneralMeeting()

//{
//    Thread.Sleep(3000);
//    Console.WriteLine("GeneralMeeting is Done");
//}


//void Presentation()

//{

//    Thread.Sleep(3000);
//    Console.WriteLine("Presentation is Done");

//}

//void AnsweringMail()

//{

//    Thread.Sleep(5000);
//    Console.WriteLine("Answering to Mail is Done");

//}

//void PaperWork()

//{
//    Thread.Sleep(5000);
//    Console.WriteLine("PaperWork is Done");

//}

//**************************************************************************************************************************************************************************





//******************************************Asynchronous Programming  (Task Await Async) *************************************************************************************

//using System.Diagnostics;
//Console.WriteLine("*******************************************************************");
//Console.WriteLine("                  Today's Work Schedule");
//Console.WriteLine("*******************************************************************");


//WorkingTask();

//Console.ReadLine();


//Methods
//void WorkingTask()
//{

//    var sw = new Stopwatch(); //timer
//    sw.Start();


//    #region asynchronously
//    var task_1 = GeneralMeeting();
//    var task_2 = Presentation();
//    var task_3 = AnsweringMail();
//    var task_4 = PaperWork();
//    #endregion

//    Task.WaitAll(task_1, task_2, task_3, task_4);

//    sw.Stop();
//    Console.WriteLine($"Time Elapsed  : {sw.ElapsedMilliseconds}  ms");
//}


//async Task GeneralMeeting()

//{
//    await Task.Run(() =>
//        {
//            Thread.Sleep(3000);
//            Console.WriteLine("GeneralMeeting is Done");
//        });
//}


//async Task Presentation()
//{
//    await Task.Run(() =>
//    {

//        Thread.Sleep(3000);
//        Console.WriteLine("Presentation is Done");
//    });
//}


//async Task AnsweringMail()
//{
//    await Task.Run(() =>
//    {

//        Thread.Sleep(5000);
//        Console.WriteLine("Answering to Mail is Done");
//    });
//}


//async Task PaperWork()
//{
//    await Task.Run(() =>
//    {
//        Thread.Sleep(5000);
//        Console.WriteLine("PaperWork is Done");
//    });
//}

//*************************************************************************************************************************************************************************




//****************************************************Execute all tasks sequentianally  (Single Thread) **********************************************************************

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ThreadingSample
//{
//    class Program
//    {
//        static int numThreads = 100;

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Press any Key to start.");
//            Console.ReadKey();

//            Stopwatch sw = new Stopwatch();
//            sw.Start();

//            ParallelSamples sample = new ParallelSamples();

//            // 1. Executes all tasks sequentianally
//            sample.StartSequenced(numThreads, WorkerFunction);

//            // 2.  Executes with spaning of every worker on a single thread.
//            //sample.StartMultithreadedNative(numThreads, WorkerFunction);

//            // 3
//            //sample.StartMultithreadedNativeV2(numThreads, WorkerFunction);

//            // 4.
//            //sample.StartWithTpl(numThreads, WorkerFunction);

//            // 5.
//            //sample.StartWithTaskAwaitAsync(numThreads, WorkerFunctionAsync);

//            // 6.
//            //sample.StartWithTaskAwaitAsync2(numThreads, WorkerFunctionAsync).Wait();


//            sw.Stop();

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

//            Console.ReadLine();

//            //int r = AddAsync(1, 2).Result;

//            //var result = await AddAsync(1, 2);

//            //await DoSomething();
//        }

//        private static void WorkerFunction(object onFinishDelegate)
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;

//            Console.WriteLine($"Started thread: {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

//            double r = 202020203030442;
//            for (int i = 0; i < 1500000; i++)
//            {
//                r = r * 1.94536;
//            }

//            if (onFinishDelegate != null)
//            {
//                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
//            }

//            Console.ForegroundColor = ConsoleColor.Blue;

//            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
//        }


//        private static Task WorkerFunctionAsync(object onFinishDelegate)
//        {
//            return Task.Run(() =>
//            {
//                WorkerFunction(onFinishDelegate);
//            });
//        }

//        public static Task<int> AddAsync(int i, int j)
//        {
//            var result = Task<int>.Run(() =>
//            {
//                return i + j;
//            });

//            return result;
//        }

//        public static async Task DoSomething()
//        {
//            await new Task(() =>
//            {
//                Task.Delay(5000).Wait();
//            });

//            await Task.Run(() =>
//            {
//                Task.Delay(5000).Wait();
//            });
//        }
//    }

//}



//*************************************************************************************************************************************************************************






//****************************************************Execute all tasks parallely  (Multi Thread) **********************************************************************


//using Parallel_Function;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ThreadingSample
//{
//    class Program
//    {
//        static int numThreads = 100;

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Press any Key to start.");
//            Console.ReadKey();

//            Stopwatch sw = new Stopwatch();
//            sw.Start();

//            //ParallelSamples sample = new ParallelSamples();

//            new MultiThreadApp();

//            // 1. Executes all tasks sequentianally
//            //sample.StartSequenced(numThreads, WorkerFunction);

//            // 2.  Executes with spaning of every worker on a single thread.
//            //sample.StartMultithreadedNative(numThreads, WorkerFunction);

//            // 3
//            //sample.StartMultithreadedNativeV2(numThreads, WorkerFunction);

//            // 4.
//            //sample.StartWithTpl(numThreads, WorkerFunction);

//            // 5.
//            //sample.StartWithTaskAwaitAsync(numThreads, WorkerFunctionAsync);

//            // 6.
//            //sample.StartWithTaskAwaitAsync2(numThreads, WorkerFunctionAsync).Wait();


//            sw.Stop();

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

//            Console.ReadLine();

//            //int r = AddAsync(1, 2).Result;

//            //var result = await AddAsync(1, 2);

//            //await DoSomething();
//        }

//        private static void WorkerFunction(object onFinishDelegate)
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;

//            Console.WriteLine($"Started thread: {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

//            double r = 202020203030442;
//            for (int i = 0; i < 1500000; i++)
//            {
//                r = r * 1.94536;
//            }

//            if (onFinishDelegate != null)
//            {
//                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
//            }

//            Console.ForegroundColor = ConsoleColor.Blue;

//            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
//        }


//        private static Task WorkerFunctionAsync(object onFinishDelegate)
//        {
//            return Task.Run(() =>
//            {
//                WorkerFunction(onFinishDelegate);
//            });
//        }

//        public static Task<int> AddAsync(int i, int j)
//        {
//            var result = Task<int>.Run(() =>
//            {
//                return i + j;
//            });

//            return result;
//        }

//        public static async Task DoSomething()
//        {
//            await new Task(() =>
//            {
//                Task.Delay(5000).Wait();
//            });

//            await Task.Run(() =>
//            {
//                Task.Delay(5000).Wait();
//            });
//        }
//    }

//}



//*************************************************************************************************************************************************************************







//**************************************************************************** Async Await ********************************************************************************


//using Parallel_Function;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ThreadingSample
//{
//    class Program
//    {
//        static int numThreads = 100;

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Press any Key to start.");
//            Console.ReadKey();

//            Stopwatch sw = new Stopwatch();
//            sw.Start();



//            new AsyncAwaitWaitAll();
//            //ParallelSamples sample = new ParallelSamples();

//            //new MultiThreadApp();

//            // 1. Executes all tasks sequentianally
//            //sample.StartSequenced(numThreads, WorkerFunction);

//            // 2.  Executes with spaning of every worker on a single thread.
//            //sample.StartMultithreadedNative(numThreads, WorkerFunction);

//            // 3
//            //sample.StartMultithreadedNativeV2(numThreads, WorkerFunction);

//            // 4.
//            //sample.StartWithTpl(numThreads, WorkerFunction);

//            // 5.
//            //sample.StartWithTaskAwaitAsync(numThreads, WorkerFunctionAsync);

//            // 6.
//            //sample.StartWithTaskAwaitAsync2(numThreads, WorkerFunctionAsync).Wait();


//            sw.Stop();

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

//            Console.ReadLine();

//            //int r = AddAsync(1, 2).Result;

//            //var result = await AddAsync(1, 2);

//            //await DoSomething();
//        }

//        private static void WorkerFunction(object onFinishDelegate)
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;

//            Console.WriteLine($"Started thread: {Thread.CurrentThread.Name} - {Thread.CurrentThread.ManagedThreadId}");

//            double r = 202020203030442;
//            for (int i = 0; i < 35000000; i++)
//            {
//                r = r * 1.94536;
//            }

//            if (onFinishDelegate != null)
//            {
//                ((Action<string>)onFinishDelegate)(Thread.CurrentThread.Name);
//            }

//            Console.ForegroundColor = ConsoleColor.Blue;

//            Console.WriteLine("Stopped thread: {0}", Thread.CurrentThread.Name);
//        }


//        private static Task WorkerFunctionAsync(object onFinishDelegate)
//        {
//            return Task.Run(() => {
//                WorkerFunction(onFinishDelegate);
//            });
//        }

//        public static Task<int> AddAsync(int i, int j)
//        {
//            var result = Task<int>.Run(() =>
//            {
//                return i + j;
//            });

//            return result;
//        }

//        public static async Task DoSomething()
//        {
//            await new Task(() =>
//            {
//                Task.Delay(5000).Wait();
//            });

//            await Task.Run(() =>
//            {
//                Task.Delay(5000).Wait();
//            });
//        }
//    }

//}



//***********************************************************Parallel Task - TPL**************************************************************************************************************



using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Console.WriteLine("Press any Key to start.");
            Console.ReadKey();
            //Console.ReadLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            ParallelSamples nt = new ParallelSamples();

            // Executes all tasks sequentianally
            //nt.StartSequenced(numThreads, workerFunction);

            // Executes with spaning of every worker on a single thread.
            //nt.StartMultithreadedNative(numThreads, workerFunction);

            //nt.StartMultithreadedNativeV2(numThreads, workerFunction);

            nt.StartWithTpl(numThreads, workerFunction);
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
            for (int i = 0; i < 1500000; i++)
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
    }

}

