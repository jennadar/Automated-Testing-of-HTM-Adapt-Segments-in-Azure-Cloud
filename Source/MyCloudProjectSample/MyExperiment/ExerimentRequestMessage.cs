using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyExperiment
{
    internal class ExerimentRequestMessage : IExerimentRequestMessage
    {
        public string ExperimentId { get; set; }
        public string InputFile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string testFile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public string testFile { get; set; }
    }
}


/*
 
 {
    "ExperimentId": "2023",
    "InputFile":"Testcase1",
    "Name": "sample",
    "Description": "None"
}
 
 */



/*
 
 {
    "ExperimentId": "ML22/23-7",
    "InputFile":"InputData.txt",
    "Name": "PermanenceStrengthening",
    "Description": "Predict the Cell State",
    "testFile": "testingData.txt"

}
 
 */