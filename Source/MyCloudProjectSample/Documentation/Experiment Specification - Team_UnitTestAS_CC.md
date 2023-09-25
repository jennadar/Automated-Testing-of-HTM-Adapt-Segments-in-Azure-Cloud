# ML22/23-7 Implement UnitTests for AdaptSegments - Azure Cloud Implementation | Team_UnitTestAS_CC

# Description

The primary goals of the project involve developing a comprehensive unit test cases for the AdaptSegment method, to ensure its correct functionality in the HTM algorithm.
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

We trigger the experiment run by passing the below queue message given as a text message. The input to this experiment is just string text 'startadaptsegmentstests' which just triggers the testcases written for the Adaptsegments methodology.
Similarly we can pass multiple strings to trigger the testcases written for different methodolgies if needed.

The experiment input is defined in the class [ExerimentRequestMessage](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyCloudProject.Common/ExerimentRequestMessage.cs) which takes in the experiment details along with the names of the input file.

~~~csharp
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
    "InputFile":"startadaptsegmentstests",
    "Name": "Unit Tests for Adapt Segments",
    "Description": "Test the functionality of the AdaptSegments method and achieve code coverage"
}
~~~

- ExperimentId : 2023 - is unique identifier for the experiment  
- InputFile: adaptsegmentstests  - specifies the name or identifier of the input file or data that the experiment will use.
- Name : This field represent the name or label for the Unit Tests for Adapt Segments experiment.
- Description : Test the functionality of the AdaptSegments method and achieve code coverage  

## blob container registry  

- 'adaptsegmentsunittests-teamas' : saving output written into the file in Excel format
  - The file inside are result from the experiment, for example:  
  - **Test_data_20230919204634939.xlsx'** Excel file.  


## Output to the Experiment experiment

The output will be a result object of class [ExperimentResult](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS_CC/Source/MyCloudProjectSample/MyExperiment/ExperimentResult.cs)

~~~csharp
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
        // Your properties related to experiment.
        public List<double> UpdatedPermList { get; set; }
        public List<double> InputPermList { get; set; }
        public int SynapseCount { get; set; }
        public int SegmentCount { get; set; }
        public String Perm_Array { get; set; }
        public byte[] excelData { get; set; }
        public string TestCaseResults { get; set; }
        public string Comments { get; set; }
    }
~~~

This information is then passed and stored in the Azure table storage.

The output of the Experiment provides information about the test name, initial and updated synapse permanence values, and counts of processed synapses and segments.
 
Below is the Screenshot of blob container file in excel format from the portal or ASX (Azure Storage Explorer)
 
<img width="923" alt="image" src="https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/e5b0b0ce-d8ab-4521-8597-b8997747e5c1">


Column names of the Excel with explanation

1. Test Name : Represents the name or identifier of the test or experiment that generated the data in the output table. It helps identify which test case or scenario produced the specific results.
2. Input Perm Value : Represent the initial permanence value of a synapse or some input parameter related to the test. It may indicate the starting value of a synapse's permanence before the AdaptSegment method is applied.
3. Updated Perm Value : Indicate the resulting permanence value of a synapse after the AdaptSegment method has been applied. It represents the updated or modified permanence value.
4. SynapseCount : Represents the count or number of synapses that were processed or affected by the AdaptSegment method within the scope of the test or experiment.
5. SegmentCount : Represent the count or number of segments or distal dendrites that were processed or affected by the AdaptSegment method within the scope of the test or experiment.
6. Test Results : Gives the status of the Test case run as 'Passed' or 'Failed'
7. Comments : Gives a brief scenario description for each test cases.


## Method : AdatSegment 

The Adapt Segment method is a part of the Temporal Memory class, which is a fundamental component of the Hierarchical Temporal Memory (HTM) algorithm. This method is responsible for updating the permanence values of synapses in a given distal dendrite segment based on whether the synapse's presynaptic cell was active in the previous cycle or not. The method takes several parameters, which are described below:

•	conn: An instance of the Connections class, which is used to perform various operations related to synapses and dendrites.
•	segment: A DistalDendrite object that represents the segment to be adapted.
•	prevActiveCells: A collection of Cell objects that represents the set of active cells in the previous cycle. These cells are used to determine whether a synapse's presynaptic cell was active or not.
•	permanenceIncrement: A double value that represents the amount by which the permanence value of a synapse should be increased if its presynaptic cell was active in the previous cycle.
•	permanenceDecrement: A double value that represents the amount by which the permanence value of a synapse should be decreased if its presynaptic cell was not active in the previous cycle.

The method first initializes an empty list called synapsesToDestroy that will be used to store synapses that need to be destroyed because their permanence value has dropped below a certain threshold. Then, it iterates through all the synapses in the given segment object using a foreach loop. For each synapse, it retrieves its current permanence value and stores it in a local variable called permanence.
The method then checks if the synapse's presynaptic cell was active in the previous cycle by using the Contains method of the prevActiveCells collection. If the presynaptic cell was active, the method increases the permanence value by permanenceIncrement; otherwise, it decreases the permanence value by permanenceDecrement. 

After updating the permanence value, the method ensures that the value is within the range of 0 to 1 by using a conditional statement. If the permanence value is less than 0, it is set to 0, and if it is greater than 1, it is set to 1. The method then checks if the permanence value is less than a predefined threshold value called EPSILON, which is a small positive number representing the minimum difference between two floating-point numbers that are considered distinct. If the permanence value is less than EPSILON, the method adds the synapse to the synapsesToDestroy list; otherwise, it updates the synapse's Permanence property with the new permanence value.

