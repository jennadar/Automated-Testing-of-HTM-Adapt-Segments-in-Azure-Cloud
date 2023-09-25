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
    }
}


/*
 
{
    "ExperimentId": "2023",
    "InputFile":"startadaptsegmentstests",
    "Name": "Unit Tests for Adapt Segments",
    "Description": "Test the functionality of the AdaptSegments method and achieve code coverage"
}

 {
    "ExperimentId": "2023",
"TestCases": [
        {
            "InputFile": "Testcase1",
            "Name": "sample",
            "Description": "None"
        },
        {
            "InputFile": "Testcase2",
            "Name": "sample1",
            "Description": "None"
        },
    ]
}
 
 {
    "ExperimentId": "2023",
"TestCases" = new List<ExerimentRequestMessage.TestCase>
        {
            "InputFile": "Testcase1",
            "Name": "sample",
            "Description": "None"
        },
        {
            "InputFile": "Testcase2",
            "Name": "sample1",
            "Description": "None"
        }
    ]
}
 */

