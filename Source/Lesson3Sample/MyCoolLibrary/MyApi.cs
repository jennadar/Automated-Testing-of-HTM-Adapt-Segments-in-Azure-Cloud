using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolLibrary
{
    /* private internal public */ 
    public class MyApi
    {
        public static double GetLength(string input)
        {
            return input.Length;
        }

        public double Divide(int a, int b)
        {
            return (double)a / (double)b;
        }

    }
}
