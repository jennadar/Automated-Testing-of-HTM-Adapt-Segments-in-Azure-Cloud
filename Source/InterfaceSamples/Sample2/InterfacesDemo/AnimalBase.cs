using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDemo
{
    public abstract class AnimalBase
    {
        #region Properties and Fields

        public int SomeProperty { get; set; }
      
        private int someField;
        #endregion

        #region Constructors and Initialization


        internal AnimalBase() : this(1)
        {

        }

        internal AnimalBase(string name) : this(0, name)
        {
        }

        internal AnimalBase(int age) : this(age, null)
        {
        }

        internal AnimalBase(int age, string name)
        {
            this.Name = name;
            this.Age = age;
        }
        #endregion

        #region public methods

        public abstract void YouMustImplementMe();
        
        public virtual void TellMeAboutYou()
        {
            Console.WriteLine("I'm an animal");
        }

        public void SetSomeField(int value)
        {
            this.SomeProperty = value * 2;
            this.someField = value;
        }

        public int GetSomeField()
        {
            return someField;
        }

        #endregion

        #region Internal Methods
        internal int Age { get; set; }

        internal string Name { get; set; }

        internal void PrintName()
        {
            Console.WriteLine(this.Name);
        }
        #endregion

    }
}
