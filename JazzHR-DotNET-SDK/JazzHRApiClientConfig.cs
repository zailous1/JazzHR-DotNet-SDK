namespace Zailous.JazzHR
{
    /// <summary>
    /// Configuration class for Jazz HR API client.
    /// </summary>
    public class JazzHRApiClientConfig
    {
        /// <summary>
        /// Gets or sets the API key used to authenticate with the Jazz HR API.
        /// </summary>
        public string APIKey { get; private set; }

        /// <summary>
        /// Gets or sets the Sandcastle ticket used to authenticate with the Jazz HR API.
        /// </summary>
        public string? SandcastleTicket { get; private set; }

        /// <summary>
        /// Gets or sets the Max Page Results to be returned in queries to the Jazz HR API.
        /// </summary>
        public int MaxPageResults { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClientConfig"/> class with the specified base URL, API key, and Sandcastle ticket.
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate with the Jazz HR API.</param>
        public JazzHRApiClientConfig(string apiKey)
            : this(apiKey, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClientConfig"/> class with the specified base URL, API key, and Sandcastle ticket.
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate with the Jazz HR API.</param>
        /// <param name="sandcastleTicket">The Sandcastle ticket used to authenticate with the Jazz HR API.</param>
        /// <param name="maxPageResults">The Max Page Results to be returned in queries to the Jazz HR API. Defaults to 100.</param>
        public JazzHRApiClientConfig(string apiKey, string? sandcastleTicket, int maxPageResults = 100)
        {
            APIKey = apiKey;
            SandcastleTicket = sandcastleTicket;
            MaxPageResults = maxPageResults;
        }
    }
}
