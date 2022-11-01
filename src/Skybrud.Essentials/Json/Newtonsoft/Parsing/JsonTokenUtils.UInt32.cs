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

        internal static uint GetUInt32(JToken? token) {
            return GetUInt32(token, default);
        }

        internal static uint GetUInt32(JToken? token, uint fallback) {
            return TryGetUInt32(token, out uint? result) ? result.Value : fallback;
        }

        internal static T? GetUInt32<T>(JToken? token, Func<uint, T> callback) {
            return TryGetUInt32(token, out uint? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetUInt32(JToken? token, out uint result) {

            if (TryGetUInt32(token, out uint? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetUInt32(JToken? token, [NotNullWhen(true)] out uint? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? 1 : (uint) 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.ToObject<uint>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseUInt32(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static uint[] GetUInt32Array(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToUInt32Array(),
                JTokenType.Array => ConvertArrayTokenToUInt32Array(token),
                _ => TryGetUInt32(token, out uint? result) ? new[] { result.Value } : ArrayUtils.Empty<uint>()
            };
        }


        private static uint[] ConvertArrayTokenToUInt32Array(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<uint>();

            List<uint> temp = new();

            foreach (JToken item in token) {
                if (TryGetUInt32(item, out uint? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}