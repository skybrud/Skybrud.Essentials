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
    public static bool GetBoolean(JToken? token) {
        return token?.Type switch {
            JTokenType.Boolean => token.Value<bool>(),
            JTokenType.Integer => token.Value<int>() switch {
                0 => false,
                1 => true,
                _ => false,
            },
            JTokenType.String => StringUtils.ParseBoolean(token.Value<string>()),
            _ => false,
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">The fallback value to be returned if <paramref name="token"/> matches neither a *truthy* nor *falsy* value.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches a *truthy* value, <see langword="false"/> if <paramref name="token"/> matches a *falsy* value. If neither, <paramref name="fallback"/> is returned instead.</returns>
    public static bool GetBoolean(JToken? token, bool fallback) {
        return token?.Type switch {
            JTokenType.Boolean => token.Value<bool>(),
            JTokenType.Integer => token.Value<int>() switch {
                0 => false,
                1 => true,
                _ => fallback,
            },
            JTokenType.String => StringUtils.ParseBoolean(token.Value<string>(), fallback),
            _ => fallback,
        };
    }
    /// <summary>
    /// Converts the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches a *truthy* value, <see langword="false"/> if <paramref name="token"/> matches a *falsy* value. If neither, <see langword="null"/> is returned instead.</returns>
    public static bool? GetBooleanOrNull(JToken? token) {
        return TryGetBoolean(token, out bool? result) ? result : null;
    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds a boolean value matching either a *truthy* or *falsy* value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches either a *truthy* or *falsy* value; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(JToken? token, out bool result) {

        if (TryGetBoolean(token, out bool? temp)) {
            result = temp.Value;
            return true;
        }

        result = default;
        return false;

    }

    /// <summary>
    /// Attempts to convert the specified <paramref name="token"/> into a boolean value.
    /// </summary>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds a boolean value matching either a *truthy* or *falsy* value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="token"/> matches either a *truthy* or *falsy* value; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(JToken? token, [NotNullWhen(true)] out bool? result) {

        switch (token?.Type) {

            case JTokenType.Boolean:
                result = token.Value<bool>();
                return true;

            case JTokenType.Integer:

                switch (token.Value<int>()) {

                    case 0:
                        result = false;
                        return true;

                    case 1:
                        result = true;
                        return true;

                    default:
                        result = false;
                        return false;

                }

            case JTokenType.String:
                return StringUtils.TryParseBoolean(token.Value<string>(), out result);

            default:
                result = false;
                return false;

        }

    }

}