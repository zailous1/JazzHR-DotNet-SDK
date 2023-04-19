using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    [JsonObject]
    public class User
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the date the user was created.
        /// </summary>
        [JsonProperty("date_created")]
        public string? DateCreated { get; set; }
    }

}
