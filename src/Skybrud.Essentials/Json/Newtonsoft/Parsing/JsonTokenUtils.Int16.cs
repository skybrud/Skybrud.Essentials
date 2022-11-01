using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        internal static short GetInt16(JToken? token) {
            return GetInt16(token, default);
        }

        internal static short GetInt16(JToken? token, short fallback) {
            return TryGetInt16(token, out short? result) ? result.Value : fallback;
        }

        internal static T? GetInt16<T>(JToken? token, Func<short, T> callback) {
            return TryGetInt16(token, out short? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetInt16(JToken? token, out short result) {

            if (TryGetInt16(token, out short? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetInt16(JToken? token, [NotNullWhen(true)] out short? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? (short) 1 : (short) 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.Value<short>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseInt16(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static short[] GetInt16Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToInt16Array(),
                JTokenType.Array => ConvertArrayTokenToInt16Array(token),
                _ => TryGetInt16(token, out short? result) ? new[] { result.Value } : ArrayUtils.Empty<short>()
            };
        }

        private static short[] ConvertArrayTokenToInt16Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<short>();

            List<short> temp = new();

            foreach (JToken item in token) {
                if (TryGetInt16(item, out short? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}