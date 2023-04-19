using RestSharp;
using System.Net;

namespace Zailous.JazzHR
{

    /// <summary>
    /// Implementation of the <see cref="IHttpClient"/> interface that uses the <see cref="RestSharp.RestClient"/> class to send HTTP requests and receive responses.
    /// </summary>
    internal class HttpClient : IHttpClient
    {
        private const string DOWNLOAD_URL = "https://app.jazz.co/files/download/";

        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _sandcastleTicket;
        private readonly IRestClient _restClient;
        private readonly JazzHRApiClientConfig _config;
        private readonly IRestClientFactory _restClientFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHrHttpClient"/> class with the specified configuration and logger.
        /// </summary>
        /// <param name="config">The configuration settings used to construct the client.</param>
        /// <param name="logger">The logger used to log requests and responses.</param>
        public HttpClient(JazzHRApiClientConfig config)
            : this(config, new RestClientFactory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHrHttpClient"/> class with the specified configuration and logger.
        /// </summary>
        /// <param name="config">The configuration settings used to construct the client.</param>
        /// <param name="restClientFactory">The factory used to create the rest client.</param>
        public HttpClient(
            JazzHRApiClientConfig config,
            IRestClientFactory restClientFactory)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _baseUrl = config.BaseUrl;
            _apiKey = config.APIKey;
            _sandcastleTicket = config.SandcastleTicket;
            _restClientFactory = restClientFactory;
            _restClient = _restClientFactory.CreateRestClient(_baseUrl);
        }

        /// <summary>
        /// Sends an HTTP GET request to the specified subpath and returns the response body as a string.
        /// </summary>
        /// <param name="subpath">The subpath of the URL to send the request to.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a string containing the response body, or null if the response did not contain a body.</returns>
        public async Task<string?> GetAsync(string subpath)
        {
            var request = new RestRequest(subpath, Method.Get);
            request.AddQueryParameter("apikey", _apiKey);

            var response = await _restClient.ExecuteAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error {response.StatusCode}: {response.StatusDescription}");
            }

            return response.Content;
        }

        /// <summary>
        /// Sends an HTTP POST request to the specified subpath with the specified body and returns the response body as a string.
        /// </summary>
        /// <param name="subpath">The subpath of the URL to send the request to.</param>
        /// <param name="body">The body of the request to send.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result is a string containing the response body, or null if the response did not contain a body.</returns>
        public async Task<string?> PostAsync(string subpath, string body)
        {
            var request = new RestRequest(subpath, Method.Post);
            request.AddBody(body);
            request.AddHeader("Content-Type", "application/json");

            var response = await _restClient.ExecuteAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error {response.StatusCode}: {response.StatusDescription}");
            }

            return response?.Content;
        }

        /// <summary>
        /// Sends a POST request with the specified body to the specified subpath and returns the response body as a string.
        /// </summary>
        /// <param name="subpath">The subpath of the API endpoint to send the request to.</param>
        /// <param name="body">The JSON body of the POST request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result is the response body as a string.</returns>
        public async Task<byte[]> DownloadAsync(string url)
        {
            var client = _restClientFactory.CreateRestClient(DOWNLOAD_URL);

            var memoryStream = new MemoryStream();
            var request = new RestRequest($"{DOWNLOAD_URL}resume?url={url}", Method.Get)
            {
                // Set the ResponseWriter property using an object initializer
                ResponseWriter = responseStream =>
                {
                    responseStream.CopyTo(memoryStream);
                    return memoryStream;
                }
            };

            // Add any required headers or parameters to the request, if needed
            request.AddHeader("Cookie", $"sandcastle_ticket={_sandcastleTicket}");

            var response = await client.ExecuteAsync(request).ConfigureAwait(false);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"{nameof(DownloadAsync)}: {response.StatusCode}");
            }

            return memoryStream.ToArray();
        }

    }
}