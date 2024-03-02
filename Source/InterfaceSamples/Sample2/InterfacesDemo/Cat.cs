using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDemo
{
    public class Cat : AnimalBase, IAnimal
    {
        public new string Name { get; set; }

        public Cat() : base(1)
        {
            
        }

        internal Cat(int age) : base(age, "Anna")
        {

        }

        internal Cat(string name) : base(1, name)
        {
            this.Name = name;
            base.Name = name;
        }

        internal Cat(int age, string name) : base(age, name)
        {

        }

        public void Eat()
        {
            Console.WriteLine($"{Name} eats angry.");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} lies angry on the shelf");
        }

        public override void TellMeAboutYou()
        {
            Console.WriteLine("I'm a cat");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} / {this.Name} / {this.Age}";
        }

        public override void YouMustImplementMe()
        {
            
        }
    }
}
