using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zailous.JazzHR.Models
{
    /// <summary>
    /// Converts a JSON array to a List of type T, or a single object of type T to a List with a single item.
    /// </summary>
    /// <typeparam name="T">Type of the items in the list</typeparam>
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        /// <summary>
        /// Determines if the object type is List&lt;T&gt;
        /// </summary>
        /// <param name="objectType">The object type to check</param>
        /// <returns>True if the object type is List&lt;T&gt;, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }

        /// <summary>
        /// Reads the JSON input and converts it to a List of type T or a single object of type T in a List.
        /// </summary>
        /// <param name="reader">The reader used to read the JSON input</param>
        /// <param name="objectType">The object type to convert the JSON to</param>
        /// <param name="existingValue">The existing value of the object being read</param>
        /// <param name="serializer">The serializer being used to read the JSON input</param>
        /// <returns>A List of type T or a single object of type T in a List.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                List<T>? arrayRetval = token.ToObject<List<T>>();
                if (arrayRetval == null)
                {
                    throw new InvalidOperationException();
                }

                return arrayRetval;
            }

            T? retval = token.ToObject<T>();
            if (retval == null)
            {
                throw new InvalidOperationException();
            }

            return new List<T> { retval };
        }

        /// <summary>
        /// Writes the List of type T to JSON output. If the list contains only one item, it writes the single item to JSON output.
        /// </summary>
        /// <param name="writer">The writer used to write the JSON output</param>
        /// <param name="value">The value to write to the JSON output</param>
        /// <param name="serializer">The serializer being used to write the JSON output</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var list = (List<T>)value;

            if (list.Count == 1)
            {
                serializer.Serialize(writer, list[0]);
            }
            else
            {
                serializer.Serialize(writer, list);
            }
        }
    }

}
