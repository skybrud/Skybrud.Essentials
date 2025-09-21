using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft;

/// <summary>
/// Interface describing a class that may be parsed from an instance of <see cref="JObject"/>.
/// </summary>
/// <typeparam name="TSelf">The type of the class.</typeparam>
public interface IJsonParsable<out TSelf> {

#if NET8_0_OR_GREATER

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <typeparamref name="TSelf"/>.
    /// </summary>
    /// <param name="json">The JSON object to parse.</param>
    /// <returns>An instance of <typeparamref name="TSelf"/>.</returns>
    static abstract TSelf Parse(JObject json);

#endif

}