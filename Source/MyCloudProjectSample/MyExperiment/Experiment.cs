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
            Tuple<List<double>, List<double>, string> PermDataList = null;
            List<Tuple<string, string, List<double>, List<double>, string>> AdaptSegmentsList = new List<Tuple<string, string, List<double>, List<double>, string>>();
            Tuple<int, int, string> SynapseCount = null;
            List<Tuple<string, string, int, int, string>> SegmentCount = new List<Tuple<string, string, int, int, string>>();
            int index = 0;// Index to keep track of the position in the datastore array
                          // Set the LicenseContext before using the EPPlus library
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExperimentResult result = new ExperimentResult("damir", "0")
            {
                Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            };
            ExcelWriter excelreport = new ExcelWriter();

            if (inputFile == "adaptsegmentstests")
            {
                ///******************************************************** Unit Tests By Jishnu Shivaraman ***************************************************************//
                ///******************************************************** TestCase 1 ***************************************************************//
                PermDataList = TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive();
                res.ExperimentName = "TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("1", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);


                ///******************************************************** TestCase 2 ***************************************************************//
                PermDataList = TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive();
                res.ExperimentName = "TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("2", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);
                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 3 ***************************************************************//
                PermDataList = TestAdaptSegment_PermanenceIsLimitedWithinRange();
                res.ExperimentName = "TestAdaptSegment_PermanenceIsLimitedWithinRange";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("3", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);


                ///******************************************************** TestCase 4 ***************************************************************//
                PermDataList = TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity();
                res.ExperimentName = "TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("4", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);

                ///******************************************************** TestCase 5 ***************************************************************//
                SynapseCount = TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment();
                res.ExperimentName = "TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                SegmentCount.Add(Tuple.Create("5", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, SegmentCount: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);

                ///******************************************************** TestCase 6 ***************************************************************//
                SynapseCount = TestAdaptSegment_MatchingSegmentAndActiveSegmentState();
                res.ExperimentName = "TestAdaptSegment_MatchingSegmentAndActiveSegmentState";
                res.SynapseCount = SynapseCount.Item1;
                res.SegmentCount = SynapseCount.Item2;
                res.TestCaseResults = SynapseCount.Item3;
                SegmentCount.Add(Tuple.Create("6", res.ExperimentName, res.SynapseCount, res.SegmentCount, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", SegmentCount.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,SynapseCount: {tuple.Item3}, SegmentCount: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);

                ///******************************************************** Kavya ***************************************************************//
                ///******************************************************** TestCase 1 ***************************************************************//

                PermDataList = TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues();
                res.ExperimentName = "TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("7", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);
                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);


                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);

                ///******************************************************** TestCase 2 ***************************************************************//

                PermDataList = TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues();
                res.ExperimentName = "TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues";
                res.InputPermList = PermDataList.Item1;
                res.UpdatedPermList = PermDataList.Item2;
                res.TestCaseResults = PermDataList.Item3;
                AdaptSegmentsList.Add(Tuple.Create("8", res.ExperimentName, res.InputPermList, res.UpdatedPermList, res.TestCaseResults));
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase No: {tuple.Item1}, TestCase Name: {tuple.Item2} ,InputPermanence: {tuple.Item3}, UpdatedPermanence: {tuple.Item4}, InputPermanenceValue: {tuple.Item5}"));
                Console.WriteLine(res.Perm_Array);
                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(AdaptSegmentsList);


                // Now you have PermValueList
                res.excelData = excelreport.WriteTestOutputDataToExcel(SegmentCount);


            }

            /*switch (inputFile)
            {
            }*/
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

        ///******************************************************** Unit Tests By Jishnu Shivaraman ***************************************************************//


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
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive()
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

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
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
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive()
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

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
            result.Add(tuple);
            return tuple;
        }

        /// <summary>
        /// Test to check if the permanence of a synapse is limited within the range of 0 to 1.0.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_PermanenceIsLimitedWithinRange()
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

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
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
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity()
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

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
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

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
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
        public Tuple<int, int, string> TestAdaptSegment_SegmentState_WhenMaximumSynapsesPerSegment()
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

            Boolean? testResult = (NoOfSegments == 1 && NoOfSynapses == 225) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string>> result = new List<Tuple<int, int, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string> tuple = Tuple.Create(NoOfSegments, NoOfSynapses, TestResult);
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
        public Tuple<int, int, string> TestAdaptSegment_MatchingSegmentAndActiveSegmentState()
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

            Boolean? testResult = (NoOfSegments == 5 && NoOfSynapses == 1 && activeSegments == 0 &&
                matchingSegments == 0) ? (bool?)true : (bool?)false;
            string TestResult;
            if (testResult == true) { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<int, int, string>> result = new List<Tuple<int, int, string>>();
            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<int, int, string> tuple = Tuple.Create(NoOfSegments, NoOfSynapses, TestResult);
            result.Add(tuple);
            return tuple;
        }


        ///******************************************** Unit Test Cases by Kavya Hirebelaguli Chandrashekar*********************************************************///

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
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues()
        {

            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections(); ///The connections object holds the infrastructure, and is used by both the SpatialPooler, TemporalMemory.
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);  ///use connection for specified object to build and implement algoarithm 

            double[] InputPerm = new double[] { 0.0000000967, 0.0000001, -0.00000001 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Created a Distal dendrite segment of a cell0
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm[1]); /// Created a synapse on a distal segment of a cell index 23
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), InputPerm[2]);/// Created a synapse on a distal segment of a cell index 24
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(43), InputPerm[3]);
            /// Invoking AdaptSegments with only the cells with index 23 and 37
            ///whose presynaptic cell is considered to be Active in the previous cycle
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24, 43 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsTrue(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsTrue(dd.Synapses.Contains(s1));/// assert condition to check does DistalDendrite contains the synapse s1
            Assert.IsTrue(dd.Synapses.Contains(s3));/// assert condition to check does DistalDendrite contains the synapse s1
            //Assert.AreEqual(3, dd.Synapses.Count);  /// synapses count check in DistalDendrite

            string TestResult;
            if (dd.Synapses.Count == 3) 
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
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
        public Tuple<List<double>, List<double>, string> TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            double[] InputPerm = new double[] { -0.199991, -0.29999 };
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), -0.199991);
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), -0.29999);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsFalse(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsFalse(dd.Synapses.Contains(s1)); /// assert condition to check does DistalDendrite contains the synapse s2
            //Assert.AreEqual(0, dd.Synapses.Count);  /// synapses count check in DistalDendrite

            string TestResult;
            if (dd.Synapses.Count == 0)
            { TestResult = "PASSED"; }// The assertion condition is met, set the result to Passed
            else { TestResult = "FAILED"; }// The assertion condition is not met, set the result to Failed

            List<Tuple<List<double>, List<double>, string>> result = new List<Tuple<List<double>, List<double>, string>>();
            List<double> synPermList = new List<double>
            {s1.Permanence};
            List<double> InputPermList = new List<double>
            {InputPerm[0]};

            // Add a new tuple if the list doesn't have an existing tuple at the current index
            Tuple<List<double>, List<double>, string> tuple = Tuple.Create(InputPermList, synPermList, TestResult);
            result.Add(tuple);
            return tuple;
        }


        /// <summary>
        /// The below test checks for exception throwing in case of connections, DistalDendrites object is null. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void TestAdaptSegment_ShouldThrow_DD_ObjectShouldNotBeNUllException()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), 0.1);

            try
            {
                TemporalMemory.AdaptSegment(cn, null, cn.GetCells(new int[] { 23 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);
            }
            catch (NullReferenceException ex)
            {
                Assert.AreEqual(DISTALDENDRITE_CANNOT_BE_NULL, ex.Message);
            }
        }

        /// <summary>
        /// This unit test is testing the maximum permanence value set by the AdaptSegment method. 
        /// For the permanece value > 1.0, AdaptSegments will set permanence to maximum bound 1.0. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void TestAdaptSegment_PermanenceMaxBound()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Create a distal segment of a cell index 0 to learn sequence
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(15), 1.1);/// create a synapse on a dital segment of a cell with index 15 
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
