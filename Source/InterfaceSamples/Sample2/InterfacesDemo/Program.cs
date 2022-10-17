using SampleLib;
using System;

namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var someCat = new Cat("Hans");
            var someDog = new Dog();

            someCat.TellMeAboutYou();
            someDog.TellMeAboutYou();

            Console.WriteLine(someCat.ToString());
            Console.WriteLine(someDog);

            someCat.PrintName();
            someDog.PrintName();
            incrementAnimaleAge(someCat);
            incrementAnimaleAge(someDog);
            MoveAnimal(someCat);
            MoveAnimal(someDog);
            FeedAnimal(someCat);
            FeedAnimal(someDog);
            var a = new SampleClass();
           
        }

        private static void MoveAnimal(IAnimal animal)
        {
            animal.Move();
        }

        private static void FeedAnimal(IAnimal animal)
        {
            animal.Eat();
        }


        private static void incrementAnimaleAge(AnimalBase animal)
        {
            animal.Age++;
        }
    }
}
