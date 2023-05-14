## Microsoft Certified: Azure Solutions Architect Expert
We will learn in this course by using the official MS Azure certification content.

![logo](https://user-images.githubusercontent.com/1756871/80301968-8f331800-87a7-11ea-9d47-8bff50d0ff0f.png)

https://docs.microsoft.com/en-us/learn/certifications/azure-solutions-architect

This course is aligned to the official Certification Path to become the Azure Solution Architect on the expert level.
We will not achieve that level in this course, but will cover topics included in the exam AZ 300, which correspond to Microsoft Azure Architect - Technology exam.
![path](https://user-images.githubusercontent.com/1756871/80301985-aa9e2300-87a7-11ea-9aeb-2ba8eb080c0f.png)

## Exam AZ-300: Microsoft Azure Solution Architect Expert
Some of the learning materials we will use from this exam.

https://docs.microsoft.com/en-us/learn/certifications/azure-solutions-architect/

### Location

Room 103

The course is also streamed by MS Teams.

Every Monday: 14:15h

Exercises must be done within 2 weeks after the lesson.

Project Deadline:  **19.August.2023!!!**

You can join to the session by using this URL: ([Teams Meeting](https://teams.microsoft.com/l/meetup-join/19%3ameeting_MGNmOTJmMzItMTRkMy00MGU2LThmOTktZjIxMTRkMTg3ODgx%40thread.v2/0?context=%7b%22Tid%22%3a%22b1f2074d-dc55-43dc-be8e-9311da2845b5%22%2c%22Oid%22%3a%224cbab5a5-4e6e-42a3-9fbe-d7142af265b5%22%7d))

Youtube lesson url : [CloudComputing](https://www.youtube.com/playlist?list=PLxYkc-bkMwhb15ADjzeSLOqTjWmrulW8H)

### Subscription
Azure for Students subscription: https://azure.microsoft.com/en-us/free/students/

### Exercises
Following document describes deliverables of your [exercises](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2022-2023/blob/master/Source/MyCloudProjectSample/Documentation/Exercises%20-%20Firstname%20Lastname.md).


### Cloud Project
The goal of your project is running your Software Engineering project in Microsoft Azure Cloud. You will make a simple console application, which will contain a code of some of your UnitTests. That code will represent some ML experiment in context of your project. To run the project in the cloud you will first have to package the code in a **Docker Container**. 
Next you will upload this code to **Azure Container Registry**. The code will start when you upload the training files to the Azure Blob Storage. Your code in container will download the file from storage and start the experiment (e.g. training and prediction). The result will be written into a **Table Storage**.

The following diagram illustrates the architecture of the solution and the technologies you will learn:

![image](https://user-images.githubusercontent.com/1756871/83964141-ec43e280-a8aa-11ea-8ba9-49a0ddc1d05b.png)

Yellow boxes describe your development work.

Following pseudo-code demonstrates how to deal with the Azure storage services within your project.

~~~csharp
void async Task Main(string args)
{
        CloudQueue queue = CreateQueueAsync(queueName).Result; 

	while(true)
	{
                CloudQueueMessage queueMessage = await queue.GetMessageAsync();
                 
                // TODO: Deserialize msg
                ExerimentRequestMessage msg = ...

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(ImageToUpload);
		
                await blockBlob.DownloadToFileAsync(string.Format("./CopyOf{0}", ImageToUpload), FileMode.Create);

		var myInputData = File.ReadToEnd();
                
                RunExperiment();

                var startTime = DateTime.Now;

                var accuracy = ml.GetAccuracy();

		File.Write("file.csv", ml.Result);

    	        CloudBlockBlob blockBlob = container.GetBlockBlobReference(ImageToUpload);

                // Set the blob's content type so that the browser knows to treat it as an image.
                blockBlob.Properties.ContentType = "image/png";
                await blockBlob.UploadFromFileAsync("file.csv");

  		var entity = new ExperimentResultEntity ("PartitionKey", "RowKey");
		entity.StartTime = startTime;
		entity.EndTime = DateTime.Now;
                entity.Accuracy = accuracy;
		entity.Error = ???
                entity.Input = msg.blobUrl;
                entity.Output = outputBlobUrl;

		tableClient.Insert(entity);
	}

        private object RunExeriment(object input)
        {
             // Here the code from your SE project.
             return result;
        }
~~~

}

Example of the Table Storage Entity used as the output of experiment.

~~~csharp
    	    ExperimentResultEntity customer = new CustomerEntity("Harp", "Walter")
            {
                public string ExperimentId { get; set; }

                public string Name {get;set}
                
		public DateTime StartTimeUtc {get;set}

		public DateTime EndTimeUtc {get;set}

		public long DurationSec {get;set}

		public string InputFileUrl {get;set}

		public string OutputFileUrl {get;set;}
		// Your properties related to experiment.

		public float Accuracy {get;set}

		public float ?? {get;set}

		public float ?? {get;set}
            };
~~~

An example which demonstrates how to serialize the message as a JSON.

~~~csharp         
            ExerimentRequestMessage msg = new ExerimentRequestMessage()
            {
                ExperimentId = "123",
                InputFile = "https://beststudents2.blob.core.windows.net/documents2/daenet.mp4",
            };

            string msgJson = JsonConvert.SerializeObject(msg);

            await queue.AddMessageAsync(new CloudQueueMessage(msgJson));

~~~

An example which demonstrates how to deserialize the message from JSON:

~~~csharp
 ExerimentRequestMessage msg2 = JsonConvert.DeserializeObject<ExerimentRequestMessage>(message.AsString);
~~~

# Learning Topics
Following topic are most important topics from the lesson, which you will need to implement your project.

## Lesson 1: Cloud Computing

### Cloud and Azure Fundamentals
https://docs.microsoft.com/en-us/learn/modules/intro-to-azure-fundamentals/

### Provisioning Resources
https://docs.microsoft.com/en-us/learn/modules/configure-azure-resources-tools/

### Managing resources and Azure Resource Manager 

https://docs.microsoft.com/en-us/learn/paths/manage-resources-in-azure/

https://docs.microsoft.com/en-us/learn/modules/control-and-organize-with-azure-resource-manager/

https://learn.microsoft.com/en-us/training/modules/introduction-to-infrastructure-as-code-using-bicep/4-what-bicep


### Azure Command Line interface (azcli)
https://docs.microsoft.com/en-us/learn/modules/control-azure-services-with-cli/

How to start wit **az** cli?
Open command prompt. Linux/WIndows/MacOS

`az login`

As next, execute the following command 

`az account show`

You might get something like this:

~~~
 {
    "cloudName": "AzureCloud",
    "homeTenantId": "1a**d",
    "id": "e8**828",
    "isDefault": false,
    "managedByTenants": [],
    "name": "Azure für Bildungseinrichtungen: Starter",
    "state": "Enabled",
    "tenantId": "1**d",
    "user": {
      "name": "**",
      "type": "user"
    }
  }
~~~

If this is not the subscription, which you want to use, then execute the following:

`az account list`

This will list all subscriptions under your account. To select the right one, use the following command:

`az account set -s <ENTER HERE SUBSCRIPTION ID or SUBSCRIPTION NAME>`

More about this in the "containers" PPTX. You can find there slides with these commands.

Recording [Lesson 1](https://www.youtube.com/watch?v=u6mNyyC42ok&list=PLxYkc-bkMwhb15ADjzeSLOqTjWmrulW8H&index=1)

#####
Exercise I (Due Date: 09th May): 
- Unlock Azure Subscription
- Practice [azcli](https://docs.microsoft.com/en-us/learn/modules/control-azure-services-with-cli/)
- Practice also [azcli](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/tree/master/Source/az)
- Take a look at the Azure Portal Videos: https://learn.microsoft.com/en-us/azure/azure-portal/azure-portal-video-series
- Step through all Lesson 1 URLs (do NOT miss any!)
- Install Docker Desktop: https://docs.docker.com/desktop/install/windows-install/, https://docs.docker.com/desktop/install/mac-install/


## Lesson 2: Docker in Azure
 
In this lesson, you will learn about containers. You will learn how to put the .NET Core application to the docker container and how to deploy it to Azure. 
You should start learning here:
### Presentation 
(1) https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/blob/master/Lessons/CloudComputing/Docker%20.NET%20Core%20and%20Azure.pptx  
### Microsoft Learning Path: Architect modern applications in Azure  
(2) https://docs.microsoft.com/en-us/learn/paths/architect-modern-apps/  

### What is Docker ?  
https://docs.microsoft.com/en-us/dotnet/architecture/microservices/container-docker-introduction/docker-defined  
### Sample Containerized Webapp with Docker  
https://docs.microsoft.com/en-us/learn/modules/intro-to-containers/  

### K8 Core Concept for AKS  
https://docs.microsoft.com/en-us/azure/aks/concepts-clusters-workloads

##### Exercise II (Due Date: 23rd May):
- Read PPTX (1) and follow practices (2). See obove.
- Create a Console Application (Follow PPTX)
- Build the docker image for the console application.
- Push the image to the docker hub
  You should also push your image to [DockerHub](https://hub.docker.com/). 
  Before you do that, You will have to create your free account for GitHub.Azure Registry is compatible with DockerHub registry.

  To push the image to the docker hub use following command:
  `docker tag myjob:latest docker.io/YOURDOCKERUSERNAME/dockerapp:v1`
  `docker push YOURDOCKERUSERNAME/dockerapp:v1`
  
  You can use the the sample code *dockerapp* in the repo.

After practicing, you should provide following delivery in your branch/source:

~~~bash
// script end extension can be: .ps1, .bat or any with shell scripts
/MyWork
/MyWork/Cloud Exercise - 01/az.scripts.bat 
/MyWork/Cloud Exercise - 02/docker.scripts.bat
/MyWork/Cloud Exercise - 02/readme.md
~~~


The read-me should provide all URLs related to your practicing. For example, provide the url to public GitHub registry and repositories to download your images from.
Example: https://hub.docker.com/repository/docker/ddobric/daenet-test-repo. Please also provide URLs to the same in Acure Container Registry.



## Lesson 3: Host a web application with Azure App service
This is the official learning path tutorial, which describes how to create a web application and how to deploy it to Azure AppService. You can execute this tutorial as described under this URL by using a learning sandbox. However, you already own an Azure Subscription. In that case, you can execute all scripts in his tutorial from any command-line prompt (bash), even on your local machine.
https://docs.microsoft.com/en-us/learn/modules/host-a-web-app-with-azure-app-service/

If you use Windows and don't like scripting, you can deploy the test web application by uploading the ZIP file, which contains the application.Note, the ZIP is created as described in previous [practice](https://docs.microsoft.com/en-us/learn/modules/host-a-web-app-with-azure-app-service/).
Deploy the ZIP with UI:
In the browser, navigate to https://<app_name>.scm.azurewebsites.net/ZipDeployUI.

More about WebApp deployment: https://docs.microsoft.com/en-us/azure/app-service/deploy-zip

To understand how files are organized in the *AppService* take a look at this article: https://github.com/projectkudu/kudu/wiki/Understanding-the-Azure-App-Service-file-system.

%HOME% is persisted and replicated across instances.
%APPDATA%/ is locked at the box.

### Create the  WebApp in Portal

##### Exercise III-a (Due Date: 6th June):
![create app](https://user-images.githubusercontent.com/1756871/82140851-179a5b00-9832-11ea-8816-46c32e13d258.png)

Create a demo web application based on MVC technology:
`dotnet new mvc --name BestBikeApp`

Run the demo application:

`dotnet run`

Then open the browser and navigate to the locally running application: http://localhost:5000

Publish the application binaries:

`dotnet publish -o pub`

Go to the folder and create the ZIP file 'site.zip' with the content of the folder. 

Deploy the application:

`az webapp deployment source config-zip --src site.zip --resource-group RG-BIKE --name bikeapp`

Open the browser and navigate to the application running in the cloud: https://bikeapp.azurewebsites.net/
![Your App running in Azure ](https://user-images.githubusercontent.com/1756871/82141297-1b7bac80-9835-11ea-80b6-a1375932ac7b.png)

##### Exersize III-b Create WebApp and Plan with AZ-CLI

Read following: https://learn.microsoft.com/en-us/cli/azure/appservice/plan?view=azure-cli-latest

Execute following command to create the plan (cluster) with two machines. Do not forget to delete the plant after exersize!!!

~~~
az appservice plan create -g MyResourceGroup -n MyPlan --is-linux --number-of-workers 2 --sku S1
~~~

Read following article: https://learn.microsoft.com/en-us/cli/azure/webapp?view=azure-cli-latest#az-webapp-create.
As next, create the AppService inside the plan (claster). 

~~~
az webapp create -g MyResourceGroup -p MyPlan -n MyUniqueAppName
~~~

### Deploy and run the containerized app in AppService

##### Exercise IV (Due Date: 20th June):

Create a Docker image and store it in a repository in Azure Container Registry. Use Azure App Service to deploy a web application based on the Docker image. 
Following exercise shows how to do this:
https://docs.microsoft.com/en-us/learn/modules/deploy-run-container-app-service/

You are done when you reach "E_xercise - Create and deploy a web app from a Docker image_". There are a few more topics in the exercise, which you don't have to do, after this topic.

## Lesson 4 - Azure Storage and Blob Storage
![Storage Account](https://user-images.githubusercontent.com/1756871/82807314-cddfef00-9e87-11ea-8457-c0343853824a.png)

To learn about cloud storage for your applications in Azure please follow this [url](https://docs.microsoft.com/en-us/learn/paths/architect-storage-infrastructure/).

Azure Storage [PPTX](https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2019-2020/blob/master/Lessons/CloudComputing/Azure%20Storage%20Overview.pptx).

**Exercise:** Create the Storage Account
![Create Storage Account](https://user-images.githubusercontent.com/1756871/82747492-9266f700-9d99-11ea-8407-947a87bcfee3.png)

### Blob Storage
![Blob Concept](https://user-images.githubusercontent.com/1756871/82807863-eac8f200-9e88-11ea-991d-e25a9702d1d0.png)

**Blob Storage Intro**
https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-overview

**Samples in university repository**
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/tree/master/Source/BlobStorageSamples

**Samples in git repo**
https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs/samples

**Exercise V (Due Date: 4th July):**
https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet

## Lesson 5 - Table Storage
![Table Concept](https://user-images.githubusercontent.com/1756871/82807915-0cc27480-9e89-11ea-8852-a440ccbf5e82.png)

**Table Storage Presentation**
https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-overview

**Samples in university repository**
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/tree/master/Source/TableStorageSamples

**Official samples as Unit Tests**

https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/tables/Azure.Data.Tables/samples

https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/tables/Azure.Data.Tables/tests/samples

**Exercise VI (Due Date: 18th July):**

Use this example to learn how to work with tables. Note, create first the storage account as we learned. This sample shows how to create the storage inside of CosmosDB. We do not cover this topic in our course. Everything else in this example is 100% compatible with the classic storage accounts.

[https://docs.microsoft.com/en-us/azure/cosmos-db/tutorial-develop-table-dotnet](https://docs.microsoft.com/en-us/azure/cosmos-db/table/create-table-dotnet?toc=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fstorage%2Ftables%2Ftoc.json&bc=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fbread%2Ftoc.json&tabs=azure-portal%2Cvisual-studio)

## Lesson 6 - Queue Storage
![Queue Concept](https://user-images.githubusercontent.com/1756871/82807958-3085ba80-9e89-11ea-8c3d-8f2a0239d3ba.png)

**Samples in university repository**
https://github.com/UniversityOfAppliedSciencesFrankfurt/se-cloud-2021-2022/tree/master/Source/QueueStorageSamples

**Exercise VII (Due Date: 18th July):**

**Step by step tutorial** 
https://docs.microsoft.com/en-us/azure/storage/queues/storage-dotnet-how-to-use-queues?tabs=dotnet



