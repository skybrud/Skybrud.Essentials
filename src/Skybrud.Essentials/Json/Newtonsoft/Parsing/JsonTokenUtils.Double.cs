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

        internal static double GetDouble(JToken? token) {
            return GetDouble(token, default);
        }

        internal static double GetDouble(JToken? token, double fallback) {
            return TryGetDouble(token, out double? result) ? result.Value : fallback;
        }

        internal static T? GetDouble<T>(JToken? token, Func<double, T> callback) {
            return TryGetDouble(token, out double? result) ? callback(result.Value) : default;
        }

        internal static double? GetDoubleOrNull(JToken? token) {
            return TryGetDouble(token, out double? result) ? result : null;
        }

        internal static bool TryGetDouble(JToken? token, out double result) {

            if (TryGetDouble(token, out double? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetDouble(JToken? token, [NotNullWhen(true)] out double? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>() ? 1 : 0;
                    return true;

                case JTokenType.Integer:
                case JTokenType.Float:
                    result = token.Value<double>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseDouble(token.Value<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static double[] GetDoubleArray(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToDoubleArray(),
                JTokenType.Array => ConvertArrayTokenToDoubleArray(token),
                _ => TryGetDouble(token, out double? result) ? new[] { result.Value } : ArrayUtils.Empty<double>()
            };
        }

        private static double[] ConvertArrayTokenToDoubleArray(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<double>();

            List<double> temp = new();

            foreach (JToken item in token) {
                if (TryGetDouble(item, out double? result)) {
                    temp.Add(result.Value);
                }
            }

            return temp.ToArray();

        }

    }

}