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
 
