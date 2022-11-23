using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class FileAnimalPrinter : IAnimalPrinter
    {
     
        public FileAnimalPrinter()
        {
    
        }
        public void Print(List<Animal> animals)
        {
            Console.ForegroundColor= ConsoleColor.Green;

            Console.WriteLine("\r\n----------------------------------\r\n");

            using (StreamWriter sw = new StreamWriter("animallog.txt"))
            {
                foreach (var animal in animals)
                {
                    sw.WriteLine($"Id: {animal.Id}");
                    sw.WriteLine($"Name: {animal.Name}");
                    sw.WriteLine($"Kind: {animal.Kind}");
                    sw.WriteLine($"Legs: {animal.Legs}");
                   
                    if (animal is Bird)
                        sw.WriteLine($"Legs: {((Bird)animal).Wings}");

                    Console.WriteLine();
                }
            }
        }
    }
}
