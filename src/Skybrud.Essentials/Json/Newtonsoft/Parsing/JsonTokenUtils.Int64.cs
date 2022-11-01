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

        internal static long GetInt64(JToken? token) {
            return GetInt64(token, default);
        }

        internal static long GetInt64(JToken? token, long fallback) {
            return TryGetInt64(token, out long? result) ? result.Value : fallback;
        }

        internal static T? GetInt64<T>(JToken? token, Func<long, T> callback) {
            return TryGetInt64(token, out long? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetInt64(JToken? token, out long result) {

            if (TryGetInt64(token, out long? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetInt64(JToken? token, [NotNullWhen(true)] out long? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.ToObject<bool>() ? 1 : 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.ToObject<long>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseInt64(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static long[] GetInt64Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToInt64Array(),
                JTokenType.Array => ConvertArrayTokenToInt64Array(token),
                _ => TryGetInt64(token, out long? result) ? new[] { result.Value } : ArrayUtils.Empty<long>()
            };
        }

        internal static long[] ConvertArrayTokenToInt64Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<long>();

            List<long> temp = new();

            foreach (JToken item in token) {
                if (TryGetInt64(item, out long? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }


    }

}