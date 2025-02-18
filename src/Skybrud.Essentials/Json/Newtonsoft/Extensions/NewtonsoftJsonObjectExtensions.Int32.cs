using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the <see cref="int"/> value of the property with the specified <paramref name="propertyName"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="int"/> value, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt32(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to an <see cref="int"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32(this JObject? json, string propertyName, int fallback) {
        return JsonTokenUtils.ParseInt32(json?[propertyName], fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
    /// successfully converted to an <see cref="int"/> value, the default value of <typeparamref name="T"/> is
    /// returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting the <see cref="int"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetInt32<T>(this JObject? json, string propertyName, Func<int, T> callback) {
        return JsonTokenUtils.ParseInt32(json?[propertyName], callback);
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the property with the specified <paramref name="propertyName"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="int"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt32OrNull(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching token can not be found or the value can not be successfully converted to a
    /// <see cref="int"/> value, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32ByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt32(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token can not be found or the value can not be successfully converted to an <see cref="int"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="int"/>.</returns>
    public static int GetInt32ByPath(this JObject? json, string path, int fallback) {
        return JsonTokenUtils.ParseInt32(json?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
    /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
    /// to an <see cref="int"/> value, the default value of <typeparamref name="T"/> is returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting the <see cref="int"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetInt32ByPath<T>(this JObject? json, string path, Func<int, T> callback) {
        return JsonTokenUtils.ParseInt32(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Returns the <see cref="int"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching token can not be found or the value can not be successfully converted to a
    /// <see cref="int"/> value,<see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="int"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNullByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt32OrNull(json?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get an <see cref="int"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this JObject? json, string propertyName, out int result) {
        return JsonTokenUtils.TryParseInt32(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get an <see cref="int"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this JObject? json, string propertyName, [NotNullWhen(true)] out int? result) {
        return JsonTokenUtils.TryParseInt32(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get an <see cref="int"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32ByPath(this JObject? json, string path, out int result) {
        return JsonTokenUtils.TryParseInt32(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get an <see cref="int"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32ByPath(this JObject? json, string path, [NotNullWhen(true)] out int? result) {
        return JsonTokenUtils.TryParseInt32(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
    /// <see cref="int"/>. If a matching property is not found, the value is not an array or the value can not be
    /// successfully converted, an empty array of <see cref="int"/> is returned instead.
    /// </summary>
    /// <returns>An array of <see cref="int"/>.</returns>
    public static int[] GetInt32Array(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt32Array(json?[propertyName]);
    }

    /// <summary>
    /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
    /// found, the value is not an array or the value can not be successfully converted, an empty array of
    /// <see cref="int"/> is returned instead.
    /// </summary>
    /// <returns>An array of <see cref="int"/>.</returns>
    public static int[] GetInt32ArrayByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt32Array(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the signed 32-bit integer value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property isn't found, or the value doesn't match a valid signed 32-bit integer, an exception is
    /// thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The signed 32-bit integer value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a signed 32-bit integer.</exception>
    public static int GetRequiredInt32(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseInt32(property.Value, out int result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid 32-bit integer value.");
        return result;
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the signed 32-bit integer value to <typeparamref name="TResult"/>.</param>
    /// <returns>The signed 32-bit integer value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a signed 32-bit integer.</exception>
    public static TResult GetRequiredInt32<TResult>(this JObject json, string propertyName, Func<int, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseInt32(property.Value, out int result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid 32-bit integer value.");
        return callback(result);
    }

}