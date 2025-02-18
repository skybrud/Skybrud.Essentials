using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the <see cref="short"/> value of the property with the specified <paramref name="propertyName"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="short"/> value, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="short"/>.</returns>
    public static short GetInt16(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt16(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="short"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="short"/>.</returns>
    public static short GetInt16(this JObject? json, string propertyName, short fallback) {
        return JsonTokenUtils.ParseInt16(json?[propertyName], fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
    /// successfully converted to a <see cref="short"/> value, the default value of <typeparamref name="T"/> is
    /// returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting the <see cref="short"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetInt16<T>(this JObject? json, string propertyName, Func<short, T> callback) {
        return JsonTokenUtils.ParseInt16(json?[propertyName], callback);
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the property with the specified <paramref name="propertyName"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="short"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static short? GetInt16OrNull(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt16OrNull(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching token can not be found or the value can not be successfully converted to a
    /// <see cref="short"/> value, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="short"/>.</returns>
    public static short GetInt16ByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt16(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>. If a
    /// matching token can not be found or the value can not be successfully converted to a <see cref="short"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="short"/>.</returns>
    public static short GetInt16ByPath(this JObject? json, string path, short fallback) {
        return JsonTokenUtils.ParseInt16(json?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
    /// <paramref name="path"/>. If a matching token can not be found or the value can not be successfully converted
    /// to a <see cref="short"/> value, the default value of <typeparamref name="T"/> is returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting the <see cref="short"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetInt16ByPath<T>(this JObject? json, string path, Func<short, T> callback) {
        return JsonTokenUtils.ParseInt16(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Returns the <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching token can not be found or the value can not be successfully converted to a
    /// <see cref="short"/> value,<see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="short"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static short? GetInt16OrNullByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt16OrNull(json?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get a <see cref="short"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt16(this JObject? json, string propertyName, out short result) {
        return JsonTokenUtils.TryParseInt16(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="short"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="int"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt16(this JObject? json, string propertyName, [NotNullWhen(true)] out short? result) {
        return JsonTokenUtils.TryParseInt16(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt16ByPath(this JObject? json, string path, out short result) {
        return JsonTokenUtils.TryParseInt16(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="short"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="short"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt16ByPath(this JObject? json, string path, [NotNullWhen(true)] out short? result) {
        return JsonTokenUtils.TryParseInt16(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
    /// <see cref="short"/>. If a matching property is not found, the value is not an array or the value can not be
    /// successfully converted, an empty array of <see cref="short"/> is returned instead.
    /// </summary>
    /// <returns>An array of <see cref="short"/>.</returns>
    public static short[] GetInt16Array(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseInt16Array(json?[propertyName]);
    }

    /// <summary>
    /// Returns the value of the token matching the specified <paramref name="path"/>. If a matching token is not
    /// found, the value is not an array or the value can not be successfully converted, an empty array of
    /// <see cref="short"/> is returned instead.
    /// </summary>
    /// <returns>An array of <see cref="short"/>.</returns>
    public static short[] GetInt16ArrayByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseInt16Array(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the signed 16-bit integer value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property isn't found, or the value doesn't match a valid signed 16-bit integer, an exception is
    /// thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The signed 16-bit integer value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a signed 16-bit integer.</exception>
    public static int GetRequiredInt16(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseInt16(property.Value, out short result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid 16-bit integer value.");
        return result;
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the signed 16-bit integer value to <typeparamref name="TResult"/>.</param>
    /// <returns>The signed 16-bit integer value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a signed 16-bit integer.</exception>
    public static TResult GetRequiredInt16<TResult>(this JObject json, string propertyName, Func<int, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseInt16(property.Value, out short result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid 16-bit integer value.");
        return callback(result);
    }

}