using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the response from creating a note for an applicant.
    /// </summary>
    [JsonObject]
    public class CreateNoteResponse
    {
        /// <summary>
        /// The ID of the created note.
        /// </summary>
        [JsonProperty("comment_id")]
        public string? CommentId { get; set; }
    }
}
