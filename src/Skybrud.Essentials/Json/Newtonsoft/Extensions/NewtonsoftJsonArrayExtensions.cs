using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="JArray"/>.
/// </summary>
public static partial class NewtonsoftJsonArrayExtensions {

    #region System.Object

    /// <summary>
    /// Gets an object from the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
    public static JObject? GetObject(this JArray? array, int index) {
        return JsonTokenUtils.GetToken(array, index) as JObject;
    }

    /// <summary>
    /// Gets an object from the item at the specified <paramref name="index"/> in the array. If an object is found,
    /// it is parsed to the type of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not
    /// found.</returns>
    public static T? GetObject<T>(this JArray? array, int index) {
        return JsonTokenUtils.GetToken(array, index) is JObject child ? child.ToObject<T>() : default;
    }

    /// <summary>
    /// Gets an object from the item at the specified <paramref name="index"/> in the array. If an object is found,
    /// the object is parsed using the specified delegate <paramref name="callback"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="callback">The delegate (callback method) used for parsing the object.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T? GetObject<T>(this JArray? array, int index, Func<JObject, T> callback) {
        return array?[index] is JObject obj ? callback(obj) : default;
    }

    /// <summary>
    /// Gets an object from token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="JObject"/>, or <c>null</c> if not found.</returns>
    public static JObject? GetObjectByPath(this JArray? array, string path) {
        return array?.SelectToken(path) as JObject;
    }

    /// <summary>
    /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, it is
    /// parsed to the type of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if not
    /// found.</returns>
    public static T? GetObjectByPath<T>(this JArray? array, string path) {
        return array?.SelectToken(path) is JObject child ? child.ToObject<T>() : default;
    }

    /// <summary>
    /// Gets an object from token matching the specified <paramref name="path"/>. If an object is found, the object
    /// is parsed using the specified delegate <paramref name="callback"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The delegate (callback method) used for parsing the object.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T? GetObjectByPath<T>(this JArray? array, string path, Func<JObject, T> callback) {
        return array?.SelectToken(path) is JObject obj ? callback(obj) : default;
    }

    #endregion

    #region System.String

    /// <summary>
    /// Gets a string from the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    public static string? GetString(this JArray? array, int index) {
        return JsonTokenUtils.ParseString(JsonTokenUtils.GetToken(array, index));
    }

    /// <summary>
    /// Gets a string from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="string"/>, or <c>null</c> if <paramref name="path"/> didn't match
    /// any tokens.</returns>
    public static string? GetStringByPath(this JArray? array, string path) {
        return JsonTokenUtils.ParseString(array?.SelectToken(path));
    }

    /// <summary>
    /// Attempts to get the <see cref="string"/> value of the item at the specified <paramref name="index"/> in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="result">When this method returns, holds the <see cref="string"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching item is found, and the value matches or can be converted to a <see cref="string"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetString(this JArray? array, int index, [NotNullWhen(true)] out string? result) {
        return JsonTokenUtils.TryParseString(JsonTokenUtils.GetToken(array, index), out result);
    }

    /// <summary>
    /// Attempts to get the <see cref="string"/> value of the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="result">When this method returns, holds the <see cref="string"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching token is found, and the value matches or can be converted to a <see cref="string"/>; otherwise, <see langword="null"/>.</returns>
    public static bool TryGetStringByPath(this JArray? array, string path, [NotNullWhen(true)] out string? result) {
        return JsonTokenUtils.TryParseString(array?.SelectToken(path), out result);
    }

    #endregion

    #region Arrays

    /// <summary>
    /// Gets an instance of <see cref="JArray"/> from the item at the specified <paramref name="index"/> in the
    /// array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>An instance of <see cref="JArray"/>.</returns>
    public static JArray? GetArray(this JArray? array, int index) {
        return JsonTokenUtils.GetToken(array, index) as JArray;
    }

    /// <summary>
    /// Gets an array of <typeparamref name="T"/> from the item at the specified <paramref name="index"/> in the
    /// array using the specified delegate <paramref name="callback"/> for parsing each item in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="index">The index of the item.</param>
    /// <param name="callback">The delegate (callback method) used for parsing each item in the array.</param>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    public static T[]? GetArray<T>(this JArray? array, int index, Func<JObject, T> callback) {
        return JsonTokenUtils.GetToken(array, index) is not JArray property ? null : [.. from JObject child in property select callback(child)];

    }

    /// <summary>
    /// Gets an instance of <see cref="JArray"/> from the token matching the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <returns>An instance of <see cref="JArray"/>.</returns>
    public static JArray? GetArrayByPath(this JArray? array, string path) {
        return array?.SelectToken(path) as JArray;
    }

    /// <summary>
    /// Gets an array of <typeparamref name="T"/> from the token matching the specified
    /// <paramref name="path"/> in the array using the specified delegate <paramref name="callback"/> for parsing each
    /// item in the array.
    /// </summary>
    /// <param name="array">The parent array.</param>
    /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
    /// <param name="callback">The delegate (callback method) used for parsing each item in the array.</param>
    /// <returns>An array of <typeparamref name="T"/>.</returns>
    public static T[]? GetArrayByPath<T>(this JArray? array, string path, Func<JObject, T> callback) {
        if (array?.SelectToken(path) is not JArray token) return null;
        return [.. from JObject child in token select callback(child)];
    }

    #endregion

}