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
    /// Converts the specified <paramref name="token"/> into an unsigned 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 16-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static ushort GetUInt16(JToken? token) {
        return GetUInt16(token, default);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted unsigned 16-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static ushort GetUInt16(JToken? token, ushort fallback) {
        return TryGetUInt16(token, out ushort? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetUInt16<T>(JToken? token, Func<ushort, T> callback) {
        return TryGetUInt16(token, out ushort? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 16-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static ushort? GetUInt16OrNull(JToken? token) {
        return TryGetUInt16(token, out ushort? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 16-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUInt16(JToken? token, out ushort result) {

        if (TryGetUInt16(token, out ushort? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 16-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 16-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetUInt16(JToken? token, [NotNullWhen(true)] out ushort? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? (ushort) 1 : (ushort) 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.ToObject<ushort>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseUInt16(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of unsigned 16-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>An unsigned 16-bit integer array.</returns>
    public static ushort[] GetUInt16Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToUInt16Array(),
            JTokenType.Array => ConvertArrayTokenToUInt16Array(token),
            _ => TryGetUInt16(token, out ushort? result) ? [result.Value] : []
        };
    }


    private static ushort[] ConvertArrayTokenToUInt16Array(JToken token) {

        if (token is not JArray) return [];

        List<ushort> temp = [];

        foreach (JToken item in token) {
            if (TryGetUInt16(item, out ushort? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}