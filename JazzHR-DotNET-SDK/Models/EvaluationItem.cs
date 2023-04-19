using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents an evaluation item for an applicant.
    /// </summary>
    [JsonObject]
    public class EvaluationItem
    {
        /// <summary>
        /// Gets or sets the ID of the evaluation item.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the evaluation item.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the evaluation item.
        /// </summary>
        [JsonProperty("category")]
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the rating of the evaluation item.
        /// </summary>
        [JsonProperty("rating")]
        public string? Rating { get; set; }

        /// <summary>
        /// Gets or sets the comment of the evaluation item.
        /// </summary>
        [JsonProperty("comment")]
        public string? Comment { get; set; }
    }

}
