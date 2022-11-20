using MyLibrary;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("UnitTestProject")]

namespace HelloStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyLibrary.MyLib referencedLib = new MyLibrary.MyLib();

            var res = referencedLib.Sum(11, 23132);
            Console.WriteLine(referencedLib.Divide(10, 2));
            Console.WriteLine(res);

            #region Serialization
            //
            // Serialization
            //

            MyAlgorithm alg1 = new MyAlgorithm();

            for (int i = 0; i < 10; i++)
            {
                double result = alg1.Calculate(i);

                Console.WriteLine($"Result = {result}");

                Thread.Sleep(500);
            }

            //
            // We serialize (save) the algorithm state to file.
            SampleSerializer ser = new SampleSerializer();
            ser.Serialize(alg1, "myalg.json");

            var alg2 = ser.Deserialize<MyAlgorithm>("myalg.json");

            for (int i = 0; i < 10; i++)
            {
                double result1 = alg1.Calculate(i);
                double result2 = alg2.Calculate(i);
          
                Console.WriteLine($"Result1 = {result1}, Result2 = {result2}");

                Thread.Sleep(500);
            }
            #endregion

            #region Derialization
            alg1.Serialize("custom.json");

            var alg3 = MyAlgorithm.Deserialize("custom.json");

            for (int i = 0; i < 10; i++)
            {
                double result1 = alg1.Calculate(i);
                double result2 = alg2.Calculate(i);
                double result3 = alg3.Calculate(i);

                Console.WriteLine($"{result1} / {result2} / {result3}");

                Thread.Sleep(500);
            }

            #endregion

            Console.WriteLine("Press any key do exit...");
            Console.ReadLine();
        }
    }
}
