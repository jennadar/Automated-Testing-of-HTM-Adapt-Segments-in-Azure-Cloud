﻿using MyCloudProject.Common;
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
    "InputFile":"Testcase1",
    "Name": "sample",
    "Description": "None"
}
 
 */ 