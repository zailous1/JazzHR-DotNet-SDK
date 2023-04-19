using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents an applicant who has applied for a job.
    /// </summary>
    [JsonObject]
    public class Applicant
    {
        /// <summary>
        /// Gets or sets the ID of the applicant.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the applicant.
        /// </summary>
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the applicant.
        /// </summary>
        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the applicant.
        /// </summary>
        [JsonProperty("prospect_phone")]
        public string? ProspectPhone { get; set; }

        /// <summary>
        /// Gets or sets the date on which the applicant applied for the job.
        /// </summary>
        [JsonProperty("apply_date")]
        public string? ApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the job for which the applicant applied.
        /// </summary>
        [JsonProperty("job_id")]
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the title of the job for which the applicant applied.
        /// </summary>
        [JsonProperty("job_title")]
        public string? JobTitle { get; set; }
    }

}
