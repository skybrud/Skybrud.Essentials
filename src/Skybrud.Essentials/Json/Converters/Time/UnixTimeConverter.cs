using System;
using System.Globalization;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.UnixTime;

#pragma warning disable CS0618

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts an instance of either <see cref="EssentialsDateTime"/> or <see cref="DateTime"/> to and from a Unix timestamp.
    /// </summary>
    public class UnixTimeConverter : JsonConverter {

        #region Properties

        /// <summary>
        /// The format to be used when serializing to JSON. Default is <see cref="UnixTimeFormat.Seconds"/>.
        /// </summary>
        public UnixTimeFormat Format { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public UnixTimeConverter() {
            Format = UnixTimeFormat.Seconds;
        }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public UnixTimeConverter(UnixTimeFormat format) {
            Format = format;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

            if (value == null) {
                writer.WriteNull();
                return;
            }

            switch (value) {

                case DateTime dt:
                    writer.WriteValue(UnixTimeUtils.ToInt64(dt, Format));
                    break;

                case DateTimeOffset dto:
                    writer.WriteValue(UnixTimeUtils.ToInt64(dto, Format));
                    break;

                case EssentialsDateTime edt:
                    writer.WriteValue(UnixTimeUtils.ToInt64(edt.DateTime, Format));
                    break;

                case EssentialsTime et:
                    writer.WriteValue(UnixTimeUtils.ToInt64(et, Format));
                    break;

                default:
                    throw new ArgumentException($"Unknown type {value.GetType()}", nameof(value));

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

            string? type;

            if (objectType.Name == "Nullable`1") {

                // Just return NULL
                if (reader.TokenType == JsonToken.Null) return null;

                // Get the name of the generic type
                type = objectType.GenericTypeArguments[0].FullName;

            } else {

                // Get the name of the type
                type = objectType.FullName;

            }

            // Read/parse the timestamp from the reader
            double timestamp = reader.TokenType switch {
                JsonToken.Integer => (long) reader.Value,
                JsonToken.Float => (double) reader.Value,
                JsonToken.String => double.Parse((string) reader.Value, CultureInfo.InvariantCulture),
                _ => throw new JsonSerializationException($"Unsupported value {reader.Value}"),
            };

            // Convert to the correct type based on the value type of the property
            return type switch {
                "System.DateTime" => UnixTimeUtils.ToDateTime(timestamp, Format),
                "System.DateTimeOffset" => UnixTimeUtils.ToDateTimeOffset(timestamp, Format),
                "Skybrud.Essentials.Time.EssentialsDateTime" => new EssentialsDateTime(UnixTimeUtils.ToDateTime(timestamp, Format)),
                "Skybrud.Essentials.Time.EssentialsTime" => new EssentialsTime(UnixTimeUtils.ToDateTimeOffset(timestamp, Format)),
                "Skybrud.Essentials.Time.EssentialsDate" => new EssentialsDate(UnixTimeUtils.ToDateTimeOffset(timestamp, Format)),
                _ => throw new JsonSerializationException($"Unsupported type {objectType.FullName}")
            };

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset) || objectType == typeof(EssentialsDateTime) || objectType == typeof(EssentialsTime) || objectType == typeof(EssentialsDate);
        }

        #endregion

    }

}