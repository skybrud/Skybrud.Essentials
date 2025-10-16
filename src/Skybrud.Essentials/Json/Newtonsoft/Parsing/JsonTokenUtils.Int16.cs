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
    /// Converts the specified <paramref name="token"/> into a 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 16-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static short ParseInt16(JToken? token) {
        return ParseInt16(token, 0);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted 16-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static short ParseInt16(JToken? token, short fallback) {
        return TryParseInt16(token, out short? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseInt16<T>(JToken? token, Func<short, T> callback) {
        return TryParseInt16(token, out short? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 16-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static short? ParseInt16OrNull(JToken? token) {
        return TryParseInt16(token, out short? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 16-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt16(JToken? token, out short result) {

        if (TryParseInt16(token, out short? temp)) {
            result = temp.Value;
            return true;
        }

        result = 0;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 16-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt16(JToken? token, [NotNullWhen(true)] out short? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? (short) 1 : (short) 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                long longValue = token.Value<long>();
                if (longValue is < short.MinValue or > short.MaxValue) {
                    result = null;
                    return false;
                }
                result = (short) longValue;
                return true;

            case JTokenType.String:
                return StringUtils.TryParseInt16(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of 16-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A 16-bit integer array.</returns>
    public static short[] ParseInt16Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToInt16Array(),
            JTokenType.Array => ConvertArrayTokenToInt16Array(token),
            _ => TryParseInt16(token, out short? result) ? [result.Value] : []
        };
    }

    private static short[] ConvertArrayTokenToInt16Array(JToken token) {

        if (token is not JArray) return [];

        List<short> temp = [];

        foreach (JToken item in token) {
            if (TryParseInt16(item, out short? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}