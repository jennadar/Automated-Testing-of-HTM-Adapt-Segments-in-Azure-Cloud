## Implementation of UnitTest for AdaptSegments | Team_UnitTestX_CC - Azure Cloud Implementation

## Description:
The main objectives of the project are to guarantee that the Adapt Segment method funciton correctly in the HTM algorithm by creating thorough unit test cases for it. The project for Implementation of UnitTest for Adapt Segments focuses on creating a robust testing framework to ensure the correct and relaible functionality of the Adapt Segment method within the Hierarchical Temporal Memory (HTM) algorithm. Unit Testing is a crucial aspect of software development, aiming to verify that individual componenets or units of code work as intended in isolution. The Hierarchical Temporal Memory (HTM) algorithm, a computer model based on the structure and function of the neocortex in the brain, incorporates Adaptive Segments as a major component. Using adaptive segments, recurrent pattern in the input data can be reprensented in HTM and modified when fresh input is received. 

In the HTM model, an Adaptive Segment consitutes a collective of neurons intricately interlinked and activated in unison by a specific input pattern. When the HTM model encounters a novel input pattern, a meticulous comparison unfolds with the existing repertoire of Adapive Segments. This scrutiny aims to discern whether the incoming input aligns with any pre-established segments. This process is know as reinforcement learning, and it is similar to the way that the brain learns and adapts to new information.

As the Hierarchical Temporal Memory (HTM) model is exposed to more input data over time, the Adaptive Segments become more specialized and proficient at identifying the patterns in the data. This means that complex input sequences that would be difficult or impossible for traditional machine learning algorithms to recognize can be learned and detected by the HTM model. Because they enable the model to adjust over time to changes in the input data, adaptive segments are a crucial component of the HTM process. As new information is continuously added to the Adaptive Segments, the HTM model is able to identify and react to new patterns and activity sequences in the data.

This makes HTM an effective tool for application in fields like robotics, finance, and health that include anomaly detection, prediction, and classification. The testing of the AdaptSegment module or component is conducted through a specialized form of software testing known as unit testing. The primary objective of unit testing is to verify that every segment of the software code functions precisely as intended. These tests meticulously isolate individual components, be it a function, method, procedure, module, or object, to validate their accuracy and adherence to the intended functionality. The essence lies in confirming that each unit of code operates seamlessly within the broader software system.

## Software Engineering:

[MySEProject](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject)

[Implement_Unit_Tests_for_AdaptSegments_Documentation](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/Documentation%20of%20project)

[Implement_Unit_Tests_for_AdaptSegments_Readme](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/Team_UnitTestAS_README.md)

[Unit_Test_Cases](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject/UnitTests_AdaptSegments.cs)



## Cloud Project

[MyCloudProjectSample](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample)

[MyExperiment](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment)

[Experiment.cs](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment/Experiment.cs)

[MyCloudProject](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyCloudProject)


## Objectives of the project:

Our research focuses on assessing the efficacy of the SpatialPooler class, specifically within the AdaptSynapses method. To achieve this objective, we have accomplished the following milestones:
- Formulated unit test cases to evaluate the functionality of the AdaptSynapses method.
- Implement automated test orchestration in the cloud for consistent triggering, monitoring, and analysis of AdaptSegment unit tests.
- Develop a cloud-based infrastructure for comprehensive unit testing of the HTM algorithm's AdaptSegment method, ensuring scalability.
- Successfully deployed the Docker image to a cloud environment through the container registry.
- Executed the entire project within a container instance, ensuring comprehensive testing and evaluation.

## Implementation on Cloud:
In order to configure the entire project in the Azure cloud, we take the following steps:
![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Flowchart.png)

a)   **Containerization with Docker**: 

     Docker containerization is essential to the deployment in this case. It streamlines the installation of software and does away with the requirement for physical infrastructure. Deployment is streamlined via containerization, which reduces costs and time. It enables the operation of several applications in separate containers on a single hardware platform without interfering with the memory, processes, or resources of the other apps. Docker is a great tool to help accomplish this goal. It makes it possible to quickly launch apps in the settings for which they are designed, whether that is locally (with Docker for Windows) or remotely (with Microsoft Azure Container Registry and Instance service). An program is packed using Docker into a Docker image, which contains the code, runtime, system tools, and libraries required to run the application.

