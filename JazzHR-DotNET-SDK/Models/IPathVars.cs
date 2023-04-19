namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Interface for classes that represent variables in a URL path.
    /// </summary>
    public interface IPathVars
    {
        /// <summary>
        /// Converts the variables to a subpath to be appended to a base URL.
        /// </summary>
        /// <returns>A subpath to be appended to a base URL.</returns>
        string ToSubpath();
    }

}
