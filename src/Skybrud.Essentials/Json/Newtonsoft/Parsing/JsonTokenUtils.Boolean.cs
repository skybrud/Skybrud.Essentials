using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches a *truthy* value; otherwise, <see langword="false"/>.</returns>
    public static bool ParseBoolean(JToken? token) {
        return TryParseBoolean(token, out bool result) && result;
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">The fallback value to be returned if <paramref name="token"/> matches neither a *truthy* nor *falsy* value.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches a *truthy* value, <see langword="false"/> if <paramref name="token"/> matches a *falsy* value. If neither, <paramref name="fallback"/> is returned instead.</returns>
    public static bool ParseBoolean(JToken? token, bool fallback) {
        return TryParseBoolean(token, out bool result) ? result : fallback; 
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches a *truthy* value, <see langword="false"/> if <paramref name="token"/> matches a *falsy* value. If neither, <see langword="null"/> is returned instead.</returns>
    public static bool? ParseBooleanOrNull(JToken? token) {
        return TryParseBoolean(token, out bool? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds a boolean value matching either a *truthy* or *falsy* value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches either a *truthy* or *falsy* value; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseBoolean(JToken? token, out bool result) {

        if (TryParseBoolean(token, out bool? temp)) {
            result = temp.Value;
            return true;
        }

        result = false;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds a boolean value matching either a *truthy* or *falsy* value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches either a *truthy* or *falsy* value; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseBoolean(JToken? token, [NotNullWhen(true)] out bool? result) {

        result = token?.ToObject<object>() switch {
            bool boolean => boolean,
            long int64 => int64 switch {
                0 => false,
                1 => true,
                _ => null,
            },
            int int32 => int32 switch {
                0 => false,
                1 => true,
                _ => null,
            },
            string str => StringUtils.ParseBooleanOrNull(str),
            _ => null
        };

        return result is not null;

    }

}