using System.Text;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a base class for defining path variables for API endpoints.
    /// </summary>
    public abstract class PathVars : IPathVars
    {
        /// <summary>
        /// Gets the list of parameter name and value pairs that should be included in the endpoint URL.
        /// </summary>
        protected abstract List<(string paramName, string? paramValue)> Parameters { get; }

        /// <summary>
        /// Returns a string that represents the endpoint URL with the path variables defined by this object.
        /// </summary>
        /// <returns>The endpoint URL with the path variables defined by this object.</returns>
        public virtual string ToSubpath()
        {
            var sb = new StringBuilder();
            foreach (var (paramName, paramValue) in Parameters)
            {
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    sb.Append($"/{paramName}/{paramValue}");
                }
            }

            return sb.ToString();
        }
    }

}
