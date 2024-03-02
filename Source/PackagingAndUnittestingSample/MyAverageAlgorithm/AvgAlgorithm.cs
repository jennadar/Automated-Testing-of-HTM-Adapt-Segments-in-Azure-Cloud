using My.Common;

namespace MyAverageAlgorithm
{
    public class AvgAlgorithm : IAlgorithm
    {
        private double m_Average;

        private string name;

        public string Name { get => name; }

        public AvgAlgorithm(string name = "Set some name")
        {
            this.name = name;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public object GetResult()
        {
            return this.m_Average;
        }


        /// <summary>
        /// ???
        /// </summary>
        /// <param name="data"></param>
        public void Train(double[] data)
        {
            double sum = 0.0;

            foreach (var number in data)
            {
                sum += number;
            }

            m_Average = sum / data.Length;
        }
    }
}


