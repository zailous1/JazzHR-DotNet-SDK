namespace Zailous.JazzHR
{
    /// <summary>
    /// Configuration class for Jazz HR API client.
    /// </summary>
    public class JazzHRApiClientConfig
    {
        /// <summary>
        /// Gets or sets the base URL of the Jazz HR API.
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Gets or sets the API key used to authenticate with the Jazz HR API.
        /// </summary>
        public string APIKey { get; private set; }

        /// <summary>
        /// Gets or sets the Sandcastle ticket used to authenticate with the Jazz HR API.
        /// </summary>
        public string SandcastleTicket { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClientConfig"/> class with the specified base URL, API key, and Sandcastle ticket.
        /// </summary>
        /// <param name="baseUrl">The base URL of the Jazz HR API.</param>
        /// <param name="apiKey">The API key used to authenticate with the Jazz HR API.</param>
        /// <param name="sandcastleTicket">The Sandcastle ticket used to authenticate with the Jazz HR API.</param>
        public JazzHRApiClientConfig(string baseUrl, string apiKey, string sandcastleTicket)
        {
            BaseUrl = baseUrl;
            APIKey = apiKey;
            SandcastleTicket = sandcastleTicket;
        }
    }
}