b)   **Azure Storage**:
     Cloud storage options from Microsoft Azure are safe, scalable, and very convenient to access from any location at any time. There are several features included in Azure Storage, such as Queue Storage, Table Storage, Blob Storage, and File Storage.

c)   **Azure Blob Storage**:
     A cloud-based object storage system called Azure Blob Storage is made to effectively store massive amounts of unstructured data. It works well for things like data analysis, backup and restoration procedures, file storage for distributed access, providing images or documents straight to web browsers, and log file management. A storage account, containers inside the storage account, and blobs inside the containers make up blob storage. These containers are connected to the storage account and operate similarly to directories. It uses a.NET format to combine the storage account and the location of the blob when creating an address to grant access to a file in Azure Data Storage.

d)   **Azure Table Storage**:
     For cloud-based structured data storage management, Azure Table Storage is the best option. In addition to storing flexible datasheets and other kinds of metadata, it accommodates data in accordance with the particular needs of diverse applications. Storage tables, entities, attributes, and storage accounts are the components of Azure Table Storage.

e)   **Azure Queue Storage**:
     Many messages can be stored using Azure Queue Storage and accessible by authenticated HTTP or HTTPS requests from any location in the world. Messages up to 64KB in size are permitted, and task and workflow management are supported. A queue can contain millions of messages, depending on the storage account capacity, which makes it ideal for building up backlogs of work that need to be processed asynchronously. These requirements are necessary to guarantee reliable data storage, effective message handling, and efficient containerization for the HTM classifier's deployment on Microsoft Azure Cloud.


## Input to the Experiment

- To initiate the experiment run, we activate it by running the queue. The message, in this instance, contains the string 'startadaptsegmentstests,' serving as the input to execute the test cases designed for the AdaptSegments methodology. 
- This approach allows for flexibility, enabling the triggering of test cases for various methodologies by passing different strings as needed.
- The class that receives the names of the input files [ExperimentRequestMessage](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/master/Source/MyCloudProjectSample/MyCloudProject.Common)and the details of the experiment defines the input for the experiment.

~~~csharp
 public interface IExerimentRequestMessage
    {
        string ExperimentId { get; set; }

        string InputFile { get; set; }

        string Name { get; set; }

        string Description { get; set; }

    }
~~~
The experiment will be started by an Azure queue message in the 'unittestxcc-trigger-queue' queue located in the storage account '''ccprojectsd''', which is also pass in the necessary files and metadata. The code sample that follows displays the input data that was utilize in the experiment. The code sample that follows displays the input data that was utilized in the experiment:

~~~json
{
    "ExperimentId": "2023",
    "InputFile":"startadaptsegmentstests",
    "Name": "Unit Tests for Adapt Segments",
    "Description": "Test the functionality of the AdaptSegments method and achieve code coverage"
}
~~~
- ExperimentId : 2023 - is unique identifier for the experiment.
- InputFile: adaptsegmentstests  - specifies the name or identifier of the input file or data that the experiment will use.
- Name : This field represent the name or label for the Unit Tests for Adapt Segments experiment.
- Description : Test the functionality of the AdaptSegments method and achieve code coverage.

## Blob container registry

- 'adaptsegmentunittest-teamunittesrxcc': saving output written into the file in Excel format.
     - The file inside are result from the experiment, for example:
          - *Test_data_20240109224957260.xlsx* Excel file.

## Output of the Experiment

The output of the experiment will be a result object of class [ExperimentResult](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment/ExperimentResult.cs)
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

Following that, this data is sent and kept in the Azure table storage.
The test name, starting and updated synapse permanence values, and counts of processed synapses and segments are all included in the experiment's output.
The screenshot of an Excel-formatted blob container file from the portal or ASX (Azure Storage Explorer) is shown below.
<img width="930" alt="image" src="https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Output.png">

