using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Exceptions;

/// <summary>
/// Exception thrown when a required JSON token was not found.
/// </summary>
public class JsonTokenNotFoundException : JsonException {

    /// <summary>
    /// Gets a reference to the JSON object.
    /// </summary>
    public new JObject Source { get; }

    /// <summary>
    /// Gets the path of the JSON token.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="source"/> and <paramref name="path"/>.
    /// </summary>
    /// <param name="source">A reference to the JSON object where the token was expected.</param>
    /// <param name="path">The path to the JSON token.</param>
    public JsonTokenNotFoundException(JObject source, string path) : base($"A required token with path '{path}' could not be not found.") {
        Source = source;
        Path = path;
    }

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="source"/> and <paramref name="path"/>.
    /// </summary>
    /// <param name="source">A reference to the JSON object where the token was expected.</param>
    /// <param name="path">The path to the JSON token.</param>
    /// <param name="message">The exception message.</param>
    public JsonTokenNotFoundException(JObject source, string path, string message) : base(message) {
        Source = source;
        Path = path;
    }

}