using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a questionnaire item.
    /// </summary>
    [JsonObject]
    public class QuestionnaireItem
    {
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        [JsonProperty("question")]
        public string? Question { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        [JsonProperty("answer")]
        public string? Answer { get; set; }
    }

}
