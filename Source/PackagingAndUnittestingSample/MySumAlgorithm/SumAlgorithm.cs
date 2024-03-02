using My.Common;

namespace MyAlgorithm
{
    /// <summary>
    /// todo...
    /// </summary>
    public class SumAlgorithm : IAlgorithm
    {
        private double m_Sum;

        private string name;

        public string Name { get => name; }

        public SumAlgorithm(string name = "Set some name")
        {
            this.name = name;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public object GetResult()
        {
            return this.m_Sum;
        }


        /// <summary>
        /// ???
        /// </summary>
        /// <param name="data"></param>
        public void Train(double[] data)
        {
            foreach (var number in data)
            {
                this.m_Sum += number;
            }
        }
    }
}