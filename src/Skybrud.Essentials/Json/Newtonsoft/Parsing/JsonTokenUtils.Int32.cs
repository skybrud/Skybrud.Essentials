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

        internal static int GetInt32(JToken? token) {
            return GetInt32(token, default);
        }

        internal static int GetInt32(JToken? token, int fallback) {
            return TryGetInt32(token, out int? result) ? result.Value : fallback;
        }

        internal static T? GetInt32<T>(JToken? token, Func<int, T> callback) {
            return TryGetInt32(token, out int? result) ? callback(result.Value) : default;
        }

        internal static int? GetInt32OrNull(JToken? token) {
            return TryGetInt32(token, out int? result) ? result : null;
        }

        internal static bool TryGetInt32(JToken? token, out int result) {

            if (TryGetInt32(token, out int? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetInt32(JToken? token, [NotNullWhen(true)] out int? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.ToObject<bool>() ? 1 : 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.ToObject<int>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseInt32(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static int[] GetInt32Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToInt32Array(),
                JTokenType.Array => ConvertArrayTokenToInt32Array(token),
                _ => TryGetInt32(token, out int? result) ? new[] { result.Value } : ArrayUtils.Empty<int>()
            };
        }


        internal static int[] ConvertArrayTokenToInt32Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<int>();

            List<int> temp = new();

            foreach (JToken item in token) {
                if (TryGetInt32(item, out int? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}