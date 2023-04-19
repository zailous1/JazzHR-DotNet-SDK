namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents the path variables for a Categories endpoint.
    /// </summary>
    public class CategoriesVars : PathVars
    {
        /// <summary>
        /// Gets or sets the ID of the user associated with the category.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the category.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the starting creation date of the categories to be retrieved.
        /// </summary>
        public string? FromCreationDate { get; set; }

        /// <summary>
        /// Gets or sets the ending creation date of the categories to be retrieved.
        /// </summary>
        public string? ToCreationDate { get; set; }

        /// <summary>
        /// Gets the list of parameter names and values for the variables.
        /// </summary>
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("user_id", UserId),
            ("name", Name),
            ("status", Status),
            ("from_creation_date", FromCreationDate),
            ("to_creation_date", ToCreationDate)
            };
    }

}
