using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a job object.
    /// </summary>
    [JsonObject]
    public class Job
    {
        /// <summary>
        /// Gets or sets the ID of the job.
        /// </summary>
        [JsonProperty("job_id")]
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the hiring lead rating of the job.
        /// </summary>
        [JsonProperty("hiring_lead_rating")]
        public string? HiringLeadRating { get; set; }

        /// <summary>
        /// Gets or sets the average rating of the job.
        /// </summary>
        [JsonProperty("average_rating")]
        public string? AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the workflow step ID of the job.
        /// </summary>
        [JsonProperty("workflow_step_id")]
        public string? WorkflowStepId { get; set; }

        /// <summary>
        /// Gets or sets the title of the job.
        /// </summary>
        [JsonProperty("job_title")]
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the applicant progress of the job.
        /// </summary>
        [JsonProperty("applicant_progress")]
        public string? ApplicantProgress { get; set; }
    }

}
