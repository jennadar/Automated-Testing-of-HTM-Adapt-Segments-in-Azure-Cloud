using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class Animal
    {
        #region Properties

       
        public int Id { get; set; }

        public string Name { get; private set; }

        public string? Kind { get; set; }

        public int Legs { get; set; }

     

        public int SleepingHours { get; set; }


        #endregion

        #region Constructors


        public Animal(int id, string name, string kind, int legs)
        {
            this.Id = id;
            this.Kind = kind;
            this.Name = name;
            this.Legs = legs;
        }
        #endregion

        #region Methods
        public void Sleep(int numOfSleepingHours)
        {
            SleepingHours += numOfSleepingHours;
        }
        #endregion
    }
}
