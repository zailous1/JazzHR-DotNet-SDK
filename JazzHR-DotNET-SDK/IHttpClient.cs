namespace Zailous.JazzHR
{
    /// <summary>
    /// Defines methods for making HTTP requests.
    /// </summary>
    internal interface IHttpClient
    {
        /// <summary>
        /// Sends an HTTP GET request to the specified subpath and returns the response body as a string.
        /// </summary>
        /// <param name="subpath">The subpath to send the request to.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the response body as a string, or null if the request failed.</returns>
        Task<string?> GetAsync(string subpath);

        /// <summary>
        /// Sends an HTTP POST request to the specified subpath with the specified request body and returns the response body as a string.
        /// </summary>
        /// <param name="subpath">The subpath to send the request to.</param>
        /// <param name="body">The request body to send with the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the response body as a string.</returns>
        Task<string?> PostAsync(string subpath, string body);

        /// <summary>
        /// Downloads the content of the specified URL as a byte array.
        /// </summary>
        /// <param name="url">The URL to download the content from.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the downloaded content as a byte array.</returns>
        Task<byte[]> DownloadAsync(string url);
    }
}