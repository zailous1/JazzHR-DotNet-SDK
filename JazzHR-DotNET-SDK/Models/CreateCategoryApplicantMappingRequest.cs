using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a request to create a mapping between a category and an applicant.
    /// </summary>
    [JsonObject]
    public class CreateCategoryApplicantMappingRequest : CreateRequest
    {
        /// <summary>
        /// Gets the ID of the applicant to map.
        /// </summary>
        [JsonProperty("applicant_id")]
        public string ApplicantId { get; private set; }

        /// <summary>
        /// Gets the ID of the category to map.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryApplicantMappingRequest"/> class with the specified applicant ID and category ID.
        /// </summary>
        /// <param name="applicantId">The ID of the applicant to map.</param>
        /// <param name="categoryId">The ID of the category to map.</param>
        /// <exception cref="ArgumentNullException">Thrown when either the <paramref name="applicantId"/> or <paramref name="categoryId"/> is <see langword="null"/>.</exception>
        public CreateCategoryApplicantMappingRequest(string applicantId, string categoryId)
        {
            _ = applicantId ?? throw new ArgumentNullException(nameof(applicantId));
            _ = categoryId ?? throw new ArgumentNullException(nameof(categoryId));

            ApplicantId = applicantId;
            CategoryId = categoryId;
        }
    }

}
