using System;
using System.Globalization;
using Newtonsoft.Json;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.Xml;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters.Time {

    /// <summary>
    /// JSON converter for serializing and deserializing instances of <see cref="TimeSpan"/> according to <see cref="Format"/>.
    /// </summary>
    public class TimeSpanConverter : JsonConverter {

        /// <summary>
        /// The format to be used when serializing to JSON. Default is <see cref="T:Skybrud.Essentials.Time.TimeSpanFormat.Seconds"/>.
        /// </summary>
        public TimeSpanFormat Format { get; }

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public TimeSpanConverter() {
            Format = TimeSpanFormat.Seconds;
        }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public TimeSpanConverter(TimeSpanFormat format) {
            Format = format;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

            switch (value) {

                case null:
                    writer.WriteNull();
                    return;

                case TimeSpan ts:

                    switch (Format) {

                        case TimeSpanFormat.Seconds:
                            writer.WriteRawValue(ts.TotalSeconds.ToString(CultureInfo.InvariantCulture));
                            return;

                        case TimeSpanFormat.Milliseconds:
                            writer.WriteRawValue(ts.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
                            return;

                        case TimeSpanFormat.Iso8601:
                            writer.WriteRawValue(XmlSchemaUtils.ToString(ts));
                            return;

                        default:
                            throw new JsonSerializationException($"Unsupported format: {Format}");

                    }

                default:
                    throw new JsonSerializationException($"Unsupported type: {value.GetType()}");

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
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {

            if (objectType != typeof(TimeSpan) && objectType != typeof(TimeSpan?)) throw new JsonSerializationException($"Object type {objectType} is not supported");

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return objectType == typeof(TimeSpan?) ? null : default(TimeSpan);

                case JsonToken.Integer:
                case JsonToken.Float:
                    return ReadFromNumber(reader, objectType);

                case JsonToken.String:
                    return ReadFromString(reader, objectType);

                default:
                    throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }

        private object? ReadFromNumber(JsonReader reader, Type objectType) {

            // Get the value from the reader
            double value;
            switch (reader.Value) {
                case long l:
                    value = l;
                    break;
                case double d:
                    value = d;
                    break;
                default:
                    return objectType == typeof(TimeSpan?) ? null : default(TimeSpan);
            }

            // Handle the various formats
            return Format switch {
                TimeSpanFormat.Seconds => TimeSpan.FromSeconds(value),
                TimeSpanFormat.Milliseconds => TimeSpan.FromMilliseconds(value),
                TimeSpanFormat.Iso8601 => throw new JsonSerializationException("Value is not in a known format."),
                _ => throw new JsonSerializationException($"Unsupported format: {Format}")
            };

        }

        private object? ReadFromString(JsonReader reader, Type objectType) {

            // Get the value from the reader
            string value = (string) reader.Value;

            // If null, empty or white space we return the default value
            if (string.IsNullOrWhiteSpace(value)) return objectType == typeof(TimeSpan?) ? null : default(TimeSpan);

            // If the string value starts with a P, we assume it's an ISO 8601 duration string
            if (value[0] is 'P') return Iso8601Utils.ParseDuration(value);

            // Can we parse the value to a double?
            if (!StringUtils.TryParseDouble(value, out double result)) throw new JsonSerializationException("Value is not in a known format.");

            // Handle the various formats
            return Format switch {
                TimeSpanFormat.Seconds => TimeSpan.FromSeconds(result),
                TimeSpanFormat.Milliseconds => TimeSpan.FromMilliseconds(result),
                TimeSpanFormat.Iso8601 => XmlSchemaUtils.ParseDuration(value),
                _ => throw new JsonSerializationException($"Unsupported format: {Format}")
            };

        }

    }

}