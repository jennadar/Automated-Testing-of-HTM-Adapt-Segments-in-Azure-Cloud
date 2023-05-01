using System.Diagnostics;

Console.WriteLine("Alexa : Good Morning !!!");

var sw = new Stopwatch();
sw.Start();
MorningRoutine();
sw.Stop();

//Methods
void MorningRoutine()
{
    #region sequentially
    CookBreakfast();
    WatchTv();
    ListenToMusic();
    ThinkAboutClass();
    #endregion

    #region asynchronously
    //var task_1 = new  CookBreakfast();
    //var task_2 =  new  WatchTv();
    //var task_3 = new   ListenToMusic();
    //var task_4 = new ThinkAboutClass();
    #endregion

    //Task.WaitAll(CookBreakfast(), WatchTv(), ListenToMusic(), ThinkAboutClass());
    Console.WriteLine($"Time elapsed : {sw.ElapsedMilliseconds} ms");
}



// sequential 
void CookBreakfast() {
   Thread.Sleep(3000);
    Console.WriteLine("(Sequential run Thread T1) -> Breakfast is cooked...");
}

// async
//async Task CookBreakfast()
//{
//    await Task.Run(() =>
//    {
//        Thread.Sleep(3000);
//      Console.WriteLine(" (Async run Thread T1) -> Breakfast is cooked...");
//    });

//}

// sequential
void WatchTv()
{
   Thread.Sleep(3000);
    Console.WriteLine(" (Sequential run Thread T2) -> It's time to off the TV");
}

//async
//async Task WatchTv()
//{
//await Task.Run(() =>
//{
//  Thread.Sleep(3000);
//  Console.WriteLine(" (Async run Thread T2) -> It's time to off the TV");
// });
//}
//sequential
void ListenToMusic()
{
    Thread.Sleep(3000);
    Console.WriteLine("(Sequential run Thread T3) -> Finished listening to music...");
}

// async
//async Task ListenToMusic()
//{
//    await Task.Run(() =>
//    {
//       Thread.Sleep(3000);
//        Console.WriteLine("(Async run Thread T3) -> Finished listening to music...");
//    });
//}

// sequential
void ThinkAboutClass()
{

        Thread.Sleep(3000);
        Console.WriteLine("(Sequential run Thread T4) -> Not more thinking about class...");
}

// async
//async Task ThinkAboutClass()
//{
//    await Task.Run(() =>
//    {
//        Thread.Sleep(3000);
//        Console.WriteLine("(Async run Thread T4) -> Not more thinking about class...");
//    });
//}
