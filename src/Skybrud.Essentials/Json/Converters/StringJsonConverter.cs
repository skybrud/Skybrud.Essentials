using System;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters {

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
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            switch (value) {

                case null:
                    writer.WriteNull();
                    break;

#if I_CAN_HAS_NAME_VALUE_COLLECTION
                case System.Collections.Specialized.NameValueCollection nvc:
                    writer.WriteValue(StringUtils.ToUrlEncodedString(nvc));
                    break;
#endif

                default:
                    writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0}", value));
                    break;

            }

        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {

#if I_CAN_HAS_NAME_VALUE_COLLECTION
            if (objectType == typeof(System.Collections.Specialized.NameValueCollection)) {
                return System.Web.HttpUtility.ParseQueryString(reader.Value.ToString());
            }
#endif

            if (objectType.GetTypeInfo().IsEnum) {
                return EnumUtils.ParseEnum(reader.Value.ToString(), objectType);
            }

            throw new Exception($"Unsupported type: {objectType}");

        }

    }

}