Explaination of the columns that are displayed in the Excel sheet:

1. **Test Name**: Represents the test or experiment name or identification that produced the data in the output table. It assists in determining which scenario or test case yielded the particular outcomes.
2. **Input Perm Value**: Represent a synapse's initial persistence value or another test-related input parameter. It might represent the initial persistence value of a synapse prior to the application of the AdaptSegment technique.
3. **Updated Perm Value**: After the AdaptSegment technique has been used, indicate the synapse's final persistence value. It stands for the revised or altered permanence value.
4. **Synampse Count**: Represents the quantity of synapses that, during the course of the test or experiment, were processed or impacted by the AdaptSegment technique.
5. **Segment Count**: Indicate the quantity of segments or distal dendrites that underwent processing or were impacted by the AdaptSegment technique during the course of the test or investigation.
6. **Test Results**: Gives the status of the Test case run as 'Passed' or 'Failed'
7. **Comments**: Provides a brief summary of the scenario for every test case.

## AdaptSegment Method
An essential part of the Hierarchical Temporal Memory (HTM) algorithm, which is a part of the Temporal Memory class, is the AdaptSegment method. According to the activity of presynaptic cells in the preceding cycle, this technique is in charge of updating synapse permanence values in a given distal dendrite segment. Various parameters are accepted by the procedure:
. **conn**: An instance of the Connections class, facilitating operations related to synapses and dendrites.
. **segment**: A DistalDendrite object representing the segment to be adapted.
. **preActiveCell**: Presynaptic cell activity is determined by assembling a set of Cell objects that correspond to active cells from the preceding cycle.
. **permanenceIncrement**: A binary value that, in the event that the presynaptic cell was activated, would represent the rise in permanence.
. **premanenceDecrement**: A double value that indicates how much a synapse's permanence value should be lowered if its presynaptic cell was dormant during the preceding cycle.

Synapses that need to be destroyed because their permanence value has fallen below a predetermined threshold are first initialized in an empty list named synapsesToDestroy. Next, a foreach loop is used to traverse through each synapses in the specified segment object. It retrieves the current persistence value for every synapse and puts it in a permanence local variable. Next, the Contains method of the prevActiveCells collection is used to determine whether the presynaptic cell of the synapse was active in the preceding cycle. The approach increases the permanence value by permanenceIncrement if the presynaptic cell was active and decreases the permanence value by permanenceDecrement if it was not. 

A list called synapsesToDestroy is initialized by the procedure to hold synapses that need to be destroyed because their permanence has fallen below a predetermined level. It updates persistence based on presynaptic cell activity as it iterates through synapses in the supplied segment. Following the update, it verifies if persistence is between 0 and 1 and determines if it is below an established threshold (EPSILON). Synapses that satisfy this requirement are designated for elimination.

Unless the maximum limit is reached, in which case the least recently used segment is eliminated, the CreateDistalSegment function creates a new distal dendritic segment for a cell. DestroyDistalDendrite dealslocates resources and eliminates a certain segment and its synapses. NumSegments provides the total number of distal dendritic segments for a given cell or for all cells, whereas LeastRecentlyUsedSegment indicates the segment that has been utilized the least recently for a given cell.

## Workflow

- The distal dendrite segment, which is the first segment we examine, is made up of a series of synapses that link to different presynaptic cells.
![Workflow-1](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Workflow-1.png)
- It's possible that certain presynaptic cells were active while others were quiescent during the preceding cycle. A list of the active cells is passed before us.AdaptSegment approach to ActiveCells technique.
![Workflow-2](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Workflow-2.png)
- We determine whether the presynaptic cell of each synapse in the segment was activated during the preceding cycle. If so, we add the permanenceIncrement value to the synapse's permanence value. We decrement the persistence value by the permanenceDecrement value if it was not active. We maintain the persistence value between 0 and 1, respectively, as the lowest and maximum boundaries. 
![Workflow-3](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Workflow-3.png)
- We eliminate a synapse and delete it from the segment if its permanence value is less than the EPSILON value. Since synapse S1's permanence value in this case is less than EPSILON, we add it to the list of synapses that should be destroyed. 
![Workflow-4](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Workflow-4.png)
- Lastly, we also destroy the section if there are no synapses remaining in it.
-![Workflow-5](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Workflow-5.png)
- Through the strengthening of connections between active cells and the pruning of weak connections, this process aids in the HTM network's ability to learn and adapt over time.