Finally, the method iterates through the synapsesToDestroy list and calls the DestroySynapse method of the Connections class to remove each synapse from the segment. If there are no synapses left in the segment, the method calls the DestroyDistalDendrite method of the Connections class to remove the segment from the dendrite.

The CreateDistalSegment function creates a new distal dendrite segment for a given cell if the maximum number of segments per cell has not been reached. If the limit has been reached, the least recently used segment is destroyed. The new segment is assigned a unique index and added to the cell's list of distal dendrites.
The DestroyDistalDendrite function removes a given distal dendrite segment and all its synapses from the cell's list of distal dendrites and destroys the synapses. The segment's index is added to a list of free indices for reuse.
The LeastRecentlyUsedSegment function returns the least recently used distal dendrite segment for a given cell. The NumSegments function returns the number of distal dendrite segments for a given cell or for all cells.


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

The experiment can be run by starting the 'teamunittestascc' container instance which can be found here

![MicrosoftTeams-image (5)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/b54837d5-c5a4-40fd-bf9c-65419a510949)

Once the experiment starts, it waits for the queue message which can be directly entered into the 'unittestascc-trigger-queue' queue storage or via the Azure Storage Explorer by using the following connection string DefaultEndpointsProtocol=https;AccountName=ccprojectsd;AccountKey=A/HxKCnv1X9riZalnZM9GRopm9Gz8MxpTavlkx1fklaGcsfxnuz8/K/3oJTkskIBYD2UqrrvqBY6+AStUCILGA==;EndpointSuffix=core.windows.net The complete configuration can be found here The sequences used for the experiment are present in the input container "adaptsegmentsunittests-teamas".

Queue Message --> Make sure to turn OFF base64 encryption before queueing the message.

![MicrosoftTeams-image (6)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/08dfb9a8-a586-4e65-b5f9-d86c5f86b644)


Once the queue is given to the experiment, the queue message is displayed in the logs of the container instance and the experiment starts running. Each of the Unit Tests will be run and generates the excel report.

![MicrosoftTeams-image (7)](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/49e89d44-c544-4ef0-bb20-e8e6debacb57)

Once the experiment is finished, the expected result is uploaded in the Excel format to the Blob container 'adaptsegmentsunittests-teamas'.

<img width="923" alt="269192242-e5b0b0ce-d8ab-4521-8597-b8997747e5c1" src="https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/assets/118343468/a386ff9d-c81d-4815-b630-d94e7fa1da5a">

Describe the Result
How many Result Files are there ? There is only one Excel file 'Test_data_202309XXXXXXXXXX.xlsx'.

What do the columns mean ?

1. Test Name : Represents the name or identifier of the test or experiment that generated the data in the output table. It helps identify which test case or scenario produced the specific results.
2. Input Perm Value : Represent the initial permanence value of a synapse or some input parameter related to the test. It may indicate the starting value of a synapse's permanence before the AdaptSegment method is applied.
3. Updated Perm Value : Indicate the resulting permanence value of a synapse after the AdaptSegment method has been applied. It represents the updated or modified permanence value.
4. SynapseCount : Represents the count or number of synapses that were processed or affected by the AdaptSegment method within the scope of the test or experiment.
5. SegmentCount : Represent the count or number of segments or distal dendrites that were processed or affected by the AdaptSegment method within the scope of the test or experiment.
6. Test Results : Gives the status of the Test case run as 'Passed' or 'Failed'
7. Comments : Gives a brief scenario description for each test cases.

## Implemented Methods

1. Run in Experiment.cs

~~~csharp
 public Task<IExperimentResult> Run(string inputFile)
        {
            // TODO read file

            // STARTING HERE WITH OUR SE EXPERIMENT i.e, UnitTest for AdaptSegments Method!!!!

            ExperimentResult res = new ExperimentResult(this.config.GroupId, null);

            res.StartTimeUtc = DateTime.UtcNow;

            // Run your experiment code here.
            Tuple<List<double>, List<double>, string, string> PermDataList = null;
            List<Tuple<string, string, List<double>, List<double>, string, string>> AdaptSegmentsList = new List<Tuple<string, string, List<double>, List<double>, string, string>>();
            Tuple<int, int, string, string> SynapseCount = null;
            List<Tuple<string, string, int, int, string, string>> SegmentCount = new List<Tuple<string, string, int, int, string, string>>();
            int index = 0;// Index to keep track of the position in the datastore array
                          // Set the LicenseContext before using the EPPlus library
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExperimentResult result = new ExperimentResult("damir", "0")
            {
                Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            };
            ExcelWriter excelreport = new ExcelWriter();

            if (inputFile == "startadaptsegmentstests")
            {
                ///******************************************************** Unit Tests By Jishnu Shivaraman ***************************************************************//
                ///******************************************************** TestCase 1 ***************************************************************//
                ///
                PermDataList = TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive();
                res.ExperimentName = "TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("1", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);
~~~

2. UploadExperimentResult

~~~csharp
public async Task UploadExperimentResult(IExperimentResult result)
        {
            var experimentLabel = result.ExperimentName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(this.config.StorageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("adaptsegmentsunittests-teamas");

            // Write encoded data to Excel file
            byte[] excelData = result.excelData;

            // Generate a unique blob name (you can customize this logic)
            string blobName = $"Test_data_{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.xlsx";

            // Upload the Excel data to the blob container
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using (MemoryStream memoryStream = new MemoryStream(excelData))
            {
                await blobClient.UploadAsync(memoryStream);
            }
~~~


















 
