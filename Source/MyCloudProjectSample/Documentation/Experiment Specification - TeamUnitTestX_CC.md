## Implementation of UnitTest for AdaptSegments | Team_UnitTestX_CC - Azure Cloud Implementation

## Description:
The main objectives of the project are to guarantee that the Adapt Segment method funciton correctly in the HTM algorithm by creating thorough unit test cases for it. The project for Implementation of UnitTest for Adapt Segments focuses on creating a robust testing framework to ensure the correct and relaible functionality of the Adapt Segment method within the Hierarchical Temporal Memory (HTM) algorithm. Unit Testing is a crucial aspect of software development, aiming to verify that individual componenets or units of code work as intended in isolution. The Hierarchical Temporal Memory (HTM) algorithm, a computer model based on the structure and function of the neocortex in the brain, incorporates Adaptive Segments as a major component. Using adaptive segments, recurrent pattern in the input data can be reprensented in HTM and modified when fresh input is received. 

In the HTM model, an Adaptive Segment consitutes a collective of neurons intricately interlinked and activated in unison by a specific input pattern. When the HTM model encounters a novel input pattern, a meticulous comparison unfolds with the existing repertoire of Adapive Segments. This scrutiny aims to discern whether the incoming input aligns with any pre-established segments. This process is know as reinforcement learning, and it is similar to the way that the brain learns and adapts to new information.

As the Hierarchical Temporal Memory (HTM) model is exposed to more input data over time, the Adaptive Segments become more specialized and proficient at identifying the patterns in the data. This means that complex input sequences that would be difficult or impossible for traditional machine learning algorithms to recognize can be learned and detected by the HTM model. Because they enable the model to adjust over time to changes in the input data, adaptive segments are a crucial component of the HTM process. As new information is continuously added to the Adaptive Segments, the HTM model is able to identify and react to new patterns and activity sequences in the data.

This makes HTM an effective tool for application in fields like robotics, finance, and health that include anomaly detection, prediction, and classification. The testing of the AdaptSegment module or component is conducted through a specialized form of software testing known as unit testing. The primary objective of unit testing is to verify that every segment of the software code functions precisely as intended. These tests meticulously isolate individual components, be it a function, method, procedure, module, or object, to validate their accuracy and adherence to the intended functionality. The essence lies in confirming that each unit of code operates seamlessly within the broader software system.

## Software Engineering:

[MySEProject] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject)

[Implement_Unit_Tests_for_AdaptSegments_Documentation] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/Documentation%20of%20project)

[Implement_Unit_Tests_for_AdaptSegments_Readme] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/Team_UnitTestAS_README.md)

[Unit_Test_Cases] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestAS/SE%20Project%20-%20Team_UnitTestAS/SE_UnitTestASProject/AdaptSegment_FinalConsolidatedProject/UnitTests_AdaptSegments.cs)



## Cloud Project

- [MyCloudProjectSample] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample)

- [MyExperiment] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment)

- [Experiment.cs] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyExperiment/Experiment.cs)

- [MyCloudProject] (https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/Team_UnitTestX_CC/Source/MyCloudProjectSample/MyCloudProject)


## Objectives of the project:

Our research focuses on assessing the efficacy of the SpatialPooler class, specifically within the AdaptSynapses method. To achieve this objective, we have accomplished the following milestones:
- Formulated unit test cases to evaluate the functionality of the AdaptSynapses method, seamlessly integrated into the SpatialPoolerTests class.
- Successfully deployed the Docker image to a cloud environment through the container registry.
- Executed the entire project within a container instance, ensuring comprehensive testing and evaluation.

## Implementation on Cloud:
In order to configure the entire project in the Azure cloud, we take the following steps:

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

