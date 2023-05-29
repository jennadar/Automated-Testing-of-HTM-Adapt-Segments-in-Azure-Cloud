using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudProject.Common
{
    /// <summary>
    /// Defines the contract for all storage operations.
    /// </summary>
    public interface IStorageProvider
    {
        /// <summary>
        /// Downloads the input file for training. This file contains all required input for the experiment.
        /// The file is stored in the cloud or any other kind of store or database.
        /// </summary>
        /// <param name="fileName">The name of the file at some remote (cloud) location from where the file will be downloaded.</param>
        /// <returns>The fullpath name of the file as downloaded locally.</returns>
        Task<string> DownloadInputFile(string fileName);

        /// <summary>
        /// Uploadds the result of the experiment in the cloud or any other kind of store or database.
        /// </summary>
        /// <param name="fileName">The name of the file at some remote (cloud) location  where the file will be uploaded.</param>
        /// <returns>Not used. It can be null.</returns>
        Task<byte[]> UploadResultFile(string fileName, byte[] data);

        /// <summary>
        /// Uploads results of the experiment to the remote (cloud) location. For example the fileshare or as the entity to the table storage.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Not used.</returns>
        Task UploadExperimentResult(IExperimentResult result);
    }
}
