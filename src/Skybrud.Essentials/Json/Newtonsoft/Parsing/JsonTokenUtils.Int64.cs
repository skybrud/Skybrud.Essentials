using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 64-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static long ParseInt64(JToken? token) {
        return ParseInt64(token, 0);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted 64-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static long ParseInt64(JToken? token, long fallback) {
        return TryParseInt64(token, out long? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseInt64<T>(JToken? token, Func<long, T> callback) {
        return TryParseInt64(token, out long? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 64-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static long? ParseInt64OrNull(JToken? token) {
        return TryParseInt64(token, out long? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 64-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt64(JToken? token, out long result) {

        if (TryParseInt64(token, out long? temp)) {
            result = temp.Value;
            return true;
        }

        result = 0;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 64-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt64(JToken? token, [NotNullWhen(true)] out long? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.ToObject<bool>() ? 1 : 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.ToObject<long>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseInt64(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of 64-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A 64-bit integer array.</returns>
    public static long[] ParseInt64Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToInt64Array(),
            JTokenType.Array => ConvertArrayTokenToInt64Array(token),
            _ => TryParseInt64(token, out long? result) ? [result.Value] : []
        };
    }

    private static long[] ConvertArrayTokenToInt64Array(JToken token) {

        if (token is not JArray) return [];

        List<long> temp = [];

        foreach (JToken item in token) {
            if (TryParseInt64(item, out long? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}