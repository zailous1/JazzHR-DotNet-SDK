using System.Text;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the path variables for an ApplicantJobMapping endpoint.
    /// </summary>
    public class ApplicantJobMappingVars : PathVars
    {
        /// <summary>
        /// Gets or sets the ID of the applicant associated with the mapping.
        /// </summary>
        public string? ApplicantId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the job associated with the mapping.
        /// </summary>
        public string? JobId { get; set; }

        /// <summary>
        /// Gets or sets the rating associated with the mapping.
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Gets or sets the workflow step ID associated with the mapping.
        /// </summary>
        public string? WorkflowStepId { get; set; }

        /// <summary>
        /// Gets the list of parameter names and values for the variables.
        /// </summary>
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("applicant_id", ApplicantId),
            ("job_id", JobId),
            ("rating", Rating.ToString()),
            ("workflow_step_id", WorkflowStepId),
            };
    }
}
