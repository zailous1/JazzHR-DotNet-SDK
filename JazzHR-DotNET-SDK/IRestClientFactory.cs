namespace Zailous.JazzHR
{
    /// <summary>
    /// A factory interface for creating instances of <see cref="IRestClient"/> with a specified base URL.
    /// </summary>
    internal interface IRestClientFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IRestClient"/> with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL for the REST client.</param>
        /// <returns>An instance of <see cref="IRestClient"/> configured with the specified base URL.</returns>
        IRestClient CreateRestClient(string baseUrl);
    }
}