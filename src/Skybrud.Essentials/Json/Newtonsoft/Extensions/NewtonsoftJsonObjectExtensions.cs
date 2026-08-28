using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections.Enumerables.Extensions;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="JObject"/>.
/// </summary>
public static partial class NewtonsoftJsonObjectExtensions {

    /// <summary>
    /// Returns a list of <typeparamref name="T"/> values representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>A list of <typeparamref name="T"/>.</returns>
    /// <remarks>This method will always return a list. If the property doesn't exist, or it's value can not be successfully converted, an empty array will be returned instead.</remarks>
    public static IReadOnlyList<T> GetItems<T>(this JObject? json, string propertyName, Func<JObject, T> callback) {
        return JsonTokenUtils.ConvertTokenToReadOnlyList(json?[propertyName], callback);
    }

    /// <summary>
    /// Returns a list of <typeparamref name="T"/> values representing the items of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>A list of <typeparamref name="T"/>.</returns>
    /// <remarks>This method will always return a list. If the property doesn't exist, or it's value can not be successfully converted, an empty array will be returned instead.</remarks>
    public static IReadOnlyList<T> GetItemsByPath<T>(this JObject? json, string path, Func<JObject, T> callback) {
        return JsonTokenUtils.ConvertTokenToReadOnlyList(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Returns an instance of <see cref="JObject"/> representing the value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property</param>
    /// <returns>An instance of <see cref="JObject"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static JObject? GetObject(this JObject? json, string propertyName) {
        return json?[propertyName] as JObject;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T? GetObject<T>(this JObject? json, string propertyName) {
        JToken? token = json?[propertyName];
        return token is JObject obj ? obj.ToObject<T>() : default;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T? GetObject<T>(this JObject? json, string propertyName, Func<JObject, T> callback) {
        JToken? token = json?[propertyName];
        return token is JObject obj ? callback(obj) : default;
    }

    /// <summary>
    /// Returns an instance of <see cref="JObject"/> representing the value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="JObject"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static JObject? GetObjectByPath(this JObject? json, string path) {
        return json?.SelectToken(path) as JObject;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T? GetObjectByPath<T>(this JObject? json, string path) {
        JToken? token = json?.SelectToken(path) as JObject;
        return token is JObject obj ? obj.ToObject<T>() : default;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="T"/> representing the value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T? GetObjectByPath<T>(this JObject? json, string path, Func<JObject, T> callback) {
        JToken? token = json?.SelectToken(path) as JObject;
        return token is JObject obj ? callback(obj) : default;
    }

    /// <summary>
    /// Returns the <see cref="JArray"/> value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property</param>
    /// <returns>An instance of <see cref="JArray"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static JArray? GetArray(this JObject? json, string propertyName) {
        return json?[propertyName] as JArray;
    }

    /// <summary>
    /// Returns an array of <typeparamref name="T"/> representing the value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An array of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T[]? GetArray<T>(this JObject? json, string propertyName, Func<JObject, T> callback) {
        return JsonTokenUtils.ConvertTokenToArray(json?[propertyName], callback);
    }

    /// <summary>
    /// Returns the <see cref="JArray"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="JArray"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static JArray? GetArrayByPath(this JObject? json, string path) {
        return json?.SelectToken(path) as JArray;
    }

    /// <summary>
    /// Returns an array of <typeparamref name="T"/> representing the value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An array of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T[]? GetArrayByPath<T>(this JObject? json, string path, Func<JObject, T> callback) {
        return JsonTokenUtils.ConvertTokenToArray(json?.SelectToken(path), callback);
    }

    /// <summary>
    /// Returns an array of <see cref="JObject"/> representing the value of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An array of <see cref="JObject"/>.</returns>
    public static JObject[] GetObjectArray(this JObject? json, string propertyName) {
        return (json?[propertyName] as JArray)?.OfType<JObject>().ToArray() ?? [];
    }

    /// <summary>
    /// Returns an array of <see cref="JObject"/> representing the value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An array of <see cref="JObject"/>.</returns>
    public static JObject[] GetObjectArrayByPath(this JObject? json, string path) {
        return (json?.SelectToken(path) as JArray)?.OfType<JObject>().ToArray() ?? [];
    }

    /// <summary>
    /// Returns an array of <see cref="JToken"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An array of <see cref="JToken"/>.</returns>
    public static JToken[] GetArrayItems(this JObject? json, string propertyName) {
        if (json?[propertyName] is not JArray array || array.Count == 0) return [];
        return [.. array];
    }

