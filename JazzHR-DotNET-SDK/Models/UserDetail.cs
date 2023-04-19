using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a detailed user object that extends the <see cref="User"/> class.
    /// </summary>
    [JsonObject]
    public class UserDetail : User
    {
        /// <summary>
        /// The list of user activities.
        /// </summary>
#pragma warning disable CS8618 // Custom converter ensures the property is never null
        [JsonProperty("user_activity")]
        [JsonConverter(typeof(SingleOrArrayConverter<UserActivity>))]
        public List<UserActivity> UserActivity { get; set; }
#pragma warning restore CS8618
    }

}
