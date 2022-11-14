using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class Bird : Animal
    {
        public int Wings { get; set; }

        public Bird(int id, string name, int legs, int wings) : base(id, name, "bird", legs)
        {
            this.Wings = wings;
        }
    }
}
