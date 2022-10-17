## My Cloud Computing Project

You all will use the same cloud storage account:

~~~
DefaultEndpointsProtocol=https;AccountName=cloudproject2022;AccountKey=nZRb5dLImtjBQxAMKY41w2ks13f2D39nqMaAhTW8ct1OC5RWHtvQUSfC53W2uD+ho1saM/LZcNuaELuDMfGm0g==;EndpointSuffix=core.windows.net
~~~

Create your container, queue and table:

![storage organization](https://user-images.githubusercontent.com/1756871/87311747-f0a19200-c51f-11ea-805a-0a53dc646b82.png)

DO NOT DELETE ANY OTHER ENTITY!!!!
All your files used for testing must be commited in the folder 'SampleFiles'. See below. We will take them from that folder and move to the container/queue.

Tasks:

1. Practice ALL Exercises
2. Implement your cloud project
3. Write documentation

Deliverables:

Your cloud solution MUST LOOK like:

![your cloud solution](https://user-images.githubusercontent.com/1756871/87311995-4aa25780-c520-11ea-893e-99a65dad0e36.png)

Here is the example: https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/tree/master/Source/MyCloudProjectSample

All documentation consists of two MARKDOWN files

![documentation](https://user-images.githubusercontent.com/1756871/87309918-85ef5700-c51d-11ea-8d4a-5f2446ebb55e.png)

## Exercises

1. Practice all exersizes
2. Document all exercises

#### Deliverables:

*Exercises - Firstname Lastname.md*

See the content of the file to be sure what to deliver for every exersize. All results of your exercises MUST be in this document.

## Cloud project
1. Specify the experiment to be used
2. Implement the experiment in project MyExperiment
3. Implement IStorageProvider

Your work is focused on the project *MyExperiment*. Do not do any changes in *MyCloudProject* && *MyCloudProject.Common*.

### (1) Specify your experiment
The experiment is a code from your existing SE project. For example, this can be some UnitTest, which executes the full training. The code must demonstrate receiving of the message from the storage queue, downloading of training file(s), execution of the training code, uploading of result files to the blob storage, and updating of the table storage with results.
Put the specification description into the file: *Experiment Specification.md*. Note, all groups share the same specification.

### (2) Implement the experiment
To implement your experiment you will have to use the project [template](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/master/Source/MyCloudProjectSample/MyCloudProject.sln).

Your experiment must implement the interface:
~~~csharp
IExperiment
~~~

### (3) Implement IStorageProvider

#### DownloadInputFile
It downloads all files required to for the training in your experiment.

#### UploadResultFile
Uploads a number of resulting files of your experiment. These can be images or some output files.

#### UploadExperimentResult
The experiment result is a record created for every executed experiment. It is defined by the class ExperimentResult.

#### Deliverables:

*Experiment Specification - Fiestname Lastname.md*
See content of the file for more information about how to document the experiment.

## Important Dates

### Official project dealine
no later than: 19 August 2022


