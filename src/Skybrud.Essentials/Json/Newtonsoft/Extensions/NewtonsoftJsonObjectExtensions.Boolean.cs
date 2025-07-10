using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="bool"/>
    /// value, <see langword="false"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBoolean(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseBoolean(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="bool"/>
    /// value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBoolean(this JObject? json, string propertyName, bool fallback) {
        return JsonTokenUtils.ParseBoolean(json?[propertyName], fallback);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If
    /// a matching property can not be found or the value can not be successfully converted to a <see cref="bool"/>
    /// value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this JObject? json, string propertyName) {
        return JsonTokenUtils.ParseBooleanOrNull(json?[propertyName]);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="bool"/> value, <see langword="false"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBooleanByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseBoolean(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="bool"/> value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An instance of <see cref="bool"/>.</returns>
    public static bool GetBooleanByPath(this JObject? json, string path, bool fallback) {
        return JsonTokenUtils.ParseBoolean(json?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the token matching the specified <paramref name="path"/>.
    /// If a matching property can not be found or the value can not be successfully converted to a
    /// <see cref="bool"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="bool"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNullByPath(this JObject? json, string path) {
        return JsonTokenUtils.ParseBooleanOrNull(json?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this JObject? json, string propertyName, out bool result) {
        return JsonTokenUtils.TryParseBoolean(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this JObject? json, string propertyName, [NotNullWhen(true)] out bool? result) {
        return JsonTokenUtils.TryParseBoolean(json?[propertyName], out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanByPath(this JObject? json, string path, out bool result) {
        return JsonTokenUtils.TryParseBoolean(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Attempts to get a boolean value from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBooleanByPath(this JObject? json, string path, [NotNullWhen(true)] out bool? result) {
        return JsonTokenUtils.TryParseBoolean(json?.SelectToken(path), out result);
    }

    /// <summary>
    /// Returns the <see cref="bool"/> value of the property with the specified <paramref name="propertyName"/>. If a
    /// matching property isn't found, or the value doesn't match a valid <see cref="bool"/>, an exception is thrown
    /// instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The <see cref="bool"/> value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="bool"/>.</exception>
    public static bool GetRequiredBoolean(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseBoolean(property.Value, out bool result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid boolean value.");
        return result;
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="bool"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="bool"/>.</exception>
    public static TResult GetRequiredBoolean<TResult>(this JObject json, string propertyName, Func<bool, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (!JsonTokenUtils.TryParseBoolean(property.Value, out bool result)) throw new JsonException($"The value of the '{propertyName}' property doesn't match a valid boolean value.");
        return callback(result);
    }

}