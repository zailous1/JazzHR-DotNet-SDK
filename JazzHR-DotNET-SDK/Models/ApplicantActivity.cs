using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents an activity associated with an applicant.
    /// </summary>
    [JsonObject]
    public class ApplicantActivity
    {
        /// <summary>
        /// Gets or sets the ID of the activity.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the activity.
        /// </summary>
        [JsonProperty("activity")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the activity.
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the time of the activity.
        /// </summary>
        [JsonProperty("time")]
        public string? Time { get; set; }
    }

}
