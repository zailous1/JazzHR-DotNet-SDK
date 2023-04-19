using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a job applicant with their prospect ID and application date.
    /// </summary>
    [JsonObject]
    public class JobApplicant
    {
        /// <summary>
        /// The ID of the prospect.
        /// </summary>
        [JsonProperty("prospect_id")]
        public string? ProspectId { get; set; }

        /// <summary>
        /// The date on which the applicant applied for the job.
        /// </summary>
        [JsonProperty("apply_date")]
        public string? ApplyDate { get; set; }
    }

}
