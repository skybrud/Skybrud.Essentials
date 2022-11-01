using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        internal static Guid GetGuid(JToken? token) {
            return token?.Type switch {
                JTokenType.Guid => token.ToObject<Guid>(),
                JTokenType.String => token.ToObject<string>().ToGuid(),
                _ => Guid.Empty
            };
        }

        internal static Guid GetGuid(JToken? token, Guid fallback) {
            return token?.Type switch {
                JTokenType.Guid => token.ToObject<Guid>(),
                JTokenType.String => token.ToObject<string>().ToGuid(fallback),
                _ => fallback
            };
        }

        internal static T? GetGuid<T>(JToken? token, Func<Guid, T> callback) {
            return TryGetGuid(token, out Guid? result) ? callback(result.Value) : default;
        }

        internal static bool TryGetGuid(JToken? token, out Guid result) {

            if (TryGetGuid(token, out Guid? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetGuid(JToken? token, [NotNullWhen(true)] out Guid? result) {

            switch (token?.Type) {

                case JTokenType.Guid:
                    result = token.ToObject<Guid>();
                    return true;

                case JTokenType.String:
                    return StringUtils.TryParseGuid(token.ToObject<string>(), out result);

                default:
                    result = null;
                    return false;

            }

        }

        internal static Guid[] GetGuidArray(JToken? token) {

            switch (token) {

                case null:
                    return ArrayUtils.Empty<Guid>();

                case JArray array:

                    List<Guid> temp = new();

                    foreach (JToken t in array) {

                        // Attempt to parse the individual tokens in the array, ensuring invalid values doesn't trigger an exception
                        if (t != null && Guid.TryParse(t.ToString(), out Guid guid)) temp.Add(guid);

                    }

                    return temp.ToArray();

                default:

                    // Be friendly to other formats
                    return token.Type switch {
                        JTokenType.String => StringUtils.ParseGuidArray(token.Value<string>()),
                        JTokenType.Guid => new[] { token.Value<Guid>() },
                        _ => ArrayUtils.Empty<Guid>()
                    };

            }

        }

    }

}