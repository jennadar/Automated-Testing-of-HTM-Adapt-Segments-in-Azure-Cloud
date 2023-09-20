# ML22/23-7 Implement UnitTests for AdaptSegments - Azure Cloud Implementation 

# Description

The primary goals of the project involve developing a comprehensive unit test cases for the AdaptSegment method, to ensure its correct functionality in the HTM algorithm and also achieving full code coverage by utilizing the Code Coverage tool.
The Hierarchical Temporal Memory (HTM) algorithm, a computer model based on the structure and function of the neocortex in the brain, includes Adaptive Segments as a crucial component. Using adaptive segments, repeating patterns in the input data can be represented in HTM and updated as fresh input is received.  

An Adaptive Segment is a group of neurons in the HTM model that are activated together by a particular pattern of input. When a new pattern of input is presented to the HTM model, it is compared to the existing Adaptive Segments to determine whether it matches any of them. If the input matches an existing Adaptive Segment, the strength of the connections between the neurons in the segment is increased, and the segment is updated to reflect the new input. This process is known as reinforcement learning, and it is similar to the way that the brain learns and adapts to new information.

The Adaptive Segments grow more specialized and effective at spotting patterns in the data over time as the HTM model is exposed to more input data. Because of this, the HTM model can learn and detect intricate input sequences that would be challenging or impossible for conventional machine learning algorithms to recognize.

Adaptive Segments are an important feature of the HTM algorithm because they allow the model to adapt to changes in the input data over time. By continually updating the Adaptive Segments based on new input, the HTM model can learn to recognize new patterns and sequences of activity in the data and respond appropriately. This makes HTM a powerful tool for applications such as anomaly detection, prediction, and classification in areas such as finance, medicine, and robotics. AdaptSegment module or component is tested as part of a type of software testing known as unit testing. The goal is to confirm that each piece of software code operates as intended). Unit tests isolate a specific piece of code and validate its accuracy. A singular function, method, procedure, module, or object might be considered a unit. 


# Software Engineering Project

[MySEProject](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject)

[Implement UnitTests for AdaptSegments Documentation](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/Documentation%20of%20project)

[Implement UnitTests for AdaptSegments Readme](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/Team_UnitTestAS_README.md)

[Unit Test cases](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject/UnitTests_AdaptSegments.cs)


# Cloud Project

[MyCloudProjectSample](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS_CC/Source/MyCloudProjectSample)

[MyExperiment](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyExperiment)

[Experiment.cs](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyExperiment/Experiment.cs)

[MyCloudProject](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyCloudProject)




## Input to the Experiment experiment

Input to this experiment are from string text of the adaptsegmentstests.

The experiment input is defined in the class [ExerimentRequestMessage](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyCloudProject.Common/ExerimentRequestMessage.cs) which takes in the experiment details along with the names of the input sequences file and the testing sequences file.

