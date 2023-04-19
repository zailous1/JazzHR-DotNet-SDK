using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    [JsonObject]
    public class Category
    {
        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the category.
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the category.
        /// </summary>
        [JsonProperty("created_by")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date when the category was created.
        /// </summary>
        [JsonProperty("date_created")]
        public string? DateCreated { get; set; }
    }

}
