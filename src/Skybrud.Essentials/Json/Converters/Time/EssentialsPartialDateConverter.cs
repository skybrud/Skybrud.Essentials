using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// JSON converter for serializing and deserializing instances of <see cref="EssentialsPartialDate"/>.
    /// </summary>
    public class EssentialsPartialDateConverter : JsonConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is EssentialsPartialDate)) return;
            EssentialsPartialDate date = (EssentialsPartialDate) value;
            writer.WriteValue(date.ToString());
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {

            if (reader.TokenType == JsonToken.Null) return null;

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return null;

                case JsonToken.Date:
                    if (reader.Value is DateTime) return new EssentialsPartialDate((DateTime)reader.Value);
                    throw new JsonSerializationException("Value doesn't match an instance of DateTime: " + reader.Value.GetType());

                case JsonToken.String:
                    if (String.IsNullOrWhiteSpace(reader.Value + "")) return null;
                    return EssentialsPartialDate.Parse(reader.Value + "");

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><code>true</code> if this instance can convert the specified object type; otherwise, <code>false</code>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(EssentialsPartialDate);
        }

    }

}