using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a message.
    /// </summary>
    [JsonObject]
    public class Message
    {
        /// <summary>
        /// Gets or sets the communication ID.
        /// </summary>
        [JsonProperty("comm_id")]
        public string? CommId { get; set; }

        /// <summary>
        /// Gets or sets the communication subject.
        /// </summary>
        [JsonProperty("comm_subject")]
        public string? CommSubject { get; set; }

        /// <summary>
        /// Gets or sets the communication text.
        /// </summary>
        [JsonProperty("comm_text")]
        public string? CommText { get; set; }

        /// <summary>
        /// Gets or sets the email address of the communication author.
        /// </summary>
        [JsonProperty("comm_author_email")]
        public string? CommAuthorEmail { get; set; }

        /// <summary>
        /// Gets or sets the communication recipients.
        /// </summary>
        [JsonProperty("comm_to")]
        public string? CommTo { get; set; }

        /// <summary>
        /// Gets or sets the communication carbon copy recipients.
        /// </summary>
        [JsonProperty("comm_cc")]
        public string? CommCc { get; set; }

        /// <summary>
        /// Gets or sets the communication blind carbon copy recipients.
        /// </summary>
        [JsonProperty("comm_bcc")]
        public string? CommBcc { get; set; }

        /// <summary>
        /// Gets or sets the date and time the communication was sent.
        /// </summary>
        [JsonProperty("comm_datetime_sent")]
        public DateTime? CommDatetimeSent { get; set; }
    }

}
