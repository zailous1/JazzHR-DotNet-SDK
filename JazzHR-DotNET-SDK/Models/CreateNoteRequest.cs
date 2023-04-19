using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Request object for creating a note for an applicant.
    /// </summary>
    [JsonObject]
    public class CreateNoteRequest : CreateRequest
    {
        /// <summary>
        /// The ID of the applicant the note is associated with.
        /// </summary>
        [JsonProperty("applicant_id")]
        public string ApplicantId { get; private set; }

        /// <summary>
        /// The ID of the user who created the note.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; private set; }

        /// <summary>
        /// The contents of the note.
        /// </summary>
        [JsonProperty("contents")]
        public string Contents { get; private set; }

        /// <summary>
        /// The security level of the note. Currently set to "1" for everyone (admins and users).
        /// </summary>
        [JsonProperty("security")]
        public string Security => "1"; //Everyone (Admins and Users)

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNoteRequest"/> class.
        /// </summary>
        /// <param name="applicantId">The ID of the applicant the note is associated with.</param>
        /// <param name="userId">The ID of the user who created the note.</param>
        /// <param name="contents">The contents of the note.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="applicantId"/> or <paramref name="userId"/> is null.</exception>
        public CreateNoteRequest(string applicantId, string userId, string contents)
        {
            _ = applicantId ?? throw new ArgumentNullException(nameof(applicantId));
            _ = userId ?? throw new ArgumentNullException(nameof(UserId));

            ApplicantId = applicantId;
            UserId = userId;
            Contents = contents;
        }
    }

}
