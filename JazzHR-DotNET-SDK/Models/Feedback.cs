using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a feedback item related to an applicant.
    /// </summary>
    [JsonObject]
    public class Feedback
    {
        /// <summary>
        /// Gets or sets the ID of the feedback item.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who authored the feedback item.
        /// </summary>
        [JsonProperty("author_id")]
        public string? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the text content of the feedback item.
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the date of the feedback item in "yyyy-MM-dd" format.
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the time of the feedback item in "HH:mm:ss" format.
        /// </summary>
        [JsonProperty("time")]
        public string? Time { get; set; }

        /// <summary>
        /// Gets or sets the privacy setting of the feedback item.
        /// </summary>
        [JsonProperty("privacy")]
        public string? Privacy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the feedback item is external.
        /// </summary>
        [JsonProperty("is_external")]
        public string? IsExternal { get; set; }
    }

}
