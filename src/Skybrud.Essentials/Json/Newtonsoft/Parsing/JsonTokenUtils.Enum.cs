using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;

// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing;

static partial class JsonTokenUtils {

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a corresponding enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted enum value if successful.</returns>
    /// <exception cref="EnumParseException">If the type <paramref name="token"/> is not supported, or the doesn't match a valid token value.</exception>
    public static TEnum ParseEnum<TEnum>(JToken? token) where TEnum : struct, Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.FromInt32<TEnum>(token.Value<int>()),
            JTokenType.Float => EnumUtils.FromInt32<TEnum>(token.Value<int>()),
            JTokenType.String => EnumUtils.ParseEnum<TEnum>(token.Value<string>()),
            _ => throw new EnumParseException(typeof(TEnum), token?.Value<string>())
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a corresponding enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">The fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted enum value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static TEnum ParseEnum<TEnum>(JToken? token, TEnum fallback) where TEnum : struct, Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.FromInt32(token.Value<int>(), fallback),
            JTokenType.Float => EnumUtils.FromInt32(token.Value<int>(), fallback),
            JTokenType.String => EnumUtils.ParseEnum(token.Value<string>()!, fallback),
            _ => fallback
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a corresponding enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted enum value if successful; otherwise, <see langword="null"/>.</returns>
    public static TEnum? ParseEnumOrNull<TEnum>(JToken? token) where TEnum : struct, Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
            JTokenType.Float => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
            JTokenType.String => EnumUtils.ParseEnumOrNull<TEnum>(token.Value<string>()),
            _ => null
        };
    }

    /// <summary>
    /// Attempts to parse the specified JSON <paramref name="token"/> into an enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <typeparamref name="TEnum"/> value if successful; otherwise, the default value of <typeparamref name="TEnum"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseEnum<TEnum>(JToken? token, out TEnum result) where TEnum : struct, Enum {

        switch (token?.Type) {

            case JTokenType.Integer:
                return EnumUtils.TryParseEnum(token.Value<int>(), out result);

            case JTokenType.Float:
                return EnumUtils.TryParseEnum(token.Value<int>(), out result);

            case JTokenType.String:
                return EnumUtils.TryParseEnum(token.Value<string>(), out result);

            default:
                result = default;
                return false;

        }

    }

    /// <summary>
    /// Attempts to parse the specified JSON <paramref name="token"/> into an enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="result">When this method returns, holds the converted <typeparamref name="TEnum"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseEnum<TEnum>(JToken? token, [NotNullWhen(true)] out TEnum? result) where TEnum : struct, Enum {

        switch (token?.Type) {

            case JTokenType.Integer:
                return EnumUtils.TryParseEnum(token.Value<int>(), out result);

            case JTokenType.Float:
                return EnumUtils.TryParseEnum(token.Value<int>(), out result);

            case JTokenType.String:
                return EnumUtils.TryParseEnum(token.Value<string>(), out result);

            default:
                result = null;
                return false;

        }

    }

}