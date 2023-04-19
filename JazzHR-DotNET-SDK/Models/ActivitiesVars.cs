namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a collection of variables related to activities, 
    /// inheriting from the PathVars class.
    /// </summary>
    public class ActivitiesVars : PathVars
    {
        /// <summary>
        /// Gets or sets the user ID associated with an activity.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the team ID associated with an activity.
        /// </summary>
        public string? TeamId { get; set; }

        /// <summary>
        /// Gets or sets the object ID associated with an activity.
        /// </summary>
        public string? ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the category associated with an activity.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets a list of parameters related to activities.
        /// </summary>
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("user_id", UserId),
            ("team_id", TeamId),
            ("object_id", ObjectId),
            ("category", Category)
            };
    }

}
