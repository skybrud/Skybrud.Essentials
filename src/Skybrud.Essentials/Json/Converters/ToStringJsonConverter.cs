using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Json.Converters {

    /// <summary>
    /// JSON converter for serializing objects into their <see cref="object.ToString"/> equivalent.
    /// </summary>
    [Obsolete("Use the 'StringJsonConverter' class instead.")]
    public class ToStringJsonConverter : JsonConverter {

        /// <inheritdoc />
        public override bool CanRead => false;

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) {
            return true;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value == null) {
                writer.WriteNull();
            } else {
                writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0}", value));
            }
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

    }

}