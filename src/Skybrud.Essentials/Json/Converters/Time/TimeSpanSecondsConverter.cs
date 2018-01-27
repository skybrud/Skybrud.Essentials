using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// JSON converter for seriqalizing and deserializating between instances of <see cref="TimeSpan"/> and the total
    /// amount of seconds represented by the time span.
    /// </summary>
    public class TimeSpanSecondsConverter : JsonConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value is TimeSpan) {
                TimeSpan ts = (TimeSpan) value;
                writer.WriteRawValue(ts.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            }
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

            if (objectType != typeof(TimeSpan)) throw new JsonSerializationException("Object type " + objectType + " is not supported");

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return default(TimeSpan);

                case JsonToken.Integer:
                case JsonToken.Float:
                    return TimeSpan.FromSeconds((double) Convert.ChangeType(reader.Value, typeof(double), CultureInfo.InvariantCulture));

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><code>true</code> if this instance can convert the specified object type; otherwise,
        /// <code>false</code>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(TimeSpan);
        }

    }

}