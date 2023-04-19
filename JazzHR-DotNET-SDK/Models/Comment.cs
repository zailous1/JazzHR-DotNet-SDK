using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    [JsonObject]
    public class Comment
    {
        /// <summary>
        /// Gets or sets the ID of the comment.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the author of the comment.
        /// </summary>
        [JsonProperty("author_id")]
        public string? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the author of the comment.
        /// </summary>
        [JsonProperty("author_name")]
        public string? AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the text of the comment.
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the date when the comment was created.
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the time when the comment was created.
        /// </summary>
        [JsonProperty("time")]
        public string? Time { get; set; }
    }

}
