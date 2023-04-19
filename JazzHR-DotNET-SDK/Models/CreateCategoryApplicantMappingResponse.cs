using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the response from a request to create a mapping between a category and an applicant.
    /// </summary>
    [JsonObject]
    public class CreateCategoryApplicantMappingResponse
    {
        /// <summary>
        /// Gets or sets the ID of the mapping between a category and an applicant.
        /// </summary>
        [JsonProperty("pro2cat_id")]
        public long? Pro2catId { get; set; }
    }

}
