using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloudProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NeoCortexApi;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NeoCortexApiSample;
using NeoCortexApi.Classifiers;

namespace MyExperiment
{
    /// <summary>
    /// This class implements the ML experiment that will run in the cloud. This is refactored code from my SE project.
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

            // YOU START HERE WITH YOUR SE EXPERIMENT!!!!

            ExperimentResult res = new ExperimentResult(this.config.GroupId, null);

            res.StartTimeUtc = DateTime.UtcNow;

            // Run your experiment code here.

            return Task.FromResult<IExperimentResult>(res); // TODO...
        }



        /// <inheritdoc/>
        public async Task RunQueueListener(CancellationToken cancelToken)
        {
            ExperimentResult res = new ExperimentResult("damir", "123")
            {
                //Timestamp = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),

                Accuracy = (float)0.5,
            };

            await storageProvider.UploadExperimentResult(res);


            QueueClient queueClient = new QueueClient(this.config.StorageConnectionString, this.config.Queue);


            while (cancelToken.IsCancellationRequested == false)
            {
                QueueMessage message = await queueClient.ReceiveMessageAsync();

                if (message != null)
                {
                    try
                    {

                        string msgTxt = Encoding.UTF8.GetString(message.Body.ToArray());

                        this.logger?.LogInformation($"Received the message {msgTxt}");

                        ExerimentRequestMessage request = JsonSerializer.Deserialize<ExerimentRequestMessage>(msgTxt);

                        var inputFile = await this.storageProvider.DownloadInputFile(request.InputFile);

                        IExperimentResult result = await this.Run(inputFile);

                        //TODO. do serialization of the result.
                        await storageProvider.UploadResultFile("outputfile.txt", null);

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

        class Program
        {
            /// <summary>
            /// This sample shows a typical experiment code for SP and TM.
            /// You must start this code in debugger to follow the trace.
            /// and TM.
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                //
                // Starts experiment that demonstrates how to learn spatial patterns.
                //SpatialPatternLearning experiment = new SpatialPatternLearning();
                //experiment.Run();

                //
                // Starts experiment that demonstrates how to learn spatial patterns.
                // SequenceLearning experiment = new SequenceLearning();
                // experiment.Run();

                RunMultiSimpleSequenceLearningExperiment();
                RunMultiSequenceLearningExperiment();
            }

            private static void RunMultiSimpleSequenceLearningExperiment()
            {
                Dictionary<string, List<double>> sequences = new Dictionary<string, List<double>>();

                sequences.Add("S1", new List<double>(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, }));
                sequences.Add("S2", new List<double>(new double[] { 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0 }));

                //
                // Prototype for building the prediction engine.
                MultiSequenceLearning experiment = new MultiSequenceLearning();
                var predictor = experiment.Run(sequences);
            }


            /// <summary>
            /// This example demonstrates how to learn two sequences and how to use the prediction mechanism.
            /// First, two sequences are learned.
            /// Second, three short sequences with three elements each are created und used for prediction. The predictor used by experiment privides to the HTM every element of every predicting sequence.
            /// The predictor tries to predict the next element.
            /// </summary>
            private static void RunMultiSequenceLearningExperiment()
            {
                Dictionary<string, List<double>> sequences = new Dictionary<string, List<double>>();

                //sequences.Add("S1", new List<double>(new double[] { 0.0, 1.0, 0.0, 2.0, 3.0, 4.0, 5.0, 6.0, 5.0, 4.0, 3.0, 7.0, 1.0, 9.0, 12.0, 11.0, 12.0, 13.0, 14.0, 11.0, 12.0, 14.0, 5.0, 7.0, 6.0, 9.0, 3.0, 4.0, 3.0, 4.0, 3.0, 4.0 }));
                //sequences.Add("S2", new List<double>(new double[] { 0.8, 2.0, 0.0, 3.0, 3.0, 4.0, 5.0, 6.0, 5.0, 7.0, 2.0, 7.0, 1.0, 9.0, 11.0, 11.0, 10.0, 13.0, 14.0, 11.0, 7.0, 6.0, 5.0, 7.0, 6.0, 5.0, 3.0, 2.0, 3.0, 4.0, 3.0, 4.0 }));

                sequences.Add("S1", new List<double>(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 2.0, 5.0, }));
                sequences.Add("S2", new List<double>(new double[] { 8.0, 1.0, 2.0, 9.0, 10.0, 7.0, 11.00 }));

                //
                // Prototype for building the prediction engine.
                MultiSequenceLearning experiment = new MultiSequenceLearning();
                var predictor = experiment.Run(sequences);

                //
                // These list are used to see how the prediction works.
                // Predictor is traversing the list element by element. 
                // By providing more elements to the prediction, the predictor delivers more precise result.
                var list1 = new double[] { 1.0, 2.0, 3.0, 4.0, 2.0, 5.0 };
                var list2 = new double[] { 2.0, 3.0, 4.0 };
                var list3 = new double[] { 8.0, 1.0, 2.0 };

                predictor.Reset();
                PredictNextElement(predictor, list1);

                predictor.Reset();
                PredictNextElement(predictor, list2);

                predictor.Reset();
                PredictNextElement(predictor, list3);
            }

            private static void PredictNextElement(Predictor predictor, double[] list)
            {
                Debug.WriteLine("------------------------------");

                foreach (var item in list)
                {
                    var res = predictor.Predict(item);

                    if (res.Count > 0)
                    {
                        foreach (var pred in res)
                        {
                            Debug.WriteLine($"{pred.PredictedInput} - {pred.Similarity}");
                        }

                        var tokens = res.First().PredictedInput.Split('_');
                        var tokens2 = res.First().PredictedInput.Split('-');
                        Debug.WriteLine($"Predicted Sequence: {tokens[0]}, predicted next element {tokens2.Last()}");
                    }
                    else
                        Debug.WriteLine("Nothing predicted :(");
                }

                Debug.WriteLine("------------------------------");
            }
        }

        #endregion
    }
}
