using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time.Iso8601;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        #region System.String

        internal static string? GetString(JToken? token) {
            return TryGetString(token, out string? result) ? result : null;
        }

        internal static T? GetString<T>(JToken? token, Func<string, T> callback) {
            return TryGetString(token, out string? result) ? callback(result) : default;
        }

        internal static bool TryGetString(JToken? token, [NotNullWhen(true)] out string? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.Guid:
                    result = string.Format(CultureInfo.InvariantCulture, "{0}", token);
                    return true;

                case JTokenType.Date:
                    switch (token.ToObject<object>()) {
                        case DateTime dt:
                            result = dt.ToString(Iso8601Constants.DateTimeMilliseconds);
                            return true;
                        case DateTimeOffset dto:
                            result = dto.ToString(Iso8601Constants.DateTimeMilliseconds);
                            return true;
                        default:
                            result = null;
                            return false;
                    }

                case JTokenType.String:
                    result = token.Value<string>();
                    return true;

                default:
                    result = null;
                    return false;

            }

        }

        internal static string[] GetStringArray(JToken? token) {
            return token?.Type switch {
                JTokenType.String => token.Value<string>().ToStringArray(),
                JTokenType.Array => ConvertArrayTokenToStringArray(token),
                _ => TryGetString(token, out string? result) ? new[] { result } : ArrayUtils.Empty<string>()
            };
        }

        internal static string[] ConvertArrayTokenToStringArray(JToken token) {

            if (token is not JArray) return ArrayUtils.Empty<string>();

            List<string> temp = new();

            foreach (JToken item in token) {
                if (TryGetString(item, out string? result)) {
                    temp.Add(result);
                }
            }

            return temp.ToArray();

        }

        #endregion

    }

}