using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCloudProject.Common;
using NeoCortexApi;
using NeoCortexApi.Entities;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;



namespace MyExperiment
{
    /// <summary>
    /// This class implements the ML experiment that will run in the cloud. This is refactored code from my Unit_Test AdaptSegments SE project.
    /// </summary>
    public class Experiment : IExperiment
    {
        private IStorageProvider storageProvider;
        //private ExcelWriter excelreport;
        private ILogger logger;

        private MyConfig config;

        public Experiment(IConfigurationSection configSection, IStorageProvider storageProvider, ILogger log)
        {
            this.storageProvider = storageProvider;
            this.logger = log;

            config = new MyConfig();
            configSection.Bind(config);
        }

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


                ///******************************************************** TestCase 0 ***************************************************************//

                PermDataList = TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive();
                res.ExperimentName = "TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasNotActive";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("0", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 1 ***************************************************************//

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


                ///******************************************************** TestCase 2 ***************************************************************//
                PermDataList = TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive();
                res.ExperimentName = "TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("2", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);
                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 3 ***************************************************************//
                PermDataList = TestAdaptSegment_PermanenceIsLimitedWithinRange();
                res.ExperimentName = "TestAdaptSegment_PermanenceIsLimitedWithinRange";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("3", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);


                ///******************************************************** TestCase 4 ***************************************************************//
                PermDataList = TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity();
                res.ExperimentName = "TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("4", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 5 ***************************************************************//
                SynapseCount = TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment();
                res.ExperimentName = "TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                res.Comments = SynapseCount.Item4;
                SegmentCount.Add(Tuple.Create("5", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, " +
                $"SegmentCount: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);
                ///******************************************************** TestCase 6 ***************************************************************//
                SynapseCount = TestAdaptSegment_MatchingSegmentAndActiveSegmentState();
                res.ExperimentName = "TestAdaptSegment_MatchingSegmentAndActiveSegmentState";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                res.Comments = SynapseCount.Item4;
                SegmentCount.Add(Tuple.Create("6", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, " +
                $"SegmentCount: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);
                ///******************************************************** TestCase 7 ***************************************************************//
                SynapseCount = TestAdaptSegment_WhenMaxSynapsesPerSegmentIsReachedAndExceeded();
                res.ExperimentName = "TestAdaptSegment_WhenMaxSynapsesPerSegmentIsReachedAndExceeded";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                res.Comments = SynapseCount.Item4;
                SegmentCount.Add(Tuple.Create("7", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, " +
                $"SegmentCount: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);
                ///******************************************************** TestCase 8 ***************************************************************//
                SynapseCount = TestAdaptSegment_SegmentIsDestroyed_WhenNoSynapseIsPresent();
                res.ExperimentName = "TestAdaptSegment_SegmentIsDestroyed_WhenNoSynapseIsPresent";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                res.Comments = SynapseCount.Item4;
                SegmentCount.Add(Tuple.Create("8", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, " +
                $"SegmentCount: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);


                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);

                ///******************************************************** TestCase 9 ***************************************************************//

                PermDataList = TestAdaptSegment_ComplexDoublePermanenceInput();
                res.ExperimentName = "TestAdaptSegment_ComplexDoublePermanenceInput";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("9", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 10 ***************************************************************//

                PermDataList = TestAdaptSegment_SynapseRetentionOnDistalDendrite();
                res.ExperimentName = "TestAdaptSegment_SynapseRetentionOnDistalDendrite";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("10", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 11 ***************************************************************//


                PermDataList = TestAdaptSegment_LowPermanence_SynapseShouldbeDestroyed();
                res.ExperimentName = "TestAdaptSegment_LowPermanence_SynapseShouldbeDestroyed";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("11", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 1 ***************************************************************//

                PermDataList = TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues();
                res.ExperimentName = "TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("12", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);
                ///******************************************************** TestCase 2 ***************************************************************//

                PermDataList = TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues();
                res.ExperimentName = "TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("13", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);
                ///******************************************************** TestCase 3 ***************************************************************//

                PermDataList = TestAdaptSegment_ShouldThrow_DD_ObjectShouldNotBeNUllException();
                res.ExperimentName = "TestAdaptSegment_ShouldThrow_DD_ObjectShouldNotBeNUllException";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("14", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 4 ***************************************************************//

                PermDataList = TestAdaptSegment_CheckMultipleSynapseState();
                res.ExperimentName = "TestAdaptSegment_CheckMultipleSynapseState";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("15", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 5 ***************************************************************//

                PermDataList = TestAdaptSegment_PermanenceMaxBound();
                res.ExperimentName = "TestAdaptSegment_PermanenceMaxBound";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("16", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 6 ***************************************************************//

                PermDataList = TestAdaptSegmentPermanenceMinBound();
                res.ExperimentName = "TestAdaptSegmentPermanenceMinBound";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                res.Comments = PermDataList.Item4;
                AdaptSegmentsList.Add(Tuple.Create("17", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults, res.Comments));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, " +
                $"UpdatedPermanence: {tuple.Item4}, TestCaseResults: {tuple.Item5}, Comments: {tuple.Item6}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                Console.WriteLine("Experiment Unit Test AdaptSegments run successfully");
            }
            return Task.FromResult<IExperimentResult>(res); // TODO...
        }

        //ExcelPackage package = new ExcelPackage();

        /// <inheritdoc/>
        public async Task RunQueueListener(CancellationToken cancelToken)
        {
            //ExperimentResult res = new ExperimentResult("damir", "123")
            //{
            //    //Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),

            //    Accuracy = (float)0.5,
            //};

            //await storageProvider.UploadExperimentResult(res);


            QueueClient queueClient = new QueueClient(this.config.StorageConnectionString, this.config.Queue);

            //
            // Implements the step 3 in the architecture picture.
            while (cancelToken.IsCancellationRequested == false)
            {
                QueueMessage message = await queueClient.ReceiveMessageAsync();

                if (message != null)
                {
                    try
                    {
                        string msgTxt = Encoding.UTF8.GetString(message.Body.ToArray());

                        this.logger?.LogInformation($"Received the message {msgTxt}");

                        // The message in the step 3 on architecture picture.
                        ExerimentRequestMessage request = JsonSerializer.Deserialize<ExerimentRequestMessage>(msgTxt);

                        // Step 4.
                        //var inputFile = await this.storageProvider.DownloadInputFile(request.InputFile);
                        var inputFile = request.InputFile;

                        // Here is your SE Project code started.(Between steps 4 and 5).
                        IExperimentResult result = await this.Run(inputFile);

                        // Step 4 (oposite direction)
                        //TODO. do serialization of the result.
                        //await storageProvider.UploadResultFile("outputfile.txt", null);

                        // Step 5.
                        await storageProvider.UploadExperimentResult(result);

                        await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
                    }
                    catch (Exception ex)
                    {
                        this.logger?.LogError(ex, "TODO...");
                    }
                }
                else
                {
                    await Task.Delay(500);
                    logger?.LogTrace("Queue empty...");
                }
            }

            this.logger?.LogInformation("Cancel pressed. Exiting the listener loop.");
        }


        #region Private Methods

        

        /// <summary>
        /// Unit Tests for AdaptSegments method of the Temporal Memory Class.
        /// </summary>

        private const string CONNECTIONS_CANNOT_BE_NULL = "Connections cannot be null";
        private const string DISTALDENDRITE_CANNOT_BE_NULL = "Object reference not set to an instance of an object.";
        /// <summary>
        /// Testing whether the permanence of a synapse in a distal dendrite segment increases if its presynaptic cell 
        /// was active in the previous cycle.with a permanence value of 0.1. Then it calls the AdaptSegment 
        /// method with the presynaptic cells set to cn.GetCells(new int[] { 23, 37 }). This means that if 
        /// the presynaptic cell with index 23 was active in the previous cycle, the synapse's permanence 
        /// should be increased.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 0.1 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);

            // Invoking AdaptSegments with only the cells with index 23
            /// whose presynaptic cell is considered to be Active in the
            /// previous cycle and presynaptic cell is Inactive for the cell 477
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);

            //Assert
            /// permanence is incremented for presynaptic cell 23 from 
            /// 0.1 to 0.2 as presynaptic cell was InActive in the previous cycle
            Assert.AreEqual(0.2, s1.Permanence);
            string TestResult;
            if (0.2 == s1.Permanence) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "Permenance increment successfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasNotActive()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 0.1 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Random rnd = new Random();
            int cell_num = rnd.Next(0, 225);
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(cell_num), InputPerm[0]);

            // Invoking AdaptSegments with only the cells with index 23
            /// whose presynaptic cell is considered to be Active in the
            /// previous cycle and presynaptic cell is Inactive for the cell 477
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 0 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);

            //Assert
            /// permanence is incremented for presynaptic cell 23 from 
            /// 0.1 to 0.2 as presynaptic cell was InActive in the previous cycle
            Assert.AreEqual(0.2, s1.Permanence);
            string TestResult;
            if (0.2 == s1.Permanence) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "Permenance increment successfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }


        /// <summary>
        /// Testing the scenario where a synapse's presynaptic cell was not active in the previous cycle, 
        /// so the AdaptSegment method should decrease the permanence value of that synapse by 
        /// permanenceDecrement amount.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 0.9 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(500), InputPerm[0]);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 57 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);
            //Assert
            /// /// permanence is decremented for presynaptie cell 500 from 
            /// 0.9 to 0.8 as presynaptic cell was InActive in the previous cycle
            /// But the synapse is not destroyed as permanence > HtmConfig.Epsilon
            Assert.AreEqual(0.8, s1.Permanence);

            string TestResult;
            if (0.8 == s1.Permanence) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "Permenance decrement successfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// Test to check if the permanence of a synapse is limited within the range of 0 to 1.0.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_PermanenceIsLimitedWithinRange()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 2.5 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);
            try
            {
                Assert.AreEqual(1.0, s1.Permanence, 0.1);
            }
            catch (AssertFailedException ex)
            {
                string PERMANENCE_SHOULD_BE_IN_THE_RANGE = $"Assert.AreEqual failed. Expected a difference no greater than <0.1> " +
                    $"between expected value <1> and actual value <{s1.Permanence}>. ";
                Assert.AreEqual(PERMANENCE_SHOULD_BE_IN_THE_RANGE, ex.Message);
            }
            Boolean? testResult = s1.Permanence >= 0.1 && s1.Permanence <= 1.0 ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "Permenance is limited within the range 0.1 to 1, successfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// Validate the behavior of the AdaptSegment method of the TemporalMemory class.
        /// The test initializes a TemporalMemory object, creates a Connection object, sets the default parameters, 
        /// and initializes the TemporalMemory. It then creates a DistalDendrite object with three synapses, each connected 
        /// to different cells. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();///The connections object holds the infrastructure, and is used by both the SpatialPooler, TemporalMemory.
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);///use connection for specified object to build and implement algoarithm 
            double[] InputPerm = new double[] { 0.5, 0.6, 0.9 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));/// Created a Distal dendrite segment of a cell0
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);/// Created a synapse on a distal segment of a cell index 23
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(37), InputPerm[1]);/// Created a synapse on a distal segment of a cell index 37
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(477), InputPerm[2]);/// Created a synapse on a distal segment of a cell index 477

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 37 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Invoking AdaptSegments with only the cells with index 23 and 37
                                                  /// whose presynaptic cell is considered to be Active in the
                                                  /// previous cycle and presynaptic cell is Inactive for the cell 477

            Assert.AreEqual(0.6, s1.Permanence, 0.01);/// permanence is incremented for cell 23 from 0.5 to 0.6 as presynaptic cell was Active in the previous cycle.
            Assert.AreEqual(0.7, s2.Permanence, 0.01);/// permanence is incremented for cell 37 from 0.6 to 0.7 as presynaptic cell was Active in the previous cycle.
            Assert.AreEqual(0.8, s3.Permanence, 0.01);/// permanence is decremented for cell 477 from 0.5 to 0.6 as presynaptic cell was InActive in the previous cycle.
            Boolean? testResult = (s1.Permanence >= 0.01 && s1.Permanence <= 0.6) |
            (s2.Permanence >= 0.01 && s2.Permanence <= 0.7) | (s3.Permanence >= 0.01 && s3.Permanence <= 0.8) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {
                s1.Permanence,
                s2.Permanence,
                s3.Permanence
            };
            List<double> InputPermList = new List<double>
            {
                InputPerm[0],
                InputPerm[1],
                InputPerm[2]
            };
            string Comments;
            Comments = "Permenance increment or decrement based on previous cycle state is successfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// This test creates a new distal dendrite segment and uses a for loop to create synapses until the 
        /// maximum number of synapses per segment(225 synapses) is reached.Once the maximum is reached, 
        /// the segment is adapted using the TemporalMemory.AdaptSegment method.Finally, the test asserts 
        /// that there is only one segment and 225 synapses in the connections object.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<int, int, string, string> TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn1 = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn1);
            tm.Init(cn1);
            DistalDendrite dd1 = cn1.CreateDistalSegment(cn1.GetCell(1));
            // Create maximum synapses per segment (225 synapses)
            int numSynapses = 0;
            for (int i = 0; i < cn1.HtmConfig.MaxSegmentsPerCell; i++)
            {
                // Create synapse connected to a random cell
                Synapse s = cn1.CreateSynapse(dd1, cn1.GetCell(5), 0.5);
                numSynapses++;

                // Adapt the segment if it has reached the maximum synapses allowed per segment
                if (numSynapses == cn1.HtmConfig.MaxSynapsesPerSegment)
                {
                    TemporalMemory.AdaptSegment(cn1, dd1, cn1.GetCells(new int[] { 5 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
                }
            }
            var field1 = cn1.GetType().GetField("m_NextSegmentOrdinal", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field2 = cn1.GetType().GetField("m_NumSynapses", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var NoOfSegments = Convert.ToInt32(field1.GetValue(cn1));
            var NoOfSynapses = Convert.ToInt32(field2.GetValue(cn1));

            //Assert
            Assert.AreEqual(1, NoOfSegments);
            Assert.AreEqual(225, NoOfSynapses);
            string Comments;
            Comments = "Maximum Synapse per segment can be = " + NoOfSynapses;

            Boolean? testResult = (NoOfSegments == 1 && NoOfSynapses == 225) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string, string>> result = new List<Tuple<int, int, string, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string, string> tuple = Tuple.Create(NoOfSynapses, NoOfSegments, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// The test is checking whether the AdaptSegment method correctly adjusts the state of the matching 
        /// and active segments in the network, and whether segments that have no remaining synapses are 
        /// properly destroyed.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<int, int, string, string> TestAdaptSegment_MatchingSegmentAndActiveSegmentState()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn1 = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn1);
            tm.Init(cn1);

            DistalDendrite dd1 = cn1.CreateDistalSegment(cn1.GetCell(1));
            DistalDendrite dd2 = cn1.CreateDistalSegment(cn1.GetCell(2));
            DistalDendrite dd3 = cn1.CreateDistalSegment(cn1.GetCell(3));
            DistalDendrite dd4 = cn1.CreateDistalSegment(cn1.GetCell(4));
            DistalDendrite dd5 = cn1.CreateDistalSegment(cn1.GetCell(5));
            Synapse s1 = cn1.CreateSynapse(dd1, cn1.GetCell(23), -1.5);
            Synapse s2 = cn1.CreateSynapse(dd2, cn1.GetCell(24), 1.5);
            Synapse s3 = cn1.CreateSynapse(dd3, cn1.GetCell(25), 0.1);
            Synapse s4 = cn1.CreateSynapse(dd1, cn1.GetCell(26), -1.1);
            Synapse s5 = cn1.CreateSynapse(dd2, cn1.GetCell(27), -0.5);

            TemporalMemory.AdaptSegment(cn1, dd1, cn1.GetCells(new int[] { 23, 24, 25 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd2, cn1.GetCells(new int[] { 25, 24, 26 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd3, cn1.GetCells(new int[] { 27, 24, 23 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd4, cn1.GetCells(new int[] { }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd5, cn1.GetCells(new int[] { }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            var field1 = cn1.GetType().GetField("m_NextSegmentOrdinal", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field3 = cn1.GetType().GetField("m_SegmentForFlatIdx", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field4 = cn1.GetType().GetField("m_ActiveSegments", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field5 = cn1.GetType().GetField("m_MatchingSegments", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


            var dictionary = (ConcurrentDictionary<int, DistalDendrite>)field3.GetValue(cn1);
            var field2 = cn1.GetType().GetField("m_NumSynapses", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var NoOfSegments = Convert.ToInt32(field1.GetValue(cn1));
            var activeSegments = ((List<DistalDendrite>)field4.GetValue(cn1)).Count;
            var matchingSegments = ((List<DistalDendrite>)field5.GetValue(cn1)).Count;
            var NoOfSynapses = Convert.ToInt32(field2.GetValue(cn1));

            //Assert
            Assert.AreEqual(5, NoOfSegments);
            Assert.AreEqual(1, NoOfSynapses);
            Assert.AreEqual(0, activeSegments);
            Assert.AreEqual(0, matchingSegments);
            string Comments;
            Comments = "Number of Matching segments = " + matchingSegments + " Number of Active segments = " + activeSegments;

            Boolean? testResult = (NoOfSegments == 5 && NoOfSynapses == 1 && activeSegments == 0 &&
                matchingSegments == 0) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string, string>> result = new List<Tuple<int, int, string, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string, string> tuple = Tuple.Create(NoOfSynapses, NoOfSegments, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }


        /// <summary>
        /// Here's an example implementation of a unit test that creates more than 225 synapses using a for 
        /// loop associated with one distal dendrite segment which is going to result in ArgumentOutOfRangeException:
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]///This attribute is used to specify the expected 
                                                                ///exception. Therefore, the test will pass if the expected exception 
                                                                ///of type ArgumentOutOfRangeException is thrown, and it will fail if 
                                                                ///any other exception or no exception is thrown.
        public Tuple<int, int, string, string> TestAdaptSegment_WhenMaxSynapsesPerSegmentIsReachedAndExceeded()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn1 = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn1);
            tm.Init(cn1);
            DistalDendrite dd1 = cn1.CreateDistalSegment(cn1.GetCell(1));
            int numSynapses = 0;/// Create maximum synapses per segment (225 synapses)
            int totalCells = cn1.Cells.Length;// Get total number of cells in cn1
            // Generate a random integer between 1 and totalCells
            Random random = new Random();
            int randomCellNumber = random.Next(1, totalCells + 1);
            for (int i = 0; i < cn1.HtmConfig.MaxSegmentsPerCell; i++)
            {
                // Create synapse connected to a random cell
                Synapse s = cn1.CreateSynapse(dd1, cn1.GetCell(randomCellNumber), 0.5);
                numSynapses++;

                // Adapt the segment if it has reached the maximum synapses allowed per segment
                if (numSynapses == cn1.HtmConfig.MaxSynapsesPerSegment)
                {
                    TemporalMemory.AdaptSegment(cn1, dd1, cn1.GetCells(new int[] { randomCellNumber }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
                }
            }
            // Adapt the segment if it has crossed the maximum synapses allowed per segment by destroying any weak synapse of that segment.
            // Create one more synapse to exceed the maximum number of synapses per segment
            Synapse s226 = cn1.CreateSynapse(dd1, cn1.GetCell(randomCellNumber), 0.6);
            numSynapses++;

            if (numSynapses >= cn1.HtmConfig.MaxSynapsesPerSegment)
            {
                //226th cell of the segment does not contains anything. Therefore trying to access the 226th throws an ArgumentOutofRangeException.
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    // Attempt to access Synapse 226
                    Synapse Syn226 = dd1.Synapses[226];
                });
            }
            string Comments;
            Comments = "Maximum synapses = " + (numSynapses - 1) + " is reached";

            Boolean? testResult = (numSynapses == 226) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string, string>> result = new List<Tuple<int, int, string, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string, string> tuple = Tuple.Create(numSynapses - 1, 1, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }


        /// <summary>
        /// The test checks that the segment is destroyed when all its synapses are destroyed.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<int, int, string, string> TestAdaptSegment_SegmentIsDestroyed_WhenNoSynapseIsPresent()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn1 = new Connections();
            /* Connections cn2 = new Connections();
             Connections cn3 = new Connections();*/
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn1);
            tm.Init(cn1);

            DistalDendrite dd1 = cn1.CreateDistalSegment(cn1.GetCell(0));
            DistalDendrite dd2 = cn1.CreateDistalSegment(cn1.GetCell(0));
            DistalDendrite dd3 = cn1.CreateDistalSegment(cn1.GetCell(0));
            DistalDendrite dd4 = cn1.CreateDistalSegment(cn1.GetCell(0));
            DistalDendrite dd5 = cn1.CreateDistalSegment(cn1.GetCell(0));
            Synapse s1 = cn1.CreateSynapse(dd1, cn1.GetCell(23), -1.5);
            Synapse s2 = cn1.CreateSynapse(dd2, cn1.GetCell(24), 1.5);
            Synapse s3 = cn1.CreateSynapse(dd3, cn1.GetCell(25), 0.1);
            Synapse s4 = cn1.CreateSynapse(dd4, cn1.GetCell(26), -1.1);
            Synapse s5 = cn1.CreateSynapse(dd5, cn1.GetCell(27), -0.5);

            TemporalMemory.AdaptSegment(cn1, dd1, cn1.GetCells(new int[] { 23, 24, 25 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd2, cn1.GetCells(new int[] { 25, 24, 26 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            TemporalMemory.AdaptSegment(cn1, dd3, cn1.GetCells(new int[] { 27, 24, 23 }), cn1.HtmConfig.PermanenceIncrement, cn1.HtmConfig.PermanenceDecrement);
            var field1 = cn1.GetType().GetField("m_ActiveSegments", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field2 = cn1.GetType().GetField("m_MatchingSegments", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field4 = cn1.GetType().GetField("m_NextSegmentOrdinal", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field5 = cn1.GetType().GetField("m_NumSynapses", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field9 = cn1.GetType().GetField("nextSegmentOrdinal", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var field6 = cn1.GetType().GetField("m_SegmentForFlatIdx", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo destroyDistalDendriteMethod = typeof(Connections).GetMethod("DestroyDistalDendrite", BindingFlags.Public
                | BindingFlags.Instance | BindingFlags.NonPublic);
            var m_ASegment = field1.GetValue(cn1);
            var m_MSegment = field2.GetValue(cn1);


            ///Assert the segment and synapse status before the DestroyDistalDendrite method is explicitly called.
            Assert.AreEqual(5, Convert.ToInt32(field4.GetValue(cn1)));
            Assert.AreEqual(3, Convert.ToInt32(field5.GetValue(cn1)));

            ///DestroyDistalDendrite is invoked for dd1,dd2,dd3,dd4.
            destroyDistalDendriteMethod.Invoke(cn1, new object[] { dd1 });
            destroyDistalDendriteMethod.Invoke(cn1, new object[] { dd2 });
            destroyDistalDendriteMethod.Invoke(cn1, new object[] { dd3 });
            destroyDistalDendriteMethod.Invoke(cn1, new object[] { dd4 });

            ///Now checking the segment and synapse status after the DestroyDistalDendrite method is explicitly called.
            int numSegments = Convert.ToInt32(field5.GetValue(cn1));
            int numSynapses = Convert.ToInt32(field4.GetValue(cn1));
            Assert.AreEqual(1, numSegments);
            Assert.AreEqual(5, numSynapses);
            string Comments;
            Comments = "Only " + numSegments + " segment is present and remaining segments are destroyed";

            Boolean? testResult = (numSegments == 1 && numSynapses == 5) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string, string>> result = new List<Tuple<int, int, string, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string, string> tuple = Tuple.Create(numSynapses, numSegments, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }


        /// <summary>
        /// Test how the AdaptSegment works when complex double inputs are given to it
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_ComplexDoublePermanenceInput()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { 0.85484565412316 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Create a distal segment of a cell index 0 to learn sequence
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(15), InputPerm[0]);/// create a synapse on a dital segment of a cell with index 15 
                                                                            /// It results with permanence 1 of the segment's synapse if the synapse's presynaptic cell index 23 was active. 
                                                                            /// If it was not active, then it will decrement the permanence by 0.1

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 15 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Invoking AdaptSegments with the cell 15 whose presynaptic cell is 
                                                  /// considered to be Active in the previous cycle.
            Assert.AreEqual(0.95484565412316, s1.Permanence, 0.1);/// permanence is incremented for cell 15 from 0.85484565412316 to 0.95484565412316 as presynaptic cell was Active in the previous cycle.

            /// Now permanence should be at max
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 15 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Again calling AdaptSegments with the cell 15 whose presynaptic cell is 
                                                  /// considered to be Active again in the previous cycle.
            Assert.AreEqual(1.0, s1.Permanence, 0.1);/// Therefore permanence is again incremented for cell 15 from 1 to 1.1 as presynaptic cell was Active 
                                                     /// in the previous cycle. But due to permanence boundary set, 1.1 is set back to 1.
            string TestResult;
            if (s1.Permanence >= 0.1 && s1.Permanence <= 1.0)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            { InputPerm[0] };


            string Comments;
            Comments = "permanece value > 1.0, AdaptSegments will set permanence to maximum bound 1.0. to complex value is Successfull ";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        //These test procedures will determine whether the AdaptSegment technique
        // effectively eliminates synapses with permanence below Epsilon havign different inputs.

        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_SynapseRetentionOnDistalDendrite()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { 0.4, -0.1 };

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));

            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), InputPerm[1]);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsTrue(dd.Synapses.Contains(s1)); /// assert condition to check does DistalDendrite contains the synapse s1
            Assert.IsFalse(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2


            string TestResult;
            if (dd.Synapses.Count == 1)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence, s2.Permanence, };
            List<double> InputPermList = new List<double>
            { InputPerm[0], InputPerm[1]};

            string Comments;
            Comments = "Synapse count is " + dd.Synapses.Count + " because it checks the retention of synapses on distal dendrite is succesfull" +
                "and checks the count";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;

        }

        /// <summary>
        /// Test how the AdaptSegment works when a low Permanence value is passed
        /// Permanence is supposed to be set to 0 as the range should vary between 0 and 1 and when a negative permanence < 0 
        /// is passed to AdaptSegments, The Synapse is destroyed. 
        /// ********But this Testcase doesn't provide the expected results and permanence is not getting set to the minimum 
        /// bound for the negative permanence value.***********
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_LowPermanence_SynapseShouldbeDestroyed()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { -1.5 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(15), InputPerm[0]);

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 15 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);
            try
            {
                Assert.IsFalse(dd.Synapses.Contains(s1));
            }
            catch (AssertFailedException ex)
            {
                throw new AssertFailedException("The synapse was not destroyed as expected.", ex);
            }
            Boolean? testResult = s1.Permanence >= 0.1 && s1.Permanence <= 1.0 ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == false) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "The permanence value results in negative hence the synapse willl be destroyed";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// These test methods will test if the AdaptSegment method correctly destroys synapses
        /// with permanence less/greater than  HtmConfig.EPSILON
        /// </summary>

        ///TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues
        ///here permanence comes greater than  HtmConfig.EPSILON
        ///hence it won´t destroys synapses
        ///take count of the synapses inside DistalDendrite

        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues()
        {

            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections(); ///The connections object holds the infrastructure, and is used by both the SpatialPooler, TemporalMemory.
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);  ///use connection for specified object to build and implement algoarithm 

            double[] InputPerm = new double[] { 0.0000000967, 0.0000001, -0.00000001 };

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Created a Distal dendrite segment of a cell0
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]); /// Created a synapse on a distal segment of a cell index 23
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), InputPerm[1]);/// Created a synapse on a distal segment of a cell index 24
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(43), InputPerm[2]);
            /// Invoking AdaptSegments with only the cells with index 23 and 37
            ///whose presynaptic cell is considered to be Active in the previous cycle
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24, 43 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsTrue(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsTrue(dd.Synapses.Contains(s1));/// assert condition to check does DistalDendrite contains the synapse s1
            Assert.IsTrue(dd.Synapses.Contains(s3));/// assert condition to check does DistalDendrite contains the synapse s3
            //Assert.AreEqual(3, dd.Synapses.Count);  /// synapses count check in DistalDendrite

            string TestResult;
            if (dd.Synapses.Count == 3)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence, s2.Permanence, s3.Permanence};
            List<double> InputPermList = new List<double>
            { InputPerm[0], InputPerm[1], InputPerm[2]};
            foreach (double value in InputPerm)
            {
                value.ToString("0.0000000000");
            }

            string Comments;
            Comments = "Synapse count is " + dd.Synapses.Count + " because it does not destroy synpase for small negatve permanence is succesfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;

        }
        /// <summary>
        /// TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues
        /// here permanence comes lesser than  HtmConfig.EPSILON
        /// hence it  destroys synapses
        ///take count of the synapses inside DistalDendrite which comes to zero
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { -0.199991, -0.29999 };

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));

            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), InputPerm[1]);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsFalse(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsFalse(dd.Synapses.Contains(s1)); /// assert condition to check does DistalDendrite contains the synapse s2
            //Assert.AreEqual(0, dd.Synapses.Count);  /// synapses count check in DistalDendrite

            string TestResult;
            if (dd.Synapses.Count == 0)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence, s2.Permanence, };
            List<double> InputPermList = new List<double>
            { InputPerm[0], InputPerm[1]};

            string Comments;
            Comments = "Synapse count is " + dd.Synapses.Count + " because it destroys synpase for negatve permanence is succesfull" +
                "and permanence value remains unchanged";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;

        }


        /// <summary>
        /// The below test checks for exception throwing in case of connections, DistalDendrites object is null. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_ShouldThrow_DD_ObjectShouldNotBeNUllException()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 0.1 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);

            try
            {
                Assert.ThrowsException<NullReferenceException>(() =>
                {
                    TemporalMemory.AdaptSegment(cn, null, cn.GetCells(new int[] { 23 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);

                });
            }
            catch (NullReferenceException ex)
            {
                Assert.AreEqual(DISTALDENDRITE_CANNOT_BE_NULL, ex.Message);
            }
            Boolean? testResult = s1.Permanence >= 0.1 && s1.Permanence <= 1.0 ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};
            string Comments;
            Comments = "Should Throw Distal Dendrite Object Should Not Be NUll Exception as Expected and the permanence value remains unchanged as same as previous permanence";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }




        /// <summary>
        /// TestAdaptSegmentCheckMultipleSynapse
        ///Checking the destroyes of synapses and the count of synapses at the end
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_CheckMultipleSynapseState()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { 0.2656, 0.0124, 0.7656, 0.0547, 0.001, 0.002, -0.2345, -0.134345 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), 0.2656);
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), 0.0124);
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(25), 0.7656);
            Synapse s4 = cn.CreateSynapse(dd, cn.GetCell(26), 0.0547);
            Synapse s5 = cn.CreateSynapse(dd, cn.GetCell(28), 0.001);
            Synapse s6 = cn.CreateSynapse(dd, cn.GetCell(31), 0.002);
            Synapse s7 = cn.CreateSynapse(dd, cn.GetCell(35), -0.2345);
            Synapse s8 = cn.CreateSynapse(dd, cn.GetCell(38), -0.134345);
            // Act
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24, 25, 26, 28, 31, 35, 38 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsTrue(dd.Synapses.Contains(s2));
            Assert.IsTrue(dd.Synapses.Contains(s1));
            Assert.IsTrue(dd.Synapses.Contains(s3));
            Assert.IsTrue(dd.Synapses.Contains(s4));
            Assert.IsTrue(dd.Synapses.Contains(s5));
            Assert.IsTrue(dd.Synapses.Contains(s6));
            Assert.IsFalse(dd.Synapses.Contains(s7));
            Assert.IsFalse(dd.Synapses.Contains(s8));
            //Assert.AreEqual(6, dd.Synapses.Count);
            string TestResult;
            if (dd.Synapses.Count == 6)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence, s2.Permanence, s3.Permanence,s4.Permanence,s5.Permanence,s6.Permanence,s7.Permanence,s8.Permanence};
            List<double> InputPermList = new List<double>
            { InputPerm[0], InputPerm[1], InputPerm[2], InputPerm[3],InputPerm[4],InputPerm[5],InputPerm[6], InputPerm[7] };


            string Comments;
            Comments = "Synapse count is " + dd.Synapses.Count + " because it destroys synpase for small negatve permanence is succesfull";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;

        }


        /// <summary>
        /// This unit test is testing the maximum permanence value set by the AdaptSegment method. 
        /// For the permanece value > 1.0, AdaptSegments will set permanence to maximum bound 1.0. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegment_PermanenceMaxBound()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double[] InputPerm = new double[] { 1.1 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Create a distal segment of a cell index 0 to learn sequence
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(15), InputPerm[0]);/// create a synapse on a dital segment of a cell with index 15 
                                                                            /// It results with permanence 1 of the segment's synapse if the synapse's presynaptic cell index 23 was active. 
                                                                            /// If it was not active, then it will decrement the permanence by 0.1

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 15 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Invoking AdaptSegments with the cell 15 whose presynaptic cell is 
                                                  /// considered to be Active in the previous cycle.
            Assert.AreEqual(1.0, s1.Permanence, 0.1);/// permanence is incremented for cell 15 from 0.9 to 1 as presynaptic cell was Active in the previous cycle.

            /// Now permanence should be at max
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 15 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Again calling AdaptSegments with the cell 15 whose presynaptic cell is 
                                                  /// considered to be Active again in the previous cycle.
            Assert.AreEqual(1.0, s1.Permanence, 0.1);/// Therefore permanence is again incremented for cell 15 from 1 to 1.1 as presynaptic cell was Active 
                                                     /// in the previous cycle. But due to permanence boundary set, 1.1 is set back to 1.
            string TestResult;
            if (s1.Permanence >= 0.1 && s1.Permanence <= 1.0)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            { InputPerm[0] };


            string Comments;
            Comments = "permanece value > 1.0, AdaptSegments will set permanence to maximum bound 1.0. is Successfull ";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// This unit test is testing the minimum permanence bound value set by the AdaptSegment method. 
        /// For the permanece value < 0, AdaptSegments will set permanence to minimum bound 0.
        /// </summary>

        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string, string> TestAdaptSegmentPermanenceMinBound()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { 0.1 };

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));

            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[0]);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsFalse(dd.Synapses.Contains(s1)); /// assert condition to check does DistalDendrite contains the synapse s1

            string TestResult;
            if (dd.Synapses.Count == 0)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string, string>> result = new List<Tuple<List<double>, List<double>, string, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence };
            List<double> InputPermList = new List<double>
            { InputPerm[0]};

            string Comments;
            Comments = "Synapse count is " + dd.Synapses.Count + " it destroys synpase for minimum bound successfully" +
                "and permanence value remains the same";

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult, Comments);
            result.Add(tuple);
            return tuple;

        }


        /// <summary>
        /// Test case to check if cellIndexes is a valid array:
        /// This test sets up a Connections object, initializes cellIndexes with the values [0, 2, 4], and initializes 
        /// expectedCells with an array containing the 1st, 3rd, and 5th elements of the Cells array in the Connections
        /// object. The GetCells method is then called with cellIndexes, and the result is compared to expectedCells 
        /// using CollectionAssert.AreEqual.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void GetCells_WithValidArray_ReturnsExpectedCells()
        {
            // Arrange
            Connections cn = new Connections();
            int[] cellIndexes = new int[] { 0, 2, 4 };
            cn.Cells = new Cell[5];
            Cell[] expectedCells = new Cell[] { cn.Cells[0], cn.Cells[2], cn.Cells[4] };

            // Act
            Cell[] result = cn.GetCells(cellIndexes);

            // Assert
            CollectionAssert.AreEqual(expectedCells, result);
        }

        /// <summary>
        /// Test used to check that the result array is equal to the expectedCells array, which is an empty array in this case.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void GetCells_WithEmptyArray_ReturnsEmptyArray1()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            int[] cellIndexes = new int[0];
            Cell[] expectedCells = new Cell[0];

            // Act
            Cell[] result = cn.GetCells(cellIndexes);

            // Assert
            CollectionAssert.AreEqual(expectedCells, result);
        }



        #endregion
    }
}