~~~json
  public interface IExerimentRequestMessage
    {
        string ExperimentId { get; set; }

        string InputFile { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
~~~

An Azure queue message in the queue 'unittestascc-trigger-queue' present in the storage account ´´´ccprojectsd´´´ will trigger the experiment and will pass in the details and files required for the experiment.
Below mentioned code snippet shows the input data used for the experment
 

~~~json
{
    "ExperimentId": "2023",
    "InputFile":"adaptsegmentstests",
    "Name": "Unit Tests for Adapt Segments",
    "Description": "Test the functionality of the AdaptSegments method and achieve code coverage"
}
~~~

- ExperimentId : 2023 - is unique identifier for the experiment  
- InputFile: adaptsegmentstests  - specifies the name or identifier of the input file or data that the experiment will use.
- Name : This field represent the name or label for the experiment itself.
- Description : Test the functionality of the AdaptSegments method and achieve code coverage  

**_Describe your blob container registry:**  

what are the blob containers you used e.g.:  
- 'training_container' : for saving training dataset  
  - the file provided for training:  
  - zip, images, configs, ...  
- 'result_container' : saving output written file  
  - The file inside are result from the experiment, for example:  
  - **file Example** screenshot, file, code  


## Output to the Experiment experiment

The output will be a result object of class [ExperimentResult](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyExperiment/ExperimentResult.cs)

~~~json

public interface IExerimentRequestMessage
    {
        string ExperimentId { get; set; }
        string InputFile { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }

public class ExperimentResult : ITableEntity, IExperimentResult
    {
        public ExperimentResult(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public ExperimentResult()
        {
            // Default parameterless constructor
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string ExperimentId { get; set; }
        public string ExperimentName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public long DurationSec { get; set; }
        public string InputFileUrl { get; set; }
        public string testFileUrl { get; set; }
        public string[] OutputFiles { get; set; }
        // Your properties related to experiment.
        public float Accuracy { get; set; }
        public List<double> UpdatedPermList { get; set; }
        public List<double> InputPermList { get; set; }
        public int SynapseCount { get; set; }
        public int SegmentCount { get; set; }
        public string AdditionalInfo { get; set; }
        public String Perm_Array { get; set; }
        public byte[] excelData { get; set; }
        //public Dictionary<double, string> encodedData { get; set; }
        public string TestCaseResults { get; set; }
        public string Comments { get; set; }
    }

~~~

This information is then passed and stored in the Azure table storage.

The output of the Experiment provides information about the test name, initial and updated synapse permanence values, and counts of processed synapses and segments.
 
Below is the Screenshot of your table from the portal or ASX (Azure Storage Explorer)
 
<img width="923" alt="image" src="https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/e5b0b0ce-d8ab-4521-8597-b8997747e5c1">


Column names of the table with explanation

1. Test Name : Represents the name or identifier of the test or experiment that generated the data in the output table. It helps identify which test case or scenario produced the specific results.
2. Input Perm Value : Represent the initial permanence value of a synapse or some input parameter related to the test. It may indicate the starting value of a synapse's permanence before the AdaptSegment method is applied.
3. Updated Perm Value : Indicate the resulting permanence value of a synapse after the AdaptSegment method has been applied. It represents the updated or modified permanence value.
4. SynapseCount : Represents the count or number of synapses that were processed or affected by the AdaptSegment method within the scope of the test or experiment.
5. SegmentCount : Represent the count or number of segments or distal dendrites that were processed or affected by the AdaptSegment method within the scope of the test or experiment.

   
## Workflow 

We start with a distal dendrite segment, which consists of a set of synapses connecting to various presynaptic cells. (Fig.1)

![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/4a894a50-9781-410c-8b00-8f82a267002b) Fig.1

During the previous cycle, some of the presynaptic cells may have been active, while others may have been inactive. We pass a list of the active cells prevActiveCells to the AdaptSegment method. (Fig.2)

![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/8d842446-a797-476a-a96c-e29f95388198) Fig.2

For each synapse in the segment, we check whether its presynaptic cell was active in the previous cycle. If it was, we increment the synapse's permanence value by the permanenceIncrement value. If it was not active, we decrement the permanence value by the permanenceDecrement value. We keep the permanence value within the minimum and maximum bounds of 0 and 1 respectively. (Fig.3)

![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/18e87d36-6e2b-471d-9414-006c826d029a)  Fig.3

If the permanence value of a synapse falls below the EPSILON value, we destroy the synapse and remove it from the segment. In this example, the permanence value of synapse S1 falls below EPSILON, so we add it to a list of synapses to be destroyed. (Fig.4)

![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/384e97fc-0aa3-4982-b697-265413565e64) Fig.4

Finally, if there are no synapses left in the segment, we destroy the segment as well. (Fig.5)

![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/4c0dccfb-9ece-41f3-afd9-2de746b8815c) Fig.5

This process helps the HTM network to learn and adapt over time by strengthening connections between active cells and pruning away weak connections.

## Azure

1. The name of the resource group is CCProjectR

![MicrosoftTeams-image (2)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/305bd856-2a07-4ea3-8348-3f3ee900b564)

2.Storage Account ccprojectsd

3.Container Registry CCProjectC

4.Container Instance teamunittestascc-msl

![MicrosoftTeams-image (3)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/aeb4e4f5-4c60-4e20-9590-bb44a6de6cde)

5. Docker Image ccprojectc.azurecr.io/teamunittestasccmycloudproject:latest
![MicrosoftTeams-image (4)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/16c0ad13-c32b-4de0-a56b-4650e0591d71)

## How to run the experiment 

The experiment can be run by starting the 'teamunittestascc-msl' container instance which can be found here




















 
