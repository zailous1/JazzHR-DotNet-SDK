using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents detailed information about an applicant.
    /// </summary>
    [JsonObject]
    public class ApplicantDetail
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
        /// Gets or sets the email of the applicant.
        /// </summary>
        [JsonProperty("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the applicant.
        /// </summary>
        [JsonProperty("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the location of the applicant.
        /// </summary>
        [JsonProperty("location")]
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the applicant.
        /// </summary>
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the LinkedIn URL of the applicant.
        /// </summary>
        [JsonProperty("linkedin_url")]
        public string? LinkedinUrl { get; set; }

        /// <summary>
        /// Gets or sets the EEO gender of the applicant.
        /// </summary>
        [JsonProperty("eeo_gender")]
        public string? EeoGender { get; set; }

        /// <summary>
        /// Gets or sets the EEO race of the applicant.
        /// </summary>
        [JsonProperty("eeo_race")]
        public string? EeoRace { get; set; }

        /// <summary>
        /// Gets or sets the EEO disability of the applicant.
        /// </summary>
        [JsonProperty("eeo_disability")]
        public string? EeoDisability { get; set; }

        /// <summary>
        /// Gets or sets the website of the applicant.
        /// </summary>
        [JsonProperty("website")]
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets the desired salary of the applicant.
        /// </summary>
        [JsonProperty("desired_salary")]
        public string? DesiredSalary { get; set; }

        /// <summary>
        /// Gets or sets the desired start date of the applicant.
        /// </summary>
        [JsonProperty("desired_start_date")]
        public string? DesiredStartDate { get; set; }

        /// <summary>
        /// Gets or sets the referrer of the applicant.
        /// </summary>
        [JsonProperty("referrer")]
        public string? Referrer { get; set; }

        /// <summary>
        /// Gets or sets the languages of the applicant.
        /// </summary>
        [JsonProperty("languages")]
        public string? Languages { get; set; }

        /// <summary>
        /// Gets or sets the WMYU of the applicant.
        /// </summary>
        [JsonProperty("wmyu")]
        public string? Wmyu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant has a driver license.
        /// </summary
        [JsonProperty("has_driver_license")]
        public string? HasDriverLicense { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant is willing to relocate.
        /// </summary>
        [JsonProperty("willing_to_relocate")]
        public string? WillingToRelocate { get; set; }

        /// <summary>
        /// Gets or sets the citizenship status of the applicant.
        /// </summary>
        [JsonProperty("citizenship_status")]
        public string? CitizenshipStatus { get; set; }

        /// <summary>
        /// Gets or sets the education level of the applicant.
        /// </summary>
        [JsonProperty("education_level")]
        public string? EducationLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant has a CDL.
        /// </summary>
        [JsonProperty("has_cdl")]
        public string? HasCdl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant is over 18 years old.
        /// </summary>
        [JsonProperty("over_18")]
        public string? Over18 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant can work weekends.
        /// </summary>
        [JsonProperty("can_work_weekends")]
        public string? CanWorkWeekends { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant can work evenings.
        /// </summary>
        [JsonProperty("can_work_evenings")]
        public string? CanWorkEvenings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant can work overtime.
        /// </summary>
        [JsonProperty("can_work_overtime")]
        public string? CanWorkOvertime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant has a felony.
        /// </summary>
        [JsonProperty("has_felony")]
        public string? HasFelony { get; set; }

        /// <summary>
        /// Gets or sets the explanation for the applicant's felony.
        /// </summary>
        [JsonProperty("felony_explanation")]
        public string? FelonyExplanation { get; set; }

        /// <summary>
        /// Gets or sets the Twitter username of the applicant.
        /// </summary>
        [JsonProperty("twitter_username")]
        public string? TwitterUsername { get; set; }

        /// <summary>
        /// Gets or sets the college GPA of the applicant.
        /// </summary>
        [JsonProperty("college_gpa")]
        public string? CollegeGpa { get; set; }

        /// <summary>
        /// Gets or sets the college of the applicant.
        /// </summary>
        [JsonProperty("college")]
        public string? College { get; set; }

        /// <summary>
        /// Gets or sets the references of the applicant.
        /// </summary>
        [JsonProperty("references")]
        public string? References { get; set; }

        /// <summary>
        /// Gets or sets the notes about the applicant.
        /// </summary>
        [JsonProperty("notes")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the date the applicant applied.
        /// </summary>
        [JsonProperty("apply_date")]
        public string? ApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the number of comments associated with the applicant.
        /// </summary>
        [JsonProperty("comments_count")]
        public string? CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets the source of the applicant.
        /// </summary>
        [JsonProperty("source")]
        public string? Source { get; set; }

        /// <summary>
        /// Gets or sets the ID of the recruiter associated with the applicant.
        /// </summary>
        [JsonProperty("recruiter_id")]
        public string? RecruiterId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant is an EEO veteran.
        /// </summary>
        [JsonProperty("eeoc_veteran")]
        public string? EeocVeteran { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the applicant has an EEO disability.
        /// </summary>
        [JsonProperty("eeoc_disability")]
        public string? EeocDisability { get; set; }

        /// <summary>
        /// Gets or sets the signature of the EEO disability of the applicant.
        /// </summary>
        [JsonProperty("eeoc_disability_signature")]
        public string? EeocDisabilitySignature { get; set; }

        /// <summary>
        /// Gets or sets the date the EEO disability was recorded for the applicant.
        /// </summary>
        [JsonProperty("eeoc_disability_date")]
        public string? EeocDisabilityDate { get; set; }

        /// <summary>
        /// Gets or sets the rating for the applicant.
        /// </summary>
        [JsonProperty("rating")]
        public bool? Rating { get; set; }

        /// <summary>
        /// Gets or sets the body of the applicant's resume.
        /// </summary>
        [JsonProperty("resume_body")]
        public string? ResumeBody { get; set; }

        /// <summary>
        /// Gets or sets the link to the applicant's resume.
        /// </summary>
        [JsonProperty("resume_link")]
        public string? ResumeLink { get; set; }

#pragma warning disable CS8618 // Custom converter ensures the property is never null

        /// <summary>
        /// Gets or sets the jobs applied to by the applicant.
        /// </summary>
        [JsonProperty("jobs")]
        [JsonConverter(typeof(SingleOrArrayConverter<Job>))]
        public List<Job> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the comments associated with the applicant.
        /// </summary>
        [JsonProperty("comments")]
        [JsonConverter(typeof(SingleOrArrayConverter<Comment>))]
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the feedback associated with the applicant.
        /// </summary>
        [JsonProperty("feedback")]
        [JsonConverter(typeof(SingleOrArrayConverter<Feedback>))]
        public List<Feedback> Feedback { get; set; }

        /// <summary>
        /// Gets or sets the activities associated with the applicant.
        /// </summary>
        [JsonProperty("activities")]
        [JsonConverter(typeof(SingleOrArrayConverter<ApplicantActivity>))]
        public List<ApplicantActivity> Activities { get; set; }

        /// <summary>
        /// Gets or sets the messages associated with the applicant.
        /// </summary>
        [JsonProperty("messages")]
        [JsonConverter(typeof(SingleOrArrayConverter<Message>))]
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Gets or sets the questionnaire associated with the applicant.
        /// </summary>
        [JsonProperty("questionnaire")]
        [JsonConverter(typeof(SingleOrArrayConverter<QuestionnaireItem>))]
        public List<QuestionnaireItem> Questionnaire { get; set; }

        /// </summary>
        [JsonProperty("evaluation")]
        [JsonConverter(typeof(SingleOrArrayConverter<EvaluationItem>))]
        public List<EvaluationItem> Evaluation { get; set; }

        /// <summary>
        /// Gets or sets the categories associated with the applicant.
        /// </summary>
        [JsonProperty("categories")]
        [JsonConverter(typeof(SingleOrArrayConverter<ApplicantCategory>))]
        public List<ApplicantCategory> Categories { get; set; }

#pragma warning restore CS8618
    }
}
