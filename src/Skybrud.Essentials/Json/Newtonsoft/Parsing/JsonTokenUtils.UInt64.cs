using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 64-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static ulong ParseUInt64(JToken? token) {
        return ParseUInt64(token, default);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted unsigned 64-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static ulong ParseUInt64(JToken? token, ulong fallback) {
        return TryParseUInt64(token, out ulong? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseUInt64<T>(JToken? token, Func<ulong, T> callback) {
        return TryParseUInt64(token, out ulong? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 64-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static ulong? ParseUInt64OrNull(JToken? token) {
        return TryParseUInt64(token, out ulong? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 64-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt64(JToken? token, out ulong result) {

        if (TryParseUInt64(token, out ulong? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 64-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 64-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt64(JToken? token, [NotNullWhen(true)] out ulong? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? 1 : (ulong) 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.ToObject<ulong>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseUInt64(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of unsigned 64-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>An unsigned 64-bit integer array.</returns>
    public static ulong[] ParseUInt64Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToUInt64Array(),
            JTokenType.Array => ConvertArrayTokenToUInt64Array(token),
            _ => TryParseUInt64(token, out ulong? result) ? [result.Value] : []
        };
    }


    private static ulong[] ConvertArrayTokenToUInt64Array(JToken token) {

        if (token is not JArray) return [];

        List<ulong> temp = [];

        foreach (JToken item in token) {
            if (TryParseUInt64(item, out ulong? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}