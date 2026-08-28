using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="Guid"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid ParseGuid(JToken? token) {
        return token?.Type switch {
            JTokenType.Guid => token.ToObject<Guid>(),
            JTokenType.String => token.ToObject<string>().ToGuid(),
            _ => Guid.Empty
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="Guid"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">A fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted <see cref="Guid"/> value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid ParseGuid(JToken? token, Guid fallback) {
        return token?.Type switch {
            JTokenType.Guid => token.ToObject<Guid>(),
            JTokenType.String => token.ToObject<string>().ToGuid(fallback),
            _ => fallback
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result of the conversion.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="callback">A callback function used for converting a <see cref="Guid"/> value into an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</returns>
    public static T? ParseGuid<T>(JToken? token, Func<Guid, T> callback) {
        return TryParseGuid(token, out Guid? result) ? callback(result.Value) : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="Guid"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? ParseGuidOrNull(JToken? token) {
        return TryParseGuid(token, out Guid? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="Guid"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseGuid(JToken? token, out Guid result) {

        if (TryParseGuid(token, out Guid? temp)) {
            result = temp.Value;
            return true;
        }

        result = Guid.Empty;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a <see cref="Guid"/> value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseGuid(JToken? token, [NotNullWhen(true)] out Guid? result) {

        switch (token?.Type) {

            case JTokenType.Guid:
                result = token.ToObject<Guid>();
                return true;

            case JTokenType.String:
                return StringUtils.TryParseGuid(token.ToObject<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="Guid"/> array.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A <see cref="Guid"/> array.</returns>
    public static Guid[] ParseGuidArray(JToken? token) {

        switch (token) {

            case null:
                return [];

            case JArray array:

                List<Guid> temp = [];

                foreach (JToken t in array) {

                    // Attempt to parse the individual tokens in the array, ensuring invalid values doesn't trigger an exception
                    if (t != null && Guid.TryParse(t.ToString(), out Guid guid)) temp.Add(guid);

                }

                return [..temp];

            default:

                // Be friendly to other formats
                return token.Type switch {
                    JTokenType.String => StringUtils.ParseGuidArray(token.Value<string>()),
                    JTokenType.Guid => [token.Value<Guid>()],
                    _ => []
                };

        }

    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a <see cref="Guid"/> list.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns>A <see cref="Guid"/> list.</returns>
    public static List<Guid> ParseGuidList(JToken? token) {

        switch (token) {

            case null:
                return [];

            case JArray array:

                List<Guid> temp = [];

                foreach (JToken t in array) {

                    // Attempt to parse the individual tokens in the array, ensuring invalid values doesn't trigger an exception
                    if (Guid.TryParse(t.ToString(), out Guid guid)) temp.Add(guid);

                }

                return [.. temp];

            default:

                // Be friendly to other formats
                return token.Type switch {
                    JTokenType.String => StringUtils.ParseGuidList(token.Value<string>()),
                    JTokenType.Guid => [token.Value<Guid>()],
                    _ => []
                };

        }

    }

}