using System.Text;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the path variables for an Applicants endpoint.
    /// </summary>
    public class ApplicantsVars : PathVars
    {
        /// <summary>
        /// Gets or sets the name of the applicant.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the city of the applicant.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the ID of the job associated with the applicant.
        /// </summary>
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the title of the job associated with the applicant.
        /// </summary>
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the ID of the recruiter associated with the applicant.
        /// </summary>
        public string? RecruiterId { get; set; }

        /// <summary>
        /// Gets or sets the apply date of the applicant.
        /// </summary>
        public DateTime? ApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the starting apply date of the applicants to be retrieved.
        /// </summary>
        public DateTime? FromApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the ending apply date of the applicants to be retrieved.
        /// </summary>
        public DateTime? ToApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the applicant.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the rating associated with the applicant.
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Gets the list of parameter names and values for the variables.
        /// </summary>
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("name", Name),
            ("city", City),
            ("job_id", JobId),
            ("job_title", JobTitle),
            ("recruiter_id", RecruiterId),
            ("apply_date", ApplyDate?.ToString("yyyy-MM-dd")),
            ("from_apply_date", FromApplyDate?.ToString("yyyy-MM-dd")),
            ("to_apply_date", ToApplyDate?.ToString("yyyy-MM-dd")),
            ("status", Status),
            ("rating", Rating.ToString()),
            };
    }

}
