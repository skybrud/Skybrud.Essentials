using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns the enum of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T GetEnum<T>(this JObject? json, string propertyName) where T : Enum {
        return JsonTokenUtils.GetEnum<T>(json?[propertyName]);
    }

    /// <summary>
    /// Returns the enum of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T GetEnum<T>(this JObject? json, string propertyName, T fallback) where T : Enum {
        return JsonTokenUtils.GetEnum(json?[propertyName], fallback);
    }

    /// <summary>
    /// Returns the enum of type <typeparamref name="TEnum"/> from the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <typeparamref name="TEnum"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static TEnum? GetEnumOrNull<TEnum>(this JObject? json, string propertyName) where TEnum : struct, Enum {
        return JsonTokenUtils.GetEnumOrNull<TEnum>(json?[propertyName]);
    }

    /// <summary>
    /// Returns the enum of type <typeparamref name="T"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T GetEnumByPath<T>(this JObject? json, string path) where T : Enum {
        return JsonTokenUtils.GetEnum<T>(json?.SelectToken(path));
    }

    /// <summary>
    /// Returns the enum of type <typeparamref name="T"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T GetEnumByPath<T>(this JObject? json, string path, T fallback) where T : Enum {
        return JsonTokenUtils.GetEnum(json?.SelectToken(path), fallback);
    }

    /// <summary>
    /// Returns the enum value of the property with the specified <paramref name="propertyName"/>. If a matching
    /// property isn't found, or the value doesn't match a valid <typeparamref name="TEnum"/>, an exception is thrown
    /// instead.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>The enum value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="double"/>.</exception>
    public static TEnum GetRequiredEnum<TEnum>(this JObject json, string propertyName) where TEnum : struct, Enum {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        return JsonTokenUtils.GetEnumOrNull<TEnum>(property.Value) ?? throw new JsonException($"The value of the '{propertyName}' property doesn't match a value of enum '{typeof(Enum)}'.");
    }

    /// <summary>
    /// Returns the value of the property with the specified <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found, or the value doesn't match a
    /// valid <typeparamref name="TEnum"/>, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="double"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="double"/>.</exception>
    public static TResult GetRequiredEnum<TEnum, TResult>(this JObject json, string propertyName, Func<TEnum, TResult> callback) where TEnum : struct, Enum where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (JsonTokenUtils.GetEnumOrNull<TEnum>(property.Value) is not {} value) throw new JsonException($"The value of the '{propertyName}' property doesn't match a value of enum '{typeof(Enum)}'.");
        return callback(value);
    }

}