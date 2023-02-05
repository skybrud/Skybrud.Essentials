using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;

// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        public static T GetEnum<T>(JToken? token) where T : Enum {
            return token?.Type switch {
                JTokenType.Integer => EnumUtils.FromInt32Internal<T>(token.Value<int>()),
                JTokenType.Float => EnumUtils.FromInt32Internal<T>(token.Value<int>()),
                JTokenType.String => EnumUtils.ParseEnumInternal<T>(token.Value<string>()),
                _ => throw new EnumParseException(typeof(T), token.Value<string>())
            };
        }

        public static T GetEnum<T>(JToken? token, T fallback) where T : Enum {
            return token?.Type switch {
                JTokenType.Integer => EnumUtils.FromInt32(token.Value<int>(), fallback),
                JTokenType.Float => EnumUtils.FromInt32(token.Value<int>(), fallback),
                JTokenType.String => EnumUtils.ParseEnumInternal(token.Value<string>(), fallback),
                _ => fallback
            };
        }

        public static TEnum? GetEnumOrNull<TEnum>(JToken? token) where TEnum : struct, Enum {
            return token?.Type switch {
                JTokenType.Integer => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
                JTokenType.Float => EnumUtils.ToEnumOrNull<TEnum>(token.Value<int>()),
                JTokenType.String => EnumUtils.ParseEnumOrNull<TEnum>(token.Value<string>()),
                _ => null
            };
        }

    }

}