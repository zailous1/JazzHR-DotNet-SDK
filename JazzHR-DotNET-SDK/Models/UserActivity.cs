using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a user activity.
    /// </summary>
    [JsonObject]
    public class UserActivity
    {
        /// <summary>
        /// Gets or sets the activity ID.
        /// </summary>
        [JsonProperty("activity_id")]
        public string? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the activity description.
        /// </summary>
        [JsonProperty("activity")]
        public string? Activity { get; set; }

        /// <summary>
        /// Gets or sets the date of the activity.
        /// </summary>
        [JsonProperty("activity_date")]
        public string? ActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the time of the activity.
        /// </summary>
        [JsonProperty("activity_time")]
        public string? ActivityTime { get; set; }
    }

}
