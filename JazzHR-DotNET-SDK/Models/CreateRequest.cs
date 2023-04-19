using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// An abstract base class for create request objects.
    /// </summary>
    [JsonObject]
    public abstract class CreateRequest
    {
        /// <summary>
        /// The API key to use for authentication.
        /// </summary>
        [JsonProperty("apikey")]
        public string? ApiKey { get; set; }
    }

}
