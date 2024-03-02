using System;
using System.Diagnostics;
using University.CalculatorLibrary;

namespace helloworldapp
{
    /// <summary>
    /// Here is my comment.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This is the start method when the program starts.
        /// </summary>
        /// <param name="args">The command line args entered on the start of application.</param>
        static void Main(string[] args)
        {
            
            // Hello world.
            Console.WriteLine("Hello World best studends!");

            foreach (var commandLineArg in args)
            {
                Console.WriteLine(commandLineArg);
            }

            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.WriteLine("Please enter something...");

            Console.ForegroundColor = ConsoleColor.Cyan;

            var userInput = Console.ReadLine();

            Console.WriteLine($"Hi, the user has entered the input: {userInput}");

            Console.ForegroundColor = defaultColor;
                 
            Console.WriteLine("Press any key to exit...");

            int[] intNumbers = new int[] { 1,2,3,4,5,6,7, -122 };

            double[] doubleNumbers = new double[] { 1.4, 2.2, 3.5, 4.1, 5.0, 6.0, -7.1 };

            CalculatorApi cal = new();

            var intRes = cal.Sum(intNumbers);

            var floatRes = cal.Sum(doubleNumbers);

            Console.WriteLine($"The result of a number of integers is: {intRes}");

            Console.WriteLine($"The result of a number of doubles is: {floatRes}");

            Console.ReadLine();
        }
    }
}
