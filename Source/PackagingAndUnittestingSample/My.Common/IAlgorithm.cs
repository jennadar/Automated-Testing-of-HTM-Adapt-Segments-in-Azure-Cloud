namespace My.Common
{
    /// <summary>
    /// Interface which defines how to train the model.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// The name of algorithm.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Get result of the trained model.
        /// </summary>
        /// <returns></returns>
        object GetResult();

        /// <summary>
        /// Train the model
        /// </summary>
        /// <param name="data">Trainng data</param>
        void Train(double[] data);
    }
}