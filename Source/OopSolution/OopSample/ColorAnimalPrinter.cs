using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class ColorAnimalPrinter : IAnimalPrinter
    {
     
        public ColorAnimalPrinter()
        {
    
        }
        public void Print(List<Animal> animals)
        {
            Console.ForegroundColor= ConsoleColor.Green;

            Console.WriteLine("\r\n----------------------------------\r\n");

            foreach (var animal in animals)
            {
                Console.WriteLine($"Id: {animal.Id}");
                Console.WriteLine($"Name: {animal.Name}");
                Console.WriteLine($"Kind: {animal.Kind}");
                Console.WriteLine($"Legs: {animal.Legs}");
                if (animal is Bird)
                    Console.WriteLine($"Legs: {((Bird)animal).Wings}");

                Console.WriteLine();
            }
        }
    }
}
