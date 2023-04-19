using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a category ID.
    /// </summary>
    [JsonObject]
    public class CategoryId
    {
        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated entity.
        /// </summary>
        [JsonProperty("aid")]
        public int? Aid { get; set; }
    }

}
