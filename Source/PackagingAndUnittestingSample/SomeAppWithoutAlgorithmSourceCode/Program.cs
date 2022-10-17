// See class Program
using My.Common;
using MyAlgorithm;
using MyAverageAlgorithm;

namespace SomeAppWithoutAlgorithmSourceCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SumAlgorithm sumAlg = new SumAlgorithm();

            double[] data = new double[] { 1.0, 2.0, 234.444, 332.3233, 32323.32323 };

            List<IAlgorithm> algorithms = new List<IAlgorithm>();

            algorithms.Add(new SumAlgorithm("Sum Algorithm 1"));
            algorithms.Add(new AvgAlgorithm("Average Algorithm 1"));
            algorithms.Add(new SumAlgorithm("Sum Algorithm 2"));
            algorithms.Add(new SumAlgorithm("Sum Algorithm 3"));
            algorithms.Add(new SumAlgorithm("Sum Algorithm 5"));

            foreach (IAlgorithm alg in algorithms)
            {
                alg.Train(data);

                Console.WriteLine($"Result of the algorithm {alg.Name} is: {alg.GetResult()}");
            }

            Console.WriteLine("Press any key to exit.");

            Console.Read();
        }
    }
}