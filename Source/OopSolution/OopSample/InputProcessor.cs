using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class InputProcessor : IInputProcessor
    {
        public InputProcessor()
        {

        }
        private void PrivateMethod()
        {

        }

        internal void InteranlMethod()
        {

        }

        protected void ProtectedMethod()
        {

        }

        public static void StaticMethod()
        {

        }
        public List<Animal> Process()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                Console.WriteLine("Please enter the name of the animal");
                string name = Console.ReadLine()!;

                Console.WriteLine("Please enter the kind/type of the animal");
                string kind = Console.ReadLine()!;

                Console.WriteLine("Please enter the number of legs of the animal");
                int numLegs = 4;
                string numOffLegs = Console.ReadLine()!;
                int.TryParse(numOffLegs, out numLegs);

                Animal animal;

                if (kind == "bird")
                {

                    Console.WriteLine("Please enter the number of wings of the bird");
                    int numWings = 4;
                    string numOffwings = Console.ReadLine()!;
                    int.TryParse(numOffwings, out numWings);

                    animal = new Bird(animals.Count + 1, name, numLegs, numWings);
                }
                else
                {
                    animal = new Animal(animals.Count + 1, name, kind, numLegs);
                }

                animals.Add(animal);

                Console.WriteLine("Please enter 'n' for next animal or 'e' for exit.");
                var userRes = Console.ReadLine()!;
                if (userRes == "e" || userRes == "exit")
                    break;
            }

            return animals;
        }


    }
}