    /// <summary>
    /// Returns an array of <typeparamref name="T"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    public static T[] GetArrayItems<T>(this JObject? json, string propertyName, Func<JObject, T?> callback) {

        if (json?[propertyName] is not JArray array || array.Count == 0) return [];

        List<T> temp = [];

        foreach (JToken item in array) {
            if (item is JObject obj && callback(obj) is { } value) temp.Add(value);
        }

        return [.. temp];

    }

    /// <summary>
    /// Returns an array of <typeparamref name="TValue"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the token.</typeparam>
    /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="TValue"/> value.</param>
    /// <returns>An array of <typeparamref name="TValue"/>.</returns>
    public static TValue[] GetArrayItems<TKey, TValue>(this JObject? json, string propertyName, Func<TKey, TValue?> callback) where TKey : JToken {

        if (json?[propertyName] is not JArray array || array.Count == 0) return [];

        List<TValue> temp = [];

        foreach (JToken child in array) {
            if (child is TKey key && callback(key) is { } value) temp.Add(value);
        }

        return [.. temp];

    }

    /// <summary>
    /// Returns an array of <typeparamref name="TValue"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An array of <typeparamref name="TValue"/>.</returns>
    public static TValue[] GetArrayItems<TValue>(this JObject? json, string propertyName) where TValue : struct {
        if (json?[propertyName] is not JArray array || array.Count == 0) return [];
        return [.. array.Values<TValue>()];
    }

    /// <summary>
    /// Returns an array of <see cref="JToken"/> representing the items of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An array of <see cref="JToken"/>.</returns>
    public static JToken[] GetArrayItemsByPath(this JObject? json, string path) {
        if (json?.SelectToken(path) is not JArray array || array.Count == 0) return [];
        return [.. array];
    }

    /// <summary>
    /// Returns an array of <typeparamref name="T"/> representing the items of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="T"/> value.</param>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    public static T[] GetArrayItemsByPath<T>(this JObject? json, string path, Func<JObject, T?> callback) {

        if (json?.SelectToken(path) is not JArray array || array.Count == 0) return [];

        List<T> temp = [];

        foreach (JToken item in array) {
            if (item is JObject obj && callback(obj) is { } value) temp.Add(value);
        }

        return [.. temp];

    }

    /// <summary>
    /// Returns an array of <typeparamref name="TValue"/> representing the items of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the token.</typeparam>
    /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The callback used for converting each item to a corresponding <typeparamref name="TValue"/> value.</param>
    /// <returns>An array of <typeparamref name="TValue"/>.</returns>
    public static TValue[] GetArrayItemsByPath<TKey, TValue>(this JObject? json, string path, Func<TKey, TValue?> callback) where TKey : JToken {

        if (json?.SelectToken(path) is not JArray array || array.Count == 0) return [];

        List<TValue> temp = [];

        foreach (JToken child in array) {
            if (child is TKey key && callback(key) is { } value) temp.Add(value);
        }

        return [.. temp];

    }

    /// <summary>
    /// Returns an array of <typeparamref name="TValue"/> representing the items of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An array of <typeparamref name="TValue"/>.</returns>
    public static TValue[] GetArrayItemsByPath<TValue>(this JObject? json, string path) where TValue : struct {
        if (json?.SelectToken(path) is not JArray array || array.Count == 0) return [];
        return [.. array.Values<TValue>()];
    }

    /// <summary>
    /// Returns an instance of <see cref="JArray"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property isn't found or the property value isn't a
    /// <see cref="JArray"/>, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="JArray"/> representing the property value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JArray"/>.</exception>
    public static JArray GetRequiredArray(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JArray array) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON array.");
        return array;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found or the property value isn't a
    /// <see cref="JArray"/>, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="JArray"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JArray"/>.</exception>
    public static TResult GetRequiredArray<TResult>(this JObject json, string propertyName, Func<JArray, TResult> callback) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JArray array) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON array.");
        return callback(array);
    }

    #region GetRequiredArray(...)

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found or the property value isn't a
    /// <see cref="JArray"/>, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="JArray"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JArray"/>.</exception>
    public static TResult[] GetRequiredArray<TResult>(this JObject json, string propertyName, Func<JToken, TResult> callback) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JArray array) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON array.");
        return array.SelectArray(callback);
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found or the property value isn't a
    /// <see cref="JArray"/>, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="JArray"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JArray"/>.</exception>
    public static TResult[] GetRequiredArray<TResult>(this JObject json, string propertyName, Func<JObject, TResult> callback) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JArray array) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON array.");
        return array.OfType<JObject>().SelectArray(callback);
    }

    #endregion

    #region GetRequiredObject(...)

    /// <summary>
    /// Returns an instance of <see cref="JObject"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property isn't found or the property value isn't a
    /// <see cref="JObject"/>, an exception will be thrown instead.
    /// </summary>
    /// <param name="json">The parent JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>An instance of <see cref="JObject"/> representing the property value.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JObject"/>.</exception>
    public static JObject GetRequiredObject(this JObject json, string propertyName) {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JObject obj) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON object.");
        return obj;
    }

    /// <summary>
    /// Returns an instance of <typeparamref name="TResult"/> representing the value of the property with the specified
    /// <paramref name="propertyName"/>. If a matching property is
    /// found, the value is converted using <paramref name="callback"/>. If not found or the property value isn't a
    /// <see cref="JObject"/>, an exception will be thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="json">The JSON object.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="callback">A callback function used for converting the <see cref="JObject"/> value to <typeparamref name="TResult"/>.</param>
    /// <returns>The property value as an instance of <typeparamref name="TResult"/>.</returns>
    /// <exception cref="JsonPropertyNotFoundException">If a property matching <paramref name="propertyName"/> isn't found.</exception>
    /// <exception cref="JsonException">If the property is found, but the value doesn't match a <see cref="JObject"/>.</exception>
    public static TResult GetRequiredObject<TResult>(this JObject json, string propertyName, Func<JObject, TResult> callback) where TResult : notnull {
        JProperty property = json.Property(propertyName) ?? throw new JsonPropertyNotFoundException(json, propertyName);
        if (property.Value is not JObject obj) throw new JsonException($"The value of the '{propertyName}' property is not a valid JSON object.");
        return callback(obj);
    }

    #endregion

    #region GetList(...)

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static List<TResult>? GetList<TResult>(this JObject? source, string propertyName) {
        JToken? token = source?.GetValue(propertyName);
        if (token is null || token.Type is JTokenType.Null) return null;
        return token.ToObject<List<TResult>>();
    }

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <param name="callback">A callback method for converting each <see cref="JToken"/> item into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static List<TResult>? GetList<TResult>(this JObject? source, string propertyName, Func<JToken, TResult> callback) {
        if (source?.GetValue(propertyName) is not JArray array) return null;
        return [.. array.Select(callback)];
    }

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <param name="callback">A callback method for converting each <see cref="JObject"/> item into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static List<TResult>? GetList<TResult>(this JObject? source, string propertyName, Func<JObject, TResult> callback) {
        if (source?.GetValue(propertyName) is not JArray array) return null;
        return [.. array.OfType<JObject>().Select(callback)];
    }

    #endregion

    #region GetListItems(...)

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful.</returns>
    public static List<TResult> GetListItems<TResult>(this JObject? source, string propertyName) {
        JToken? token = source?.GetValue(propertyName);
        if (token is null || token.Type is JTokenType.Null) return [];
        return token.ToObject<List<TResult>>() ?? [];
    }

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <param name="callback">A callback method for converting each <see cref="JToken"/> item into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful.</returns>
    public static List<TResult> GetListItems<TResult>(this JObject? source, string propertyName, Func<JToken, TResult> callback) {
        if (source?.GetValue(propertyName) is not JArray array) return [];
        return [.. array.Select(callback)];
    }

    /// <summary>
    /// Returns a list of <typeparamref name="TResult"/> representing the items of the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the items.</typeparam>
    /// <param name="source">The parent <see cref="JObject"/> holding the property.</param>
    /// <param name="propertyName">The name of the object.</param>
    /// <param name="callback">A callback method for converting each <see cref="JObject"/> item into an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>A list of <typeparamref name="TResult"/> if successful.</returns>
    public static List<TResult> GetListItems<TResult>(this JObject? source, string propertyName, Func<JObject, TResult> callback) {
        if (source?.GetValue(propertyName) is not JArray array) return [];
        return [.. array.OfType<JObject>().Select(callback)];
    }

    #endregion
}