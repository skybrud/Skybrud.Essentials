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

        internal static float GetFloat(JToken? token) {
            return GetFloat(token, default);
        }

        internal static float GetFloat(JToken? token, float fallback) {
            return TryGetFloat(token, out float? result) ? result.Value : fallback;
        }

        internal static T? GetFloat<T>(JToken? token, Func<float, T> callback) {
            return TryGetFloat(token, out float? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetFloat(JToken? token, out float result) {

            if (TryGetFloat(token, out float? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetFloat(JToken? token, [NotNullWhen(true)] out float? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? 1 : 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.Value<float>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseFloat(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static float[] GetFloatArray(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToFloatArray(),
                JTokenType.Array => ConvertArrayTokenToFloatArray(token),
                _ => TryGetFloat(token, out float? result) ? new[] { result.Value } : ArrayUtils.Empty<float>()
            };
        }

        private static float[] ConvertArrayTokenToFloatArray(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<float>();

            List<float> temp = new();

            foreach (JToken item in token) {
                if (TryGetFloat(item, out float? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}