## Implementation Method
1. Execute within [Experiment.cs](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/master/Source/MyCloudProjectSample/MyExperiment/Experiment.cs)
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
                /// <summary>
                /// The below codes captures various data related to the test case, such as input and updated permanence values, test case results, and comments.
                /// It stores this test case data in a tuple named res and then adds this tuple to a list named AdaptSegmentsList.
                /// The code generates a string representation of the test case data and stores it in the res.Perm_Array variable.
                /// Finally, it appears to write the test output data (stored in AdaptSegmentsList) to an Excel file using the excelreport.WriteTestOutputDataToExcel method.
                /// </summary>


                ///******************************************************** TestCase ***************************************************************//
                for (int runIndex = 1; runIndex < 11; runIndex++)
                {
                    PermDataList = TestAdaptSegment_IfPresynapticCellWasNotActive();
                    res.ExperimentName = "TestAdaptSegment_IfPresynapticCellWasNotActive";
                    res.InputPermList = PermDataList.Item1;
                    res.UpdatedPermList = PermDataList.Item2;
                    res.TestCaseResults = PermDataList.Item3;
                    res.Comments = PermDataList.Item4;
                    AdaptSegmentsList.Add(Tuple.Create(""+runIndex.ToString(), res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                    res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                    $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                    Console.WriteLine(res.Perm_Array);

                    // Now you have PermValueList
                    res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);
                  
                }
            }
        }
~~~

Here, a variety of variables and objects are declared and initialized for usage in the experiment later on, including lists and objects connected to Excel. It then runs a particular set of unit tests associated with the "AdaptSegments" method if the inputFile parameter equals "startadaptsegmentstests." The results are stored in PermDataList and a unit test method named TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive is called. Additionally, it adds the test results to a number of properties on the ExperimentResult object. Lastly, it writes the test output data to an Excel file using an ExcelWriter object.

2. The uploading of experiment results, including Excel data, to a Blob Storage container is done by the Upload [ExperimentResult](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment/AzureStorageProvider.cs) function.
~~~csharp
public async Task UploadExperimentResult(IExperimentResult result)
        {
            var experimentLabel = result.ExperimentName;

            BlobServiceClient blobServiceClient = new BlobServiceClient(this.config.StorageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(this.config.ResultContainer);

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
        }
~~~

## Azure
1. The resource group is called CCProjectR.
![Azure-page](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Azure-page.png)
2. Account for Storage ccprojectsd
3. Registry for Containers CCProjectC
4. Container Instance projectx
![Azure-p2](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Azure-p2.png)
5. Docker Image ccprojectc.azurecr.io/projectxmycloudproject:latest
![Azure-p3](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Azure-p3.png)

## Steps to run the experiment

## Step 1: Message input from the queue portal

## How to add message:

Azure portal > Home > ccprojectsd | Queues > project-x-trigger-queue> Add message
![image](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Queue%20trigger.png)

The experiment can be run by starting the 'projectx' container instance which can be found here.
![image1]()

Once the queue is given to the experiment, the queue message is displayed in the logs of the container instance and the experiment starts running. Each of the Unit Tests will be run and generates the excel report.
![image2](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/log-image.png)

## Step 2: Experiment Result Output Container
After the experiments are completed, the result file is stored in Azure storage blob containers
![image4](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/storage-output.png)
The expected result is uploaded in the Excel format to the Blob container 'project-x-result-files'. Here we have consolidated the results of all the testcases executed and stored it in is a single Excel file. For example:'Test_data_20240109224957260.xlsx'. which is uploaded into the blob container 'project-x-result-files'(https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Images/Output.png)
