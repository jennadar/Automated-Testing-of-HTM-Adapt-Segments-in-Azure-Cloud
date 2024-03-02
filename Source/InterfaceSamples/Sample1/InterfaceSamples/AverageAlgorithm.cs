using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSamples
{
    public class AverageAlgorithm : IMyMLAlgorithm
    {
        private double m_Sum;

        public AverageAlgorithm()
        {
            this.m_Sum = 0;

        }

        public object GetResult()
        {
            return this.m_Sum;
        }

        public void Train(double[] data)
        {
            foreach (var number in data)
            {
                this.m_Sum += number;
            }

            m_Sum = m_Sum / data.Length;
        }
    }
}
