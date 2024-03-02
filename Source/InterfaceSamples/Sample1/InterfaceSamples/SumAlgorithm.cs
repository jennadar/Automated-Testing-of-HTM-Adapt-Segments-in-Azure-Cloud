using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSamples
{
    public class SumAlgorithm : IMyMLAlgorithm
    {
        private double sum;

        public SumAlgorithm()
        {
            this.sum = 0;
        }

        public virtual void SomeVirtualMethod()
        { 
        
        }


        public object SomeOtherMethod()
        {
            return this.sum;
        }

        public object GetResult()
        {
            return this.sum;
        }

        public void Train(double[] data)
        {
            foreach (var number in data)
            {
                this.sum += number;
            }
        }

        public override string ToString()
        {
            return$"{base.ToString()}\t {this.sum}";
        }
    }
}
