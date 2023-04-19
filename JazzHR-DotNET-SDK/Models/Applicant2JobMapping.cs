using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a mapping between an applicant and a job.
    /// </summary>
    [JsonObject]
    public class ApplicantJobMapping
    {
        /// <summary>
        /// Gets or sets the ID of the mapping.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the applicant in the mapping.
        /// </summary>
        [JsonProperty("applicant_id")]
        public string? ApplicantId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the job in the mapping.
        /// </summary>
        [JsonProperty("job_id")]
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the rating of the applicant for the job in the mapping.
        /// </summary>
        [JsonProperty("rating")]
        public string? Rating { get; set; }

        /// <summary>
        /// Gets or sets the ID of the workflow step in the mapping.
        /// </summary>
        [JsonProperty("workflow_step_id")]
        public string? WorkflowStepId { get; set; }

        /// <summary>
        /// Gets or sets the date of the mapping.
        /// </summary>
        [JsonProperty("date")]
        public string? Date { get; set; }
    }

}
