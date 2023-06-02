using System;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using Skybrud.Essentials.Enums;

#if I_CAN_HAS_NAME_VALUE_COLLECTION
using System.Collections.Specialized;
using Skybrud.Essentials.Strings;
#endif

namespace Skybrud.Essentials.Json.Newtonsoft.Converters {

    /// <summary>
    /// JSON converter for serializing objects into their <see cref="object.ToString"/> equivalent.
    /// </summary>
    public class StringJsonConverter : JsonConverter {

        /// <inheritdoc />
        public override bool CanRead => true;

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) {
            return true;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

            switch (value) {

                case null:
                    writer.WriteNull();
                    break;

#if I_CAN_HAS_NAME_VALUE_COLLECTION
                case NameValueCollection nvc:
                    writer.WriteValue(StringUtils.ToUrlEncodedString(nvc));
                    break;
#endif

                default:
                    writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0}", value));
                    break;

            }

        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {

#if I_CAN_HAS_NAME_VALUE_COLLECTION
            if (objectType == typeof(NameValueCollection)) {
                string? temp = reader.Value?.ToString();
                return temp is null ? new NameValueCollection() : System.Web.HttpUtility.ParseQueryString(temp);
            }
#endif

            if (objectType.GetTypeInfo().IsEnum) {
                string? temp = reader.Value?.ToString();
                return EnumUtils.ParseEnum(temp ?? string.Empty, objectType);
            }

            throw new Exception($"Unsupported type: {objectType}");

        }

    }

}