using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

/// <summary>
/// Static class with various methods for parsing instances of <see cref="JToken"/>.
/// </summary>
public static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the array.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting each child token into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An array of <typeparamref name="T"/> if <paramref name="token"/> is an array; otherwise, <see langword="null"/>.</returns>
    public static T[]? ConvertTokenToArray<T>(JToken? token, Func<JToken, T> callback) {

        if (token is not JArray array) return null;
        if (array.Count == 0) return [];

        List<T> temp = [];

        foreach (JToken item in array) {
            temp.Add(callback(item));
        }

        return [..temp];

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The item type of the array.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting each child object into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An array of <typeparamref name="T"/> if <paramref name="token"/> is an array; otherwise, <see langword="null"/>.</returns>
    public static T[]? ConvertTokenToArray<T>(JToken? token, Func<JObject, T> callback) {

        if (token is not JArray array) return null;
        if (array.Count == 0) return [];

        List<T> temp = [];

        foreach (JToken item in array) {
            if (item is JObject obj) temp.Add(callback(obj));
        }

        return [..temp];

    }

    internal static IReadOnlyList<T> ConvertTokenToReadOnlyList<T>(JToken? token, Func<JObject, T> callback) {

        // TODO: should this return null if token is not an array?

        if (token is not JArray array || array.Count == 0) return [];

        List<T> temp = [];

        foreach (JToken item in array) {
            if (item is JObject obj) temp.Add(callback(obj));
        }

        return temp;

    }

}