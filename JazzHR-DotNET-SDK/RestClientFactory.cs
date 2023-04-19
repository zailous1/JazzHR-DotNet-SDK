namespace Zailous.JazzHR
{
    /// <summary>
    /// A factory implementation for creating instances of <see cref="IRestClient"/> with a specified base URL.
    /// </summary>
    internal class RestClientFactory : IRestClientFactory
    {
        /// <inheritdoc />
        public IRestClient CreateRestClient(string baseUrl)
        {
            return new RestClientImpl(baseUrl);
        }
    }
}