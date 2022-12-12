using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        internal static bool GetBoolean(JToken? token) {
            return token?.Type switch {
                JTokenType.Boolean => token.Value<bool>(),
                JTokenType.Integer => token.Value<int>() switch {
                    0 => false,
                    1 => true,
                    _ => false,
                },
                JTokenType.String => StringUtils.ParseBoolean(token.Value<string>()),
                _ => false,
            };
        }

        internal static bool GetBoolean(JToken? token, bool fallback) {
            return token?.Type switch {
                JTokenType.Boolean => token.Value<bool>(),
                JTokenType.Integer => token.Value<int>() switch {
                    0 => false,
                    1 => true,
                    _ => fallback,
                },
                JTokenType.String => StringUtils.ParseBoolean(token.Value<string>(), fallback),
                _ => fallback,
            };
        }

        internal static bool? GetBooleanOrNull(JToken? token) {
            return TryGetBoolean(token, out bool? result) ? result : null;
        }

        internal static bool TryGetBoolean(JToken? token, out bool result) {

            if (TryGetBoolean(token, out bool? temp)) {
                result = temp.Value;
                return true;
            }

            result = default;
            return false;

        }

        internal static bool TryGetBoolean(JToken? token, [NotNullWhen(true)] out bool? result) {

            switch (token?.Type) {

                case JTokenType.Boolean:
                    result = token.Value<bool>();
                    return true;

                case JTokenType.Integer:

                    switch (token.Value<int>()) {

                        case 0:
                            result = false;
                            return true;

                        case 1:
                            result = true;
                            return true;

                        default:
                            result = false;
                            return false;

                    }

                case JTokenType.String:
                    return StringUtils.TryParseBoolean(token.Value<string>(), out result);

                default:
                    result = false;
                    return false;

            }

        }

    }

}