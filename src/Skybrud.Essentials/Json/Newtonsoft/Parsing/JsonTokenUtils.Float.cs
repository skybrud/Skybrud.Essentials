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
    /// Converts the specified <paramref name="token"/> into a <see cref="float"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="float"/> value if successful; otherwise, <c>0</c>.</returns>
    public static float GetFloat(JToken? token) {
        return GetFloat(token, default);
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="float"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted <see cref="float"/> value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float GetFloat(JToken? token, float fallback) {
        return TryGetFloat(token, out float? result) ? result.Value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? GetFloat<T>(JToken? token, Func<float, T> callback) {
        return TryGetFloat(token, out float? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="float"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(JToken? token) {
        return TryGetFloat(token, out float? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="float"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="float"/> value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(JToken? token, out float result) {

        if (TryGetFloat(token, out float? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="float"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(JToken? token, [NotNullWhen(true)] out float? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>() ? 1 : 0;
                return true;

            case JTokenType.Integer:
            case JTokenType.Float:
                result = token.Value<float>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseFloat(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an array of <see cref="float"/> values.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A <see cref="float"/> array.</returns>
    public static float[] GetFloatArray(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToFloatArray(),
            JTokenType.Array => ConvertArrayTokenToFloatArray(token),
            _ => TryGetFloat(token, out float? result) ? [result.Value] : []
        };
    }

    private static float[] ConvertArrayTokenToFloatArray(JToken token) {

        if (token is not JArray) return [];

        List<float> temp = [];

        foreach (JToken item in token) {
            if (TryGetFloat(item, out float? result)) {
                temp.Add(result.Value);
            }
        }

        return [..temp];

    }

}