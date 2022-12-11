using Common;
using System;

namespace MyLibrary
{
    public class MyLib : ICalLibrary
    {
        /// <summary>
        /// Sum between operand1 and operand2.
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns></returns>
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public double Divide(int a, int b)
        {
            return (double)a / (double)b;
        }

        public double Multiple(int a, int b)
        {
            return a * b;
        }

        public double Substract(int a, int b)
        {
            return a - b;
        }
    }
}
