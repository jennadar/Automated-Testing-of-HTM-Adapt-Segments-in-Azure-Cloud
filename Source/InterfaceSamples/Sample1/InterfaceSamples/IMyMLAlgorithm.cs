using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceSamples
{
    /// <summary>
    /// Interface which defines how to train the model.
    /// </summary>
    interface IMyMLAlgorithm  
    {
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
