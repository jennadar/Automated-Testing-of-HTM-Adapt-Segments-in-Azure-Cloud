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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            List<Tuple<double, double, bool?>> PermData = null;
            int index = 0;// Index to keep track of the position in the datastore array
                          // Set the LicenseContext before using the EPPlus library
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExperimentResult result = new ExperimentResult("damir", "0")
            {
                Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
            };
            List<Tuple<string, double, double, bool?>> AdaptSegmentsList = new List<Tuple<string, double, double, bool?>>();

            if (inputFile == "adaptsegmentstests")
            {
                PermData = TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive();
                foreach (var entry in PermData)
                {
                    res.ExperimentName = "TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive";
                    res.UpdatedPerm = entry.Item1;
                    res.InputPerm = entry.Item2;
                    res.TestCaseResults = entry.Item3;
                    AdaptSegmentsList.Add(Tuple.Create(res.ExperimentName, res.InputPerm, res.UpdatedPerm, res.TestCaseResults));

                }
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase Name: {tuple.Item1} ,InputPermanence: {tuple.Item1}, UpdatedPermanence: {tuple.Item2}, InputPermanenceValue: {tuple.Item3}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList with pairs of (input, PermValueList)
                res.excelData = WriteEncodedDataToExcel(AdaptSegmentsList);

                PermData = TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive();
                foreach (var entry in PermData)
                {
                    res.ExperimentName = "TestAdaptSegment_PermanenceWekened_IfPresynapticCellWasInActive";
                    res.UpdatedPerm = entry.Item1;
                    res.InputPerm = entry.Item2;
                    res.TestCaseResults = entry.Item3;
                    AdaptSegmentsList.Add(Tuple.Create(res.ExperimentName, res.InputPerm, res.UpdatedPerm, res.TestCaseResults));

                }
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase Name: {tuple.Item1} ,InputPermanence: {tuple.Item1}, UpdatedPermanence: {tuple.Item2}, InputPermanenceValue: {tuple.Item3}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList with pairs of (input, PermValueList)
                res.excelData = WriteEncodedDataToExcel(AdaptSegmentsList);

                
                    PermData = TestAdaptSegment_PermanenceIsLimitedWithinRange();
                foreach (var entry in PermData)
                {
                    res.ExperimentName = "TestAdaptSegment_PermanenceIsLimitedWithinRange";
                    res.UpdatedPerm = entry.Item1;
                    res.InputPerm = entry.Item2;
                    res.TestCaseResults = entry.Item3;
                    AdaptSegmentsList.Add(Tuple.Create(res.ExperimentName, res.InputPerm, res.UpdatedPerm, res.TestCaseResults));

                }
                res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase Name: {tuple.Item1} ,InputPermanence: {tuple.Item1}, UpdatedPermanence: {tuple.Item2}, InputPermanenceValue: {tuple.Item3}"));
                Console.WriteLine(res.Perm_Array);

                // Now you have PermValueList with pairs of (input, PermValueList)
                res.excelData = WriteEncodedDataToExcel(AdaptSegmentsList);

            }

            /*switch (inputFile)
            {
                    case "Testcase1":
                    PermData = TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive();
                    foreach (var entry in PermData)
                    {
                        res.ExperimentName = "TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive";
                        res.UpdatedPerm = entry.Item1;
                        res.InputPerm = entry.Item2;
                        res.TestCaseResults = entry.Item3;
                        AdaptSegmentsList.Add(Tuple.Create(res.ExperimentName, res.InputPerm, res.UpdatedPerm, res.TestCaseResults));

                    }
                    res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase Name: {tuple.Item1} ,InputPermanence: {tuple.Item1}, UpdatedPermanence: {tuple.Item2}, InputPermanenceValue: {tuple.Item3}"));
                    Console.WriteLine(res.Perm_Array);

                    // Now you have PermValueList with pairs of (input, PermValueList)
                    res.excelData = WriteEncodedDataToExcel(AdaptSegmentsList);
                    break;

                case "Testcase2":
                    PermData = TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive();
                    foreach (var entry in PermData)
                    {
                        res.ExperimentName = "TestAdaptSegment_PermanenceWekened_IfPresynapticCellWasInActive";
                        res.UpdatedPerm = entry.Item1;
                        res.InputPerm = entry.Item2;
                        res.TestCaseResults = entry.Item3;
                        AdaptSegmentsList.Add(Tuple.Create(res.ExperimentName, res.InputPerm, res.UpdatedPerm, res.TestCaseResults));

                    }
                    res.Perm_Array = string.Join(", ", AdaptSegmentsList.Select(tuple => $"TestCase Name: {tuple.Item1} ,InputPermanence: {tuple.Item1}, UpdatedPermanence: {tuple.Item2}, InputPermanenceValue: {tuple.Item3}"));
                    Console.WriteLine(res.Perm_Array);

                    // Now you have PermValueList with pairs of (input, PermValueList)
                    res.excelData = WriteEncodedDataToExcel(AdaptSegmentsList);
                    break;

                case "Testcase3":
                TestAdaptSegment_PermanenceIsLimitedWithinRange();
                break;

            case "Testcase4":
                TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity();
                break;

            case "Testcase5":
                GetCells_WithEmptyArray_ReturnsEmptyArray();
                break;

            case "Testcase6":
                TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues();
                break;

            case "Testcase7":
                TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues();
                break;

            case "Testcase8":
                TestAdaptSegment_ShouldThrow_DD_ObjectShouldNotBeNUllException();
                break;

            case "Testcase9":
                TestAdaptSegment_PermanenceMaxBound();
                break;


            case "Testcase10":
                GetCells_WithValidArray_ReturnsExpectedCells();
                break;



            }*/
            return Task.FromResult<IExperimentResult>(res); // TODO...
        }


        public byte[] WriteEncodedDataToExcel(List<Tuple<string, double, double, bool?>> PermValueList)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("TestResults");
                ExperimentResult res = new ExperimentResult(this.config.GroupId, null);
                // Add headers
                worksheet.Cells[1, 1].Value = "TestCase Name";
                worksheet.Cells[1, 2].Value = "Input Permenance Value";
                worksheet.Cells[1, 3].Value = "Updated Permenance Value";
                worksheet.Cells[1, 4].Value = "Test Case Results";

                // Set the fill color and font color for the header row
                var headerCells = worksheet.Cells["A1:D1"];
                headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerCells.Style.Fill.BackgroundColor.SetColor(Color.LightGoldenrodYellow); // Set your desired background color
                headerCells.Style.Font.Color.SetColor(Color.Black); // Set your desired font color

                // Fill data
                for (int i = 0; i < PermValueList.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = PermValueList[i].Item1;
                    worksheet.Cells[i + 2, 2].Value = PermValueList[i].Item2;
                    worksheet.Cells[i + 2, 3].Value = PermValueList[i].Item3;
                    worksheet.Cells[i + 2, 4].Value = PermValueList[i].Item4;

                    // Set the color of the "Test Case Results" cell based on the boolean value
                    var resultCell = worksheet.Cells[i + 2, 4];
                    bool? testResult = PermValueList[i].Item4;
                    if (testResult.HasValue)
                    {
                        resultCell.Value = testResult.Value;
                        resultCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        resultCell.Style.Font.Color.SetColor(testResult.Value ? Color.Black : Color.Black);
                        resultCell.Style.Fill.BackgroundColor.SetColor(testResult.Value ? Color.LightGreen : Color.LightPink);
                    }
                    else
                    {
                        resultCell.Value = "N/A";
                    }
                }

                // Auto fit columns
                worksheet.Cells.AutoFitColumns();

                // Save the Excel package to a memory stream
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

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
        public List<Tuple<double, double, bool?>> TestAdaptSegment_PermanenceStrengthened_IfPresynapticCellWasActive()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double InputPerm = 0.1;
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm);

            // Invoking AdaptSegments with only the cells with index 23
            /// whose presynaptic cell is considered to be Active in the
            /// previous cycle and presynaptic cell is Inactive for the cell 477
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);

            //Assert
            /// permanence is incremented for presynaptic cell 23 from 
            /// 0.1 to 0.2 as presynaptic cell was InActive in the previous cycle
            Assert.AreEqual(0.2, s1.Permanence);
            Boolean? testResult;
            if (0.2 == s1.Permanence)
            {
                // The assertion condition is met, set the result to true
                testResult = true;
            }
            else
            {
                // The assertion condition is not met, set the result to false
                testResult = false;
            }

            // Creating a list of MyResult objects with the desired data
            List<Tuple<double, double, bool?>> result = new List<Tuple<double, double, bool?>>();
            result.Add(Tuple.Create(s1.Permanence, InputPerm, testResult));

            Console.WriteLine(s1.Permanence);
            return result;
        }


        /// <summary>
        /// Testing the scenario where a synapse's presynaptic cell was not active in the previous cycle, 
        /// so the AdaptSegment method should decrease the permanence value of that synapse by 
        /// permanenceDecrement amount.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public List<Tuple<double, double, bool?>> TestAdaptSegment_PermanenceWeakened_IfPresynapticCellWasInActive()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double InputPerm = 0.9;
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(500), InputPerm);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 57 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);
            //Assert
            /// /// permanence is decremented for presynaptie cell 500 from 
            /// 0.9 to 0.8 as presynaptic cell was InActive in the previous cycle
            /// But the synapse is not destroyed as permanence > HtmConfig.Epsilon
            Assert.AreEqual(0.8, s1.Permanence);
            Boolean? testResult;
            if (0.8 == s1.Permanence)
            {
                // The assertion condition is met, set the result to true
                testResult = true;
            }
            else
            {
                // The assertion condition is not met, set the result to false
                testResult = false;
            }

            // Creating a list of MyResult objects with the desired data
            List<Tuple<double, double, bool?>> result = new List<Tuple<double, double, bool?>>();
            result.Add(Tuple.Create(s1.Permanence, InputPerm, testResult));

            Console.WriteLine(s1.Permanence);
            return result;
        }

        /// <summary>
        /// Test to check if the permanence of a synapse is limited within the range of 0 to 1.0.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public List<Tuple<double, double, bool?>> TestAdaptSegment_PermanenceIsLimitedWithinRange()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);
            double InputPerm = 2.5;
            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), InputPerm);

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
            if (testResult == true) { testResult = true; }// The assertion condition is met, set the result to true
            else { testResult = false; }// The assertion condition is not met, set the result to false

            // Creating a list of MyResult objects with the desired data
            List<Tuple<double, double, bool?>> result = new List<Tuple<double, double, bool?>>();
            result.Add(Tuple.Create(s1.Permanence, InputPerm, testResult));
            Console.WriteLine(s1.Permanence);
            return result;
        }

        /// <summary>
        /// Validate the behavior of the AdaptSegment method of the TemporalMemory class.
        /// The test initializes a TemporalMemory object, creates a Connection object, sets the default parameters, 
        /// and initializes the TemporalMemory. It then creates a DistalDendrite object with three synapses, each connected 
        /// to different cells. 
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void TestAdaptSegment_UpdatesSynapsePermanenceValues_BasedOnPreviousCycleActivity()
        {
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();///The connections object holds the infrastructure, and is used by both the SpatialPooler, TemporalMemory.
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);///use connection for specified object to build and implement algoarithm 

            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));/// Created a Distal dendrite segment of a cell0
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), 0.5);/// Created a synapse on a distal segment of a cell index 23
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(37), 0.6);/// Created a synapse on a distal segment of a cell index 37
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(477), 0.9);/// Created a synapse on a distal segment of a cell index 477

            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 37 }), cn.HtmConfig.PermanenceIncrement,
                cn.HtmConfig.PermanenceDecrement);/// Invoking AdaptSegments with only the cells with index 23 and 37
                                                  /// whose presynaptic cell is considered to be Active in the
                                                  /// previous cycle and presynaptic cell is Inactive for the cell 477

            Assert.AreEqual(0.6, s1.Permanence, 0.01);/// permanence is incremented for cell 23 from 0.5 to 0.6 as presynaptic cell was Active in the previous cycle.
            Assert.AreEqual(0.7, s2.Permanence, 0.01);/// permanence is incremented for cell 37 from 0.6 to 0.7 as presynaptic cell was Active in the previous cycle.
            Assert.AreEqual(0.8, s3.Permanence, 0.01);/// permanence is decremented for cell 477 from 0.5 to 0.6 as presynaptic cell was InActive in the previous cycle.
        }


        /// <summary>
        /// Test used to check that the result array is equal to the expectedCells array, which is an empty array in this case.
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void GetCells_WithEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            int[] cellIndexes = new int[0];
            Cell[] expectedCells = new Cell[0];

            // Act
            Cell[] result = cn.GetCells(cellIndexes);

            // Assert
            //CollectionAssert.AreEqual(expectedCells, result);
            Console.WriteLine(result);
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
        public void TestAdaptSegment_DoesNotDestroySynapses_ForSmallNNegativePermanenceValues()
        {

            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections(); ///The connections object holds the infrastructure, and is used by both the SpatialPooler, TemporalMemory.
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);  ///use connection for specified object to build and implement algoarithm 


            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0)); /// Created a Distal dendrite segment of a cell0
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), 0.0000000967); /// Created a synapse on a distal segment of a cell index 23
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), 0.0000001);/// Created a synapse on a distal segment of a cell index 24
            Synapse s3 = cn.CreateSynapse(dd, cn.GetCell(43), -0.00000001);
            /// Invoking AdaptSegments with only the cells with index 23 and 37
            ///whose presynaptic cell is considered to be Active in the previous cycle
            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24, 43 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsTrue(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsTrue(dd.Synapses.Contains(s1));/// assert condition to check does DistalDendrite contains the synapse s1
            Assert.IsTrue(dd.Synapses.Contains(s3));/// assert condition to check does DistalDendrite contains the synapse s1
            Assert.AreEqual(3, dd.Synapses.Count);  /// synapses count check in DistalDendrite

        }
        /// <summary>
        /// TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues
        /// here permanence comes lesser than  HtmConfig.EPSILON
        /// hence it  destroys synapses
        ///take count of the synapses inside DistalDendrite which comes to zero
        /// </summary>
        [TestMethod]
        [TestCategory("Prod")]
        public void TestAdaptSegment_DestroySynapses_WithNegativePermanenceValues()
        {
            // Arrange
            TemporalMemory tm = new TemporalMemory();
            Connections cn = new Connections();
            Parameters p = Parameters.getAllDefaultParameters();
            p.apply(cn);
            tm.Init(cn);


            DistalDendrite dd = cn.CreateDistalSegment(cn.GetCell(0));
            Synapse s1 = cn.CreateSynapse(dd, cn.GetCell(23), -0.199991);
            Synapse s2 = cn.CreateSynapse(dd, cn.GetCell(24), -0.29999);


            TemporalMemory.AdaptSegment(cn, dd, cn.GetCells(new int[] { 23, 24 }), cn.HtmConfig.PermanenceIncrement, cn.HtmConfig.PermanenceDecrement);


            Assert.IsFalse(dd.Synapses.Contains(s2)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.IsFalse(dd.Synapses.Contains(s1)); /// assert condition to check does DistalDendrite contains the synapse s2
            Assert.AreEqual(0, dd.Synapses.Count);  /// synapses count check in DistalDendrite
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
