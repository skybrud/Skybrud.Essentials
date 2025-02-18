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
    /// Converts the specified <paramref name="token"/> into a 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static int ParseInt32(JToken? token) {
        return ParseInt32(token, default);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted 32-bit integer value if successful; otherwise, <paramref name="fallback"/>>.</returns>
    public static int ParseInt32(JToken? token, int fallback) {
        return TryParseInt32(token, out int? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseInt32<T>(JToken? token, Func<int, T> callback) {
        return TryParseInt32(token, out int? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted 32-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static int? ParseInt32OrNull(JToken? token) {
        return TryParseInt32(token, out int? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 32-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt32(JToken? token, out int result) {

        if (TryParseInt32(token, out int? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a 32-bit integer value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted 32-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseInt32(JToken? token, [NotNullWhen(true)] out int? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.ToObject<bool>() ? 1 : 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.ToObject<int>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseInt32(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of 32-bit integer values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A 32-bit integer array.</returns>
    public static int[] ParseInt32Array(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToInt32Array(),
            JTokenType.Array => ConvertArrayTokenToInt32Array(token),
            _ => TryParseInt32(token, out int? result) ? [result.Value] : []
        };
    }


    internal static int[] ConvertArrayTokenToInt32Array(JToken token) {

        if (token is not JArray) return [];

        List<int> temp = [];

        foreach (JToken item in token) {
            if (TryParseInt32(item, out int? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}