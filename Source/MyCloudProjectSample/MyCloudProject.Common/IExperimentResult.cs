
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCloudProject.Common
{
    public interface IExperimentResult
    {
        string ExperimentId { get; set; }
        string ExperimentName { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime? StartTimeUtc { get; set; }
        DateTime? EndTimeUtc { get; set; }
        public string Perm_Array { get; set; }
        public byte[] excelData { get; set; }
        public class TestResults
        {
            public int Input { get; set; }
            public string AdaptSegmentsList { get; set; }
        }
        public string TestCaseResults { get; set; }
        public string Comments { get; set; }

    }

}
