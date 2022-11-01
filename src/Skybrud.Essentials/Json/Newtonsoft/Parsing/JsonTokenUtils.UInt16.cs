using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        internal static ushort GetUInt16(JToken? token) {
            return GetUInt16(token, default);
        }

        internal static ushort GetUInt16(JToken? token, ushort fallback) {
            return TryGetUInt16(token, out ushort? result) ? result.Value : fallback;
        }

        internal static T? GetUInt16<T>(JToken? token, Func<ushort, T> callback) {
            return TryGetUInt16(token, out ushort? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetUInt16(JToken? token, out ushort result) {

            if (TryGetUInt16(token, out ushort? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetUInt16(JToken? token, [NotNullWhen(true)] out ushort? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? (ushort) 1 : (ushort) 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.ToObject<ushort>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseUInt16(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static ushort[] GetUInt16Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToUInt16Array(),
                JTokenType.Array => ConvertArrayTokenToUInt16Array(token),
                _ => TryGetUInt16(token, out ushort? result) ? new[] { result.Value } : ArrayUtils.Empty<ushort>()
            };
        }


        private static ushort[] ConvertArrayTokenToUInt16Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<ushort>();

            List<ushort> temp = new();

            foreach (JToken item in token) {
                if (TryGetUInt16(item, out ushort? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}