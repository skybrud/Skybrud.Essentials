using System;
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
    public static TEnum GetEnum<TEnum>(JToken? token) where TEnum : Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.FromInt32Internal<TEnum>(token.Value<int>()),
            JTokenType.Float => EnumUtils.FromInt32Internal<TEnum>(token.Value<int>()),
            JTokenType.String => EnumUtils.ParseEnumInternal<TEnum>(token.Value<string>()),
            _ => throw new EnumParseException(typeof(TEnum), token.Value<string>())
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a corresponding enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <param name="fallback">The fallback value to be returned if the conversion fails.</param>
    /// <returns>The converted enum value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static TEnum GetEnum<TEnum>(JToken? token, TEnum fallback) where TEnum : Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.FromInt32(token.Value<int>(), fallback),
            JTokenType.Float => EnumUtils.FromInt32(token.Value<int>(), fallback),
            JTokenType.String => EnumUtils.ParseEnumInternal(token.Value<string>(), fallback),
            _ => fallback
        };
    }

    /// <summary>
    /// Converts the specified <paramref name="token"/> into a corresponding enum value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="token">The token to be converted.</param>
    /// <returns>The converted enum value if successful; otherwise, <see langword="null"/>.</returns>
    public static TEnum? GetEnumOrNull<TEnum>(JToken? token) where TEnum : struct, Enum {
        return token?.Type switch {
            JTokenType.Integer => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
            JTokenType.Float => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
            JTokenType.String => EnumUtils.ParseEnumOrNull<TEnum>(token.Value<string>()),
            _ => null
        };
    }

}