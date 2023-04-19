using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the response from a category creation request.
    /// </summary>
    [JsonObject]
    public class CreateCategoryResponse
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        [JsonProperty("category_id")]
        public CategoryId? CategoryId { get; set; }
    }

}
