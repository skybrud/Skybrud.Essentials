using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {
    
    /// <summary>
    /// Converts an instance of either <see cref="EssentialsDateTime"/> or <see cref="DateTime"/> to and from a Unix timestamp.
    /// </summary>
    public class UnixTimeConverter : JsonConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            if (value is EssentialsDateTime) {
                EssentialsDateTime dt = (EssentialsDateTime) value;
                writer.WriteValue(dt.UnixTimestamp);
            }

            if (value is DateTime) {
                DateTime dt = (DateTime) value;
                writer.WriteValue(TimeUtils.GetUnixTimeFromDateTime(dt));
            }

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

            double timestamp;

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return objectType == typeof(DateTime) ? (object) default(DateTime) : null;

                case JsonToken.Integer:
                    timestamp = (long) reader.Value; break;

                case JsonToken.Float:
                    timestamp = (double) reader.Value; break;

                case JsonToken.String:
                    if (!Double.TryParse(reader.Value + "", out timestamp)) throw new JsonSerializationException("String value doesn't match a Unix timestamp: " + reader.Value); break;

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

            if (objectType == typeof(EssentialsDateTime)) return EssentialsDateTime.FromUnixTimestamp(timestamp);
            if (objectType == typeof(DateTime)) return TimeUtils.GetDateTimeFromUnixTime(timestamp);
            throw new JsonSerializationException("Object type " + objectType + " is not supported");

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><code>true</code> if this instance can convert the specified object type; otherwise, <code>false</code>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(EssentialsDateTime) || objectType == typeof(DateTime);
        }

    }

}