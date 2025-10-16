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
    /// Converts the specified <paramref name="token"/> into a <see cref="double"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="double"/> value if successful; otherwise, <c>0</c>.</returns>
    public static double ParseDouble(JToken? token) {
        return ParseDouble(token, 0);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="double"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted <see cref="double"/> value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double ParseDouble(JToken? token, double fallback) {
        return TryParseDouble(token, out double? result) ? result.Value : fallback;
    }

    internal static T? ParseDouble<T>(JToken? token, Func<double, T> callback) {
        return TryParseDouble(token, out double? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="double"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</returns>
    public static double? ParseDoubleOrNull(JToken? token) {
        return TryParseDouble(token, out double? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="double"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="double"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDouble(JToken? token, out double result) {

        if (TryParseDouble(token, out double? temp)) {
            result = temp.Value;
            return true;
        }

        result = 0;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="double"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDouble(JToken? token, [NotNullWhen(true)] out double? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? 1 : 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.Value<double>();
                if (result is double.NegativeInfinity) result = null;
                if (result is double.PositiveInfinity) result = null;
                return result is not null;

            case JTokenType.String:
                if (!StringUtils.TryParseDouble(token.Value<string>(), out result)) return false;
                if (result is double.NegativeInfinity) result = null;
                if (result is double.PositiveInfinity) result = null;
                return result is not null;

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of double-precision floating point numbers (<see cref="double"/>).
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>An array with the double-precision floating point numbers.</returns>
    public static double[] ParseDoubleArray(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToDoubleArray(),
            JTokenType.Array => ConvertArrayTokenToDoubleArray(token),
            _ => TryParseDouble(token, out double? result) ? [result.Value] : []
        };
    }

    private static double[] ConvertArrayTokenToDoubleArray(JToken token) {

        if (token is not JArray) return [];

        List<double> temp = [];

        foreach (JToken item in token) {
            if (TryParseDouble(item, out double? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}