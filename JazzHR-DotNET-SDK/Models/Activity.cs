using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents an activity with various properties.
    /// </summary>
    [JsonObject]
    public class Activity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the activity.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the activity.
        /// </summary>
        [JsonProperty("category")]
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the team identifier associated with the activity.
        /// </summary>
        [JsonProperty("team_id")]
        public string? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the activity.
        /// </summary>
        [JsonProperty("user_id")]
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the object identifier associated with the activity.
        /// </summary>
        [JsonProperty("object_id")]
        public string? ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the action performed in the activity.
        /// </summary>
        [JsonProperty("action")]
        public string? Action { get; set; }

        /// <summary>
        /// Gets or sets the date when the activity occurred.
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the time when the activity occurred.
        /// </summary>
        [JsonProperty("time")]
        public string? Time { get; set; }
    }
}
