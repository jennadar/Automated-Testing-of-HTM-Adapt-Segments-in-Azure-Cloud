using System;

namespace ClassInheritanceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string data = "Hello world";

            EncoderBase e0 = new EncoderBase(data);
            Console.WriteLine($"{e0.GetType().Name} - {e0.Encode()}");

            Encoder1 e1 = new Encoder1(data);
            Console.WriteLine($"{e1.GetType().Name} - {e1.Encode()}");

            Encoder2 e2 = new Encoder2(data);
            Console.WriteLine($"{e2.GetType().Name} - {e2.Encode()}");


            EncoderBase e = new Encoder1(data);
            Console.WriteLine($"{e.GetType().Name} - {e.Encode()}");

            e = new Encoder2(data);
            Console.WriteLine($"{e.GetType().Name} - {e.Encode()}");

            e = new PipelineEncoder(data);
            Console.WriteLine($"{e.GetType().Name} - {e.Encode()}");

            Console.ReadLine();
        }
    }
}
