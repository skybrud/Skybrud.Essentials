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
    /// Converts the specified <paramref name="token"/> into an unsigned 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static uint ParseUInt32(JToken? token) {
        return ParseUInt32(token, 0);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted unsigned 32-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static uint ParseUInt32(JToken? token, uint fallback) {
        return TryParseUInt32(token, out uint? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseUInt32<T>(JToken? token, Func<uint, T> callback) {
        return TryParseUInt32(token, out uint? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an unsigned 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted unsigned 32-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static uint? ParseUInt32OrNull(JToken? token) {
        return TryParseUInt32(token, out uint? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 32-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt32(JToken? token, out uint result) {

        if (TryParseUInt32(token, out uint? temp)) {
            result = temp.Value;
            return true;
        }

        result = 0;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into an unsigned 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted unsigned 32-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt32(JToken? token, [NotNullWhen(true)] out uint? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? 1 : (uint) 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                double value = token.ToObject<double>();
                if (value is < uint.MinValue or > uint.MaxValue) {
                    result = null;
                    return false;
                }
                result = (uint) value;
                return true;

            case JTokenType.String:
                return StringUtils.TryParseUInt32(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of unsigned 32-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>An unsigned 32-bit integer array.</returns>
    public static uint[] ParseUInt32Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToUInt32Array(),
            JTokenType.Array => ConvertArrayTokenToUInt32Array(token),
            _ => TryParseUInt32(token, out uint? result) ? [result.Value] : []
        };
    }


    private static uint[] ConvertArrayTokenToUInt32Array(JToken token) {

        if (token is not JArray) return [];

        List<uint> temp = [];

        foreach (JToken item in token) {
            if (TryParseUInt32(item, out uint? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}