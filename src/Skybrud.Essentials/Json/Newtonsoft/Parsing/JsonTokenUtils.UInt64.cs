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

        internal static ulong GetUInt64(JToken? token) {
            return GetUInt64(token, default);
        }

        internal static ulong GetUInt64(JToken? token, ulong fallback) {
            return TryGetUInt64(token, out ulong? result) ? result.Value : fallback;
        }

        internal static T? GetUInt64<T>(JToken? token, Func<ulong, T> callback) {
            return TryGetUInt64(token, out ulong? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetUInt64(JToken? token, out ulong result) {

            if (TryGetUInt64(token, out ulong? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetUInt64(JToken? token, [NotNullWhen(true)] out ulong? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? 1 : (ulong) 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.ToObject<ulong>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseUInt64(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static ulong[] GetUInt64Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToUInt64Array(),
                JTokenType.Array => ConvertArrayTokenToUInt64Array(token),
                _ => TryGetUInt64(token, out ulong? result) ? new[] { result.Value } : ArrayUtils.Empty<ulong>()
            };
        }


        private static ulong[] ConvertArrayTokenToUInt64Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<ulong>();

            List<ulong> temp = new();

            foreach (JToken item in token) {
                if (TryGetUInt64(item, out ulong? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}