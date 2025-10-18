using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="Guid"/>
    /// value, <see langword="false"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuid(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseGuid(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="Guid"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuid(this JObject? json, string propertyName, Guid fallback) {
        return JsonTokenUtils.ParseGuid(json?[propertyName], fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property can not be found or the value can not be
    /// successfully converted to a <see cref="Guid"/> value, the default value of <typeparamref name="T"/> is
    /// returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting the <see cref="Guid"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetGuid<T>(this JObject? json, string propertyName, Func<Guid, T> callback) {
        return JsonTokenUtils.ParseGuid(json?[propertyName], callback);
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the property with the specified <paramref name="propertyName"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="Guid"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseGuidOrNull(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If
    /// a matching token can not be found or the value can not be successfully converted to a <see cref="Guid"/>
    /// value, <see langword="false"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuidByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseGuid(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>. If
    /// a matching token can not be found or the value can not be successfully converted to a <see cref="Guid"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="Guid"/>.</returns>
    public static Guid GetGuidByPath(this JObject? json, string path, Guid fallback) {
        return JsonTokenUtils.ParseGuid(json?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified
    /// <paramref name="path"/>. If a matching token can not be found or the value can not be
    /// successfully converted to a <see cref="Guid"/> value, the default value of <typeparamref name="T"/> is
    /// returned instead.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned.</typeparam>
    /// <param name="json"></param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting the <see cref="Guid"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetGuidByPath<T>(this JObject? json, string path, Func<Guid, T> callback) {
        return JsonTokenUtils.ParseGuid(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Returns the <see cref="Guid"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching token can not be found or the value can not be successfully converted to a
    /// <see cref="Guid"/> value,<see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNullByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseGuidOrNull(json?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get a <see cref="Guid"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this JObject? json, string propertyName, out Guid result) {
        return JsonTokenUtils.TryParseGuid(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="Guid"/> value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this JObject? json, string propertyName, [NotNullWhen(true)] out Guid? result) {
        return JsonTokenUtils.TryParseGuid(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="Guid"/> value from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <c>0</c>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidByPath(this JObject? json, string path, out Guid result) {
        return JsonTokenUtils.TryParseGuid(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get a <see cref="Guid"/> value from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed <see cref="Guid"/> value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidByPath(this JObject? json, string path, [NotNullWhen(true)] out Guid? result) {
        return JsonTokenUtils.TryParseGuid(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/> as an array of
    /// <see cref="Guid"/>. If a matching property is not found, the value is not an array or the value can not be
    /// successfully converted, an empty array of <see cref="Guid"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An array of <see cref="Guid"/>.</returns>
    public static Guid[] GetGuidArray(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseGuidArray(json?[propertyName]);
    }

    /// <summary>
    /// Returns the value of the token matching the specified <paramref name="path"/> as an array of
    /// <see cref="Guid"/>. If a matching token is not found, the value is not an array or the value can not be
    /// successfully converted, an empty array of <see cref="Guid"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An array of <see cref="Guid"/>.</returns>
    public static Guid[] GetGuidArrayByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseGuidArray(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/> as a list of
    /// <see cref="Guid"/>. If a matching property is not found, the value is not an array or the value can not be
    /// successfully converted, an empty list of <see cref="Guid"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>A list of <see cref="Guid"/>.</returns>
    public static List<Guid> GetGuidList(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseGuidList(json?[propertyName]);
    }

    /// <summary>
    /// Returns the value of the token matching the specified <paramref name="path"/> as a list of
    /// <see cref="Guid"/>. If a matching token is not found, the value is not an array or the value can not be
    /// successfully converted, an empty list of <see cref="Guid"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>A list of <see cref="Guid"/>.</returns>
    public static List<Guid> GetGuidListByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseGuidList(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the GUID value of the property with the specified <paramref name="propertyName"/>. If a matching
    /// property isn't found, or the value isn't a valid GUID, an exception is thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The <see cref="Guid"/>> value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="Guid"/>.</exception>
    public static Guid GetRequiredGuid(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseGuid(property.Value, out Guid result)) throw new JsonException($"The value of the '{propertyName}' property is not a valid GUID.");
        return result;
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, and the value matches a GUID, the GUID value is converted using the specified
    /// <paramref name="callback"/> function. If a matching property isn't found, or the value doesn't match a GUID
    /// value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the GUID value will be converted.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback function used for converting the GUID value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted GUID value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="Guid"/>.</exception>
    public static TResult GetRequiredGuid<TResult>(this JObject json, string propertyName, Func<Guid, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseGuid(property.Value, out Guid result)) throw new JsonException($"The value of the '{propertyName}' property is not a valid GUID.");
        return callback(result);
    }

    /// <summary>
    /// Returns a GUID array from value the property with the specified <paramref name="propertyName"/>. If a matching property isn't found, or at least one of the values doesn't match a GUID, an exception is thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An array of <see cref="Guid"/></returns>.
    public static Guid[] GetRequiredGuidArray(this JObject json, string propertyName) {
        return [..GetRequiredGuidList(json, propertyName)];
    }

    /// <summary>
    /// Returns a GUID list from value the property with the specified <paramref name="propertyName"/>. If a matching property isn't found, or at least one of the values doesn't match a GUID, an exception is thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>A list of <see cref="Guid"/></returns>.
    public static List<Guid> GetRequiredGuidList(this JObject json, string propertyName) {

        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);

        switch (property.Value.Type) {

            case JTokenType.String:

                List<Guid> temp = [];

                foreach (string piece in StringUtils.ParseStringArray(property.Value.ToString())) {

                    if (!StringUtils.TryParseGuid(piece, out Guid guid)) {
                        throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid GUID array.");
                    }

                    temp.Add(guid);

                }

                return temp;

            case JTokenType.Array:

                List<Guid> temp2 = [];

                foreach (JToken item in (JArray) property.Value) {

                    if (item.Type is not JTokenType.String || !StringUtils.TryParseGuid(item.ToString(), out Guid guid)) {
                        throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid GUID array.");
                    }

                    temp2.Add(guid);

                }

                return temp2;

            default:

                throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid GUID array.");

        }

    }

}