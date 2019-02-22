using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts an instance of <see cref="EssentialsDateTime"/> to and from the ISO 8601 date format (e.g. <c>2008-04-12T12:53Z</c>).
    /// </summary>
    [Obsolete("Use TimeConverter instead.")]
    public class EssentialsDateTimeConverter : IsoDateTimeConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is EssentialsDateTime)) return;
            EssentialsDateTime dt = (EssentialsDateTime) value;
            base.WriteJson(writer, dt.DateTime, serializer);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
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
                    if (reader.Value is DateTime) return new EssentialsDateTime((DateTime) reader.Value);
                    throw new JsonSerializationException("Value doesn't match an instance of DateTime: " + reader.Value.GetType());

                case JsonToken.String:
                    if (String.IsNullOrWhiteSpace(reader.Value + "")) return null;
                    if (!String.IsNullOrEmpty(DateTimeFormat)) {
                        return (EssentialsDateTime) DateTime.ParseExact(reader.Value + "", DateTimeFormat, Culture, DateTimeStyles);
                    }
                    return (EssentialsDateTime) DateTime.Parse(reader.Value + "", Culture, DateTimeStyles);

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(EssentialsDateTime);
        }

    }

}