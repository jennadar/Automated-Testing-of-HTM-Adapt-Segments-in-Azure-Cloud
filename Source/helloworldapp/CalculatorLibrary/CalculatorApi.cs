using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.CalculatorLibrary
{
    /// <summary>
    /// This is the API example that demonstrates how to build an API.
    /// </summary>
    public class CalculatorApi
    {
        /// <summary>
        /// Calculates the sum of all numbers specified in the input argument <see cref="numbers"/>.
        /// </summary>
        /// <param name="numbers">List of numbers ot calculate the sum.</param>
        /// <returns>The sum of all numbers specified in the argument.</returns>
        public int Sum(int[] numbers)
        {
            int sum = 0;

            //
            // Step through all elements of the array of numbers.
            foreach (var num in numbers)
            {
                sum += num;
            }

            return sum;
        }

        /// <summary>
        /// Calculates the sum of all numbers specified in the input argument <see cref="numbers"/>.
        /// </summary>
        /// <param name="numbers">List of numbers ot calculate the sum.</param>
        /// <returns>The sum of all numbers specified in the argument.</returns>
        public double Sum(double[] numbers)
        {
            double sum = 0;

            //
            // Step through all elements of the array of numbers.
            foreach (var num in numbers)
            {
                sum += num;
            }

            return sum;
        }
    }
}