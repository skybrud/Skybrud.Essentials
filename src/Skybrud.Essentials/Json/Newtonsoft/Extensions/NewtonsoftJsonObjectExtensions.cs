using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

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
        /// <remarks>This method will always return a list. If the property doesn't exist or it's value can not be successfully converted, an empty array will be returned instead.</remarks>
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
        /// <remarks>This method will always return a list. If the property doesn't exist or it's value can not be successfully converted, an empty array will be returned instead.</remarks>
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
            return (json?[propertyName] as JArray)?.OfType<JObject>().ToArray() ?? ArrayUtils.Empty<JObject>();
        }

        /// <summary>
        /// Returns an array of <see cref="JObject"/> representing the value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An array of <see cref="JObject"/>.</returns>
        public static JObject[] GetObjectArrayByPath(this JObject? json, string path) {
            return (json?.SelectToken(path) as JArray)?.OfType<JObject>().ToArray() ?? ArrayUtils.Empty<JObject>();
        }

        /// <summary>
        /// Returns an array of <see cref="JToken"/> representing the items of the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An array of <see cref="JToken"/>.</returns>
        public static JToken[] GetArrayItems(this JObject? json, string propertyName) {
            if (json?[propertyName] is not JArray array || array.Count == 0) return ArrayUtils.Empty<JToken>();
            return array.ToArray();
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

            if (json?[propertyName] is not JArray array || array.Count == 0) return ArrayUtils.Empty<T>();

            List<T> temp = new();

            foreach (JToken item in array) {
                if (item is JObject obj && callback(obj) is { } value) temp.Add(value);
            }

            return temp.ToArray();

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

            if (json?[propertyName] is not JArray array || array.Count == 0) return ArrayUtils.Empty<TValue>();

            List<TValue> temp = new();

            foreach (JToken child in array) {
                if (child is TKey key && callback(key) is { } value) temp.Add(value);
            }

            return temp.ToArray();

        }

        /// <summary>
        /// Returns an array of <typeparamref name="TValue"/> representing the items of the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An array of <typeparamref name="TValue"/>.</returns>
        public static TValue[] GetArrayItems<TValue>(this JObject? json, string propertyName) where TValue : struct {
            if (json?[propertyName] is not JArray array || array.Count == 0) return ArrayUtils.Empty<TValue>();
            return array.Values<TValue>().ToArray();
        }

        /// <summary>
        /// Returns an array of <see cref="JToken"/> representing the items of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An array of <see cref="JToken"/>.</returns>
        public static JToken[] GetArrayItemsByPath(this JObject? json, string path) {
            if (json?.SelectToken(path) is not JArray array || array.Count == 0) return ArrayUtils.Empty<JToken>();
            return array.ToArray();
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

            if (json?.SelectToken(path) is not JArray array || array.Count == 0) return ArrayUtils.Empty<T>();

            List<T> temp = new();

            foreach (JToken item in array) {
                if (item is JObject obj && callback(obj) is { } value) temp.Add(value);
            }

            return temp.ToArray();

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

            if (json?.SelectToken(path) is not JArray array || array.Count == 0) return ArrayUtils.Empty<TValue>();

            List<TValue> temp = new();

            foreach (JToken child in array) {
                if (child is TKey key && callback(key) is { } value) temp.Add(value);
            }

            return temp.ToArray();

        }

        /// <summary>
        /// Returns an array of <typeparamref name="TValue"/> representing the items of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the items to be returned.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An array of <typeparamref name="TValue"/>.</returns>
        public static TValue[] GetArrayItemsByPath<TValue>(this JObject? json, string path) where TValue : struct {
            if (json?.SelectToken(path) is not JArray array || array.Count == 0) return ArrayUtils.Empty<TValue>();
            return array.Values<TValue>().ToArray();
        }

    }

}