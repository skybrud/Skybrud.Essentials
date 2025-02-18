using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetString(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseString(json?[propertyName]);
    }

    /// <summary>
    /// Returns the string value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting the <see cref="string"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetString<T>(this JObject? json, string propertyName, Func<string, T> callback) {
        return JsonTokenUtils.ParseString(json?[propertyName], callback);

    }

    /// <summary>
    /// Returns the string value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="string"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetStringByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseString(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the string value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting the <see cref="string"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetStringByPath<T>(this JObject? json, string path, Func<string, T> callback) {
        return JsonTokenUtils.ParseString(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Attempts to get the <see cref="string"/> value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the <see cref="string"/> value. If the property could not be found or the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the property is found, and it's value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetString(this JObject? json, string propertyName, [NotNullWhen(true)] out string? result) {
        return JsonTokenUtils.TryParseString(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="string"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the <see cref="string"/> value. If the property could not be found or the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the property is found, and it's value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetStringByPath(this JObject? json, string path, [NotNullWhen(true)] out string? result) {
        return JsonTokenUtils.TryParseString(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching token
    /// is not found, or the value can not be successfully converted to a <see cref="string"/> array, an empty
    /// array is returned instead.
    /// </summary>
    /// <returns>An array of <see cref="string"/>.</returns>
    public static string[] GetStringArray(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseStringArray(json?[propertyName]);
    }

    /// <summary>
    /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
    /// found, or the value can not be successfully converted to a <see cref="string"/> array, an empty array is
    /// returned instead.
    /// </summary>
    /// <returns>An array of <see cref="string"/>.</returns>
    public static string[] GetStringArrayByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseStringArray(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is not found, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The string value </returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    public static string GetRequiredString(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseString(property.Value, out string? result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid string value.");
        return result;
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the string value to <typeparamref name="TResult"/>.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    public static TResult GetRequiredString<TResult>(this JObject json, string propertyName, Func<string, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseString(property.Value, out string? result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid string value.");
        return callback(result);
    }

}