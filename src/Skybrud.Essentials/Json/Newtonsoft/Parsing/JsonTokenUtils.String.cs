using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time.Iso8601;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a string value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted string value if successful; otherwise, <see langword="null"/>.</returns>
    public static string? ParseString(JToken? token) {
        return TryParseString(token, out string? result) ? result : null;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a string value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static T? ParseString<T>(JToken? token, Func<string, T> callback) {
        return TryParseString(token, out string? result) ? callback(result) : default;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a string value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When the method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseString(JToken? token, [NotNullWhen(true)] out string? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
            case JTokenType.Integer:
            case JTokenType.Float:
            case JTokenType.Guid:
                result = string.Format(CultureInfo.InvariantCulture, "{0}", token);
                return true;

            case JTokenType.Date:
                switch (token.ToObject<object>()) {
                    case DateTime dt:
                        result = dt.ToString(Iso8601Constants.DateTimeMilliseconds);
                        return true;
                    case DateTimeOffset dto:
                        result = dto.ToString(Iso8601Constants.DateTimeMilliseconds);
                        return true;
                    default:
                        result = null;
                        return false;
                }

            case JTokenType.String:
                result = token.Value<string>();
                return true;

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a string array.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A string array.</returns>
    public static string[] ParseStringArray(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToStringArray(),
            JTokenType.Array => ConvertArrayTokenToStringArray(token),
            _ => TryParseString(token, out string? result) ? [result] : []
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a string list.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A string list.</returns>
    public static List<string> ParseStringList(JToken? token) {
        return token?.Type switch {
            JTokenType.String => token.Value<string>().ToStringList(),
            JTokenType.Array => ConvertArrayTokenToStringList(token),
            _ => TryParseString(token, out string? result) ? [result] : []
        };
    }

    internal static string[] ConvertArrayTokenToStringArray(JToken token) {
        if (token is not JArray array || array.Count == 0) return [];
        return [.. ConvertArrayTokenToStringList(token)];
    }

    internal static List<string> ConvertArrayTokenToStringList(JToken token) {

        if (token is not JArray) return [];

        List<string> temp = [];

        foreach (JToken item in token) {
            if (TryParseString(item, out string? result)) temp.Add(result);
        }

        return temp;

    }

}