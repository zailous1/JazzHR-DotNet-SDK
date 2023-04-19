using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a hire object with details about an applicant being hired for a job.
    /// </summary>
    [JsonObject]
    public class Hire
    {
        /// <summary>
        /// Gets or sets the unique identifier of the hire.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the applicant being hired.
        /// </summary>
        [JsonProperty("applicant_id")]
        public string? ApplicantId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the job for which the applicant is being hired.
        /// </summary>
        [JsonProperty("job_id")]
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the workflow step associated with the hire.
        /// </summary>
        [JsonProperty("workflow_step_id")]
        public string? WorkflowStepId { get; set; }

        /// <summary>
        /// Gets or sets the name of the workflow step associated with the hire.
        /// </summary>
        [JsonProperty("workflow_step_name")]
        public string? WorkflowStepName { get; set; }

        /// <summary>
        /// Gets or sets the date on which the applicant was hired.
        /// </summary>
        [JsonProperty("hired_date")]
        public string? HiredDate { get; set; }

        /// <summary>
        /// Gets or sets the time at which the applicant was hired.
        /// </summary>
        [JsonProperty("hired_time")]
        public string? HiredTime { get; set; }
    }
}
