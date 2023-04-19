using RestSharp;

namespace Zailous.JazzHR
{
    /// <summary>
    /// An implementation of the <see cref="IRestClient"/> interface that uses the <see cref="RestClient"/> class to send HTTP requests and receive responses.
    /// </summary>
    internal class RestClientImpl : IRestClient
    {
        private readonly RestClient _restClient;

        internal Uri BaseUrl { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClientImpl"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL for the REST client.</param>
        internal RestClientImpl(string baseUrl)
            : this(baseUrl, new RestClient(baseUrl))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClientImpl"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL for the REST client.</param>
        /// <param name="restClient">The REST Client implmentation.</param>/// 
        internal RestClientImpl(string baseUrl, RestClient restClient)
        {
            BaseUrl = new Uri(baseUrl);
            _restClient = restClient;
        }

        /// <inheritdoc />
        public async Task<RestResponse> ExecuteAsync(RestRequest request)
            => await _restClient.ExecuteAsync(request).ConfigureAwait(false);
    }
}