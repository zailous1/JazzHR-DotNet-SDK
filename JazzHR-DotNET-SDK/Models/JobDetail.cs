using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a job detail.
    /// </summary>
    [JsonObject]
    public class JobDetail
    {
        /// <summary>
        /// Gets or sets the ID of the job.
        /// </summary>
        [JsonProperty("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the team ID of the job.
        /// </summary>
        [JsonProperty("team_id")]
        public string? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the title of the job.
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the country ID of the job.
        /// </summary>
        [JsonProperty("country_id")]
        public string? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the city of the job.
        /// </summary>
        [JsonProperty("city")]
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the state of the job.
        /// </summary>
        [JsonProperty("state")]
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the ZIP code of the job.
        /// </summary>
        [JsonProperty("zip")]
        public string? Zip { get; set; }

        /// <summary>
        /// Gets or sets the department of the job.
        /// </summary>
        [JsonProperty("department")]
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the description of the job.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the minimum salary of the job.
        /// </summary>
        [JsonProperty("minimum_salary")]
        public string? MinimumSalary { get; set; }

        /// <summary>
        /// Gets or sets the maximum salary of the job.
        /// </summary>
        [JsonProperty("maximum_salary")]
        public string? MaximumSalary { get; set; }

        /// <summary>
        /// Gets or sets the notes of the job.
        /// </summary>
        [JsonProperty("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the original open date of the job.
        /// </summary>
        [JsonProperty("original_open_date")]
        public string? OriginalOpenDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the job.
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating whether the job is sent to job boards.
        /// </summary>
        [JsonProperty("send_to_job_boards")]
        public string? SendToJobBoards { get; set; }

        /// <summary>
        /// Gets or sets the hiring lead of the job.
        /// </summary>
        [JsonProperty("hiring_lead")]
        public string? HiringLead { get; set; }

        /// <summary>
        /// Gets or sets the board code of the job.
        /// </summary>
        [JsonProperty("board_code")]
        public string? BoardCode { get; set; }

        /// <summary>
        /// Gets or sets the internal code of the job.
        /// </summary>
        [JsonProperty("internal_code")]
        public string? InternalCode { get; set; }

        /// <summary>
        /// Gets or sets the questionnaire of the job.
        /// </summary>
        [JsonProperty("questionnaire")]
        public string? Questionnaire { get; set; }

#pragma warning disable CS8618 // Custom converter ensures the property is never null
        /// <summary>
        /// Gets or sets the list of job applicants.
        /// </summary>
        [JsonProperty("job_applicants")]
        [JsonConverter(typeof(SingleOrArrayConverter<JobApplicant>))]
        public List<JobApplicant> JobApplicants { get; set; }
#pragma warning restore CS8618
    }
}
