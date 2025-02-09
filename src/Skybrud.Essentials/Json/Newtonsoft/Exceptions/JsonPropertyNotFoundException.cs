using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Exceptions;

/// <summary>
/// Exception thrown when a required JSON property was not found.
/// </summary>
public class JsonPropertyNotFoundException : JsonException {

    /// <summary>
    /// Gets a reference to the JSON object.
    /// </summary>
    public new JObject Source { get; }

    /// <summary>
    /// Gets the name of the property.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="source"/> and <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="source">A reference to the JSON object where the property was expected.</param>
    /// <param name="propertyName">The name of the property.</param>
    public JsonPropertyNotFoundException(JObject source, string propertyName) : base($"JSON property with name '{propertyName}' not found.") {
        Source = source;
        PropertyName = propertyName;
    }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="source"/> and <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="source">A reference to the JSON object where the property was expected.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="message">The exception message.</param>
    public JsonPropertyNotFoundException(JObject source, string propertyName, string message) : base(message) {
        Source = source;
        PropertyName = propertyName;
    }

}