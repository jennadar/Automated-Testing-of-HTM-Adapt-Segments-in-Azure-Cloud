# Implementation of UnitTest for AdaptSegments | Team_UnitTestX_CC - Azure Cloud Implementation

# Description:
The main objectives of the project are to guarantee that the Adapt Segment method funciton correctly in the HTM algorithm by creating thorough unit test cases for it. The project for Implementation of UnitTest for Adapt Segments focuses on creating a robust testing framework to ensure the correct and relaible functionality of the Adapt Segment method within the Hierarchical Temporal Memory (HTM) algorithm. Unit Testing is a crucial aspect of software development, aiming to verify that individual componenets or units of code work as intended in isolution. The Hierarchical Temporal Memory (HTM) algorithm, a computer model based on the structure and function of the neocortex in the brain, incorporates Adaptive Segments as a major component. Using adaptive segments, recurrent pattern in the input data can be reprensented in HTM and modified when fresh input is received. 

In the HTM model, an Adaptive Segment consitutes a collective of neurons intricately interlinked and activated in unison by a specific input pattern. When the HTM model encounters a novel input pattern, a meticulous comparison unfolds with the existing repertoire of Adapive Segments. This scrutiny aims to discern whether the incoming input aligns with any pre-established segments. This process is know as reinforcement learning, and it is similar to the way that the brain learns and adapts to new information.

As the Hierarchical Temporal Memory (HTM) model is exposed to more input data over time, the Adaptive Segments become more specialized and proficient at identifying the patterns in the data. This means that complex input sequences that would be difficult or impossible for traditional machine learning algorithms to recognize can be learned and detected by the HTM model. Because they enable the model to adjust over time to changes in the input data, adaptive segments are a crucial component of the HTM process. As new information is continuously added to the Adaptive Segments, the HTM model is able to identify and react to new patterns and activity sequences in the data.

This makes HTM an effective tool for application in fields like robotics, finance, and health that include anomaly detection, prediction, and classification. The testing of the AdaptSegment module or component is conducted through a specialized form of software testing known as unit testing. The primary objective of unit testing is to verify that every segment of the software code functions precisely as intended. These tests meticulously isolate individual components, be it a function, method, procedure, module, or object, to validate their accuracy and adherence to the intended functionality. The essence lies in confirming that each unit of code operates seamlessly within the broader software system.

# Cloud Project

https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/tree/master/Source/MyCloudProjectSample



## What is your experiment about

Describe here what your experiment is doing. Provide a reference to your SE project documentation (PDF)*)

1. What is the **input**?

2. What is the **output**?

3. What your algorithmas does? How ?

## How to run experiment

Describe Your Cloud Experiment based on the Input/Output you gave in the Previous Section.

**_Describe the Queue Json Message you used to trigger the experiment:_**  

~~~json
{
     ExperimentId = "123",
     InputFile = "https://beststudents2.blob.core.windows.net/documents2/daenet.mp4",
     .. // see project sample for more information 
};
~~~

- ExperimentId : Id of the experiment which is run  
- InputFile: The video file used for trainign process  

**_Describe your blob container registry:**  

what are the blob containers you used e.g.:  
- 'training_container' : for saving training dataset  
  - the file provided for training:  
  - zip, images, configs, ...  
- 'result_container' : saving output written file  
  - The file inside are result from the experiment, for example:  
  - **file Example** screenshot, file, code  


**_Describe the Result Table_**

 What is expected ?
 
 How many tables are there ? 
 
 How are they arranged ?
 
 What do the columns of the table mean ?
 
 Include a screenshot of your table from the portal or ASX (Azure Storage Explorer) in case the entity is too long, cut it in half or use another format
 
 - Column1 : explaination
 - Column2 : ...
Some columns are obligatory to the ITableEntities and don't need Explaination e.g. ETag, ...
 
