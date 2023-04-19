using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a category associated with an applicant.
    /// </summary>
    [JsonObject]
    public class ApplicantCategory
    {
        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        [JsonProperty("category_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the date the category was created.
        /// </summary>
        [JsonProperty("date_created")]
        public string? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the status of the category.
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }
    }

}
