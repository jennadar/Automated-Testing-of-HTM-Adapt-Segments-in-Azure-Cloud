### Exercises
Following exercises must be completed before you start wiht the project. Please note, if exercises are not completed in the required iteration (sprint) you cannot start with the project. You MUST complete all of them and you MUST complete them in the scheduled iteration (sprint).

#### Exercises Folder Structure
We expect you to follow the following folder structure, so we can find your exercises easily. 

1.  You MUST create MyWork folder on the very begining.
2.  Create each exercise folder under MyWork folder as E1, E2, ... or Ex1, Ex2, ... or Exercise-1, Exercise-2, ... 

The structure of the folder should be as following image.

![ex_folder_structure](https://user-images.githubusercontent.com/74201124/201675494-f872c28f-b93d-49e1-b203-2fb7ed81997a.PNG)

* E0 Before all
* E1 Install .NET Core
* E2 Create your first program with command line
* E3 Create your first program with Visual Studio
* E4 Learn about Structure of Application.
* E5 Framework Independent Build
* E6 Working with Debugger

#### E0 - Before All
- Create Account on LinkedIn
- Create Account on GitHub
- Install Visual Studio and alternatively Visual Studio Code
- Please complete the survey if you didn't already.https://forms.office.com/r/LWguEBQ6ft
- Create your own branch on GitHub
- Clone your branch repository to some local folder
- Create some files in your branch
- Execute some git CLI commands to commit files
- Change files and commit changes
- Do some changes in the file again and commit changes.
- Clone the repository (your branch) to some other folder

##### Expected Output
- You are on-boarded in LinkedIn and on GitHub, with access to LinkedIn group and git repository.
- You have installed .NET Core SDK and Visual Studio.
- You have your branch in repository. The branch contains a folder *MyWork*.

#### E1 Install .NET Core
The best way to develop with .NET Core on Windows is using Visual Studio. We will work in course with this version.
Download .NET 6.0 SDK: https://www.microsoft.com/net/download/core
If you have installed the Visual Studio, the .NET Core is automatically installed. VS 2022 installs .NET 6.0. You may install .NET 5.0 side by side with .NET 6.0.

After installation use the CLI (command line interface) tool **dotnet**. 
This tool works on all operative systems.

If dot net SDK is installed, simply open the command prompt and execute following command
~~~
dotnet
~~~

As next, check what is installed.

~~~
dotnet --info
~~~

This will list all installed runtimes and SDKs.

##### Expected Output
Installed .NET Core SDK on your machine.
<br/>Screenshot as a proof when you run dotnet --info.

#### E2 Create your first program with command line
Open Command Prompt or Powershell (bash on Linux or MAC) and execute following code line by line.
```
//Create a new folder
mkdir YOURAPP

// Go to folder
cd YOURAPP

// Create a new .NET Core project
dotnet new

// Create a new .NET Core project
dotnet restore

// Build the project
dotnet build

// Run application
dotnet run

```
##### Expected Output
Folder in your branch inside of *MyWork* with project name like *HelloWorldWithCli*.
I.E.: *\MyWork\HelloWorldWithCli*
<br/>Screenshot as a proof to show you created a project with command line.

**Do not commit to master**

#### E3 Create your first program with Visual Studio

##### Expected Output
Folder in your branch with project name like *HelloWorldWithVS*.
I.E.: *\MyWork\HelloWorldWithVS*

**Do not commit to master**

#### E4 Learn about Structure of Application.
- Add new Project to the solution (library)
- Implement some class in the new project
- Add Reference to the new project (library) from application project

##### Expected Output
Folder in your branch with project name like *HelloWorldWithClass*.
I.E.: *\MyWork\HelloWorldWithClass*
**Do not commit to master**

#### E5 Independent Framework  Build (stand alone build/deployment)
- publish a standalone application.  

##### Expected Output
Folder in your branch with project name *publish-independent*.
I.E.: *\MyWork\publish-independent*
<br/> Since published files are part of the ignore files for git, we ask you to take a Screenshot of your standalone app, when it is running, without using VS studio.

**Do not commit to master**

#### E6 - Working with Debugger 

1. Start you application
2. Attach the debugger to the process.
3. Try to step through the code and read some variable values.

##### Expected Output
Screenshot when you step though each line as a proof. ( any line is okay, but you should be in debug mode )

#### E7 - Reading Configuration, Reading Files, Reading file 

1. Add nugget packages:
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Binder
- Microsoft.Extensions.Configuration.EnvironmentVariables
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.CommandLine

2. Add new file ‘appsettings.json’ to the project
	
3. Add Code for reading settings 

##### Expected Output
A project with appsettings.json file. 


#### E8 - Exercise with Interfaces and classes
1. Define some interface or use IMyInterface from this presentation. (See slide 6)
1. Create two classes, which implement interface by using two different approaches.

For example:
* Method train could calculate sum of all values specified in data and set result to 1 if the sum is greater than 100 and 0 if sum is less than 100.
* Second implementation could use some different rule. For example Train would calculate Average value, Median and Variance. All named results can be provided as 	properties of some class called Result. Method GetResult would return instance of class Result.
* Please note that method Train can be called multiple times. It means implementation of 	interface must remember calculated result. 
3. Extend interface with methods Save and Load. Save should save currently calculated (trained) result and Load should load saved result on next application start

#### E9 - Parallel Processing
1. Run a job in Sequence  
1.1 Execution job after job.  
2. Run every job in its own thread  
2.1 Optimal: If number of processors (cores) equals num. of threads.  
2.2 Context switches: if num. of threads higher than num of processors (cores).  
2.3 OS need time for managing of context switches.  
3. Run jobs as parallel Tasks  
3.2 Internal scheduler fires optimal num. of threads  
3.3 Internal scheduler reuses threads.  
4. Implement your own worker.  
5. Provide test results for all 3 approaches for .NET 5, .NET 6 and .NET 7  
6. Outputs  
6.1 Execution time  
6.2 Max number of threads during execution  
6.3 Excel Diagram  
7. Inputs:  
7.1 Test Name (Approach)   
7.2 Test with numThreads = {50, 100, 150} 
7.3 Number of processors (Affinity in TaskMgr -- only for windows) {1, 2, 4}  for 100 threads  

Use the following diagram (Box and Whisker)
![image](https://user-images.githubusercontent.com/1756871/101355906-90790700-3897-11eb-9451-a6edd3da4349.png)

#### E10 - Working with NuGet

1. Go to VS settings and add new nuget source (file share)
2. Create new .NET Core Library (or use an existing one)
3. Open command prompt and navigate to project folder
4. Create NUGET package
5. Copy NUGET package to your nuget source folder. (c:\temp\TestPackages)
6. Open Visual Studio solution
7. Reference NUGE package from nuget source folder

#### E11 - Working with UnitTests

1. The goal of this lab is to implement tests for your existing code
2. Create UnitTest Project in existing solution
3. Add reference from UnitTest project to your project 
4. Implement Unit Tests

#### E12 - Project started

1. You have solution with two projects and first code lines.
2. Solution compiles
3. Unitests run
