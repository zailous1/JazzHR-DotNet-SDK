namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the query parameters for retrieving a list of jobs.
    /// </summary>
    public class JobsVars : PathVars
    {
        /// <summary>
        /// Gets or sets the job title to filter by.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the recruiter to filter by.
        /// </summary>
        public string? Recruiter { get; set; }

        /// <summary>
        /// Gets or sets the job board code to filter by.
        /// </summary>
        public string? BoardCode { get; set; }

        /// <summary>
        /// Gets or sets the department to filter by.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the name of the hiring lead to filter by.
        /// </summary>
        public string? HiringLead { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team to filter by.
        /// </summary>
        public string? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the state to filter by.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the city to filter by.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the minimum open date to filter by.
        /// </summary>
        public DateTime? FromOpenDate { get; set; }

        /// <summary>
        /// Gets or sets the maximum open date to filter by.
        /// </summary>
        public DateTime? ToOpenDate { get; set; }

        /// <summary>
        /// Gets or sets the status to filter by.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include confidential jobs in the result.
        /// </summary>
        public bool? Confidential { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include private jobs in the result.
        /// </summary>
        public bool? Private { get; set; }

        /// <summary>
        /// Gets the query parameters as a list of tuples.
        /// </summary>
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("title", Title),
            ("recruiter", Recruiter),
            ("board_code", BoardCode),
            ("department", Department),
            ("hiring_lead", HiringLead),
            ("team_id", TeamId),
            ("state", State),
            ("city", City),
            ("from_open_date", FromOpenDate?.ToString("yyyy-MM-dd")),
            ("to_open_date", ToOpenDate?.ToString("yyyy-MM-dd")),
            ("status", Status),
            ("confidential", Confidential?.ToString().ToLowerInvariant()),
            ("private", Private?.ToString().ToLowerInvariant()),
            };
    }

}
