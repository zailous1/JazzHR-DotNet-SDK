using Newtonsoft.Json;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Represents a request to create a new category.
    /// </summary>
    [JsonObject]
    public class CreateCategoryRequest : CreateRequest
    {
        /// <summary>
        /// Gets or sets the name of the category to be created.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets whether the category is enabled or not.
        /// </summary>
        [JsonProperty("status")]
        public string Enabled { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryRequest"/> class with the given name and active status.
        /// </summary>
        /// <param name="name">The name of the category to be created.</param>
        /// <param name="active">A value indicating whether the category should be enabled or not.</param>
        public CreateCategoryRequest(string name, bool active)
        {
            _ = name ?? throw new ArgumentNullException(nameof(name));

            Name = name;
            Enabled = active ? "1" : "0";
        }
    }

}
