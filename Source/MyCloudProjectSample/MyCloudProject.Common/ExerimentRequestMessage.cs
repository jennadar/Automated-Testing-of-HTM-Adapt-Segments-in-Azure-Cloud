using System;
using System.Collections.Generic;
using System.Text;

namespace MyCloudProject.Common
{
    /// <summary>
    /// Enter all the input information based on this interface.
    /// Defines the contract for the message request that will run your experiment.
    /// </summary>
    public interface IExerimentRequestMessage
    {
        string ExperimentId { get; set; }

        string InputFile { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        // ********************************************************Additional Required Inputs***************************************************************//
        public string testFile { get; set; }


    }
}
