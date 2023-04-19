namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents path variables for retrieving user information.
    /// </summary>
    public class UsersVars : PathVars
    {
        /// <summary>
        /// Gets or sets the name of the user to search for.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user to search for.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the type of the user to search for.
        /// </summary>
        public string? Type { get; set; }

        /// <inheritdoc />
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
            ("name", Name),
            ("email", Email),
            ("type", Type)
            };
    }

}
