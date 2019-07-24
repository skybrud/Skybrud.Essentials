using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts a timestamp (eg. <see cref="DateTime"/> or <see cref="DateTimeOffset"/>) to <see cref="Format"/>.
    /// </summary>
    public class TimeConverter : JsonConverter {

        /// <summary>
        /// The format to be used when serializing to JSON. Default is <see cref="TimeFormat.Iso8601"/>.
        /// </summary>
        public TimeFormat Format { get; protected set; }

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public TimeConverter() {
            Format = TimeFormat.Iso8601;
        }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public TimeConverter(TimeFormat format) {
            Format = format;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            if (value == null) {
                writer.WriteNull();
                return;
            }
            
            switch (value) {

                case DateTime dt:
                    writer.WriteValue(TimeUtils.ToFormat(dt, Format));
                    break;

                case DateTimeOffset dto:
                    writer.WriteValue(TimeUtils.ToFormat(dto, Format));
                    break;

                case EssentialsDateTime edt:
                    writer.WriteValue(TimeUtils.ToFormat(edt.DateTime, Format));
                    break;

                case EssentialsTime et:
                    writer.WriteValue(TimeUtils.ToFormat(et.DateTimeOffset, Format));
                    break;

                case EssentialsPartialDate epd:
                    writer.WriteValue(TimeUtils.ToFormat(epd, Format));
                    break;

                case EssentialsDate date:
                    writer.WriteValue(TimeUtils.ToFormat(date, Format));
                    break;

                default:
                    throw new ArgumentException("Unknown type " + value.GetType(), nameof(value));

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

            string type;

            if (objectType.Name == "Nullable`1") {

                // Just return NULL
                if (reader.TokenType == JsonToken.Null) return null;

                // Get the name of the generic type
                type = objectType.GenericTypeArguments[0].FullName;

            } else {

                // Get the name of the type
                type = objectType.FullName;

            }

            switch (type) {

                case "System.DateTime":
                    return ParseDateTime(reader);

                case "System.DateTimeOffset":
                    return ParseDateTimeOffset(reader);

                case "Skybrud.Essentials.Time.EssentialsDateTime":
                    return ParseEssentialsDateTime(reader);

                case "Skybrud.Essentials.Time.EssentialsTime":
                    return ParseEssentialsTime(reader);

                case "Skybrud.Essentials.Time.EssentialsDate":
                    return ParseEssentialsDate(reader);

                default:
                    throw new JsonSerializationException("Unsupported type " + objectType.FullName);

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset) || objectType == typeof(EssentialsDateTime) || objectType == typeof(EssentialsTime) || objectType == typeof(EssentialsDate);
        }

        private DateTime ParseDateTime(JsonReader reader) {

            switch (reader.TokenType) {

                // Return the default value of DateTime of the JSON value is NULL
                case JsonToken.Null:
                    return default(DateTime);

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Integer:
                    return TimeUtils.GetDateTimeFromUnixTime((long) reader.Value);

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Float:
                    return TimeUtils.GetDateTimeFromUnixTime((double) reader.Value);

                // Is the value already a date? JSON.net may automatically detect and parse some date formats
                case JsonToken.Date:

                    switch (reader.Value) {

                        case DateTime dt:
                            return dt;

                        case DateTimeOffset dto:
                            return dto.DateTime;

                        default:
                            throw new JsonSerializationException("Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value.GetType());

                    }

                case JsonToken.String:

                    // Get the value as a string
                    string value = (string) reader.Value;

                    // Parse the string using the format of the converter
                    switch (Format) {

                        case TimeFormat.Iso8601:
                            return TimeUtils.Iso8601ToDateTime(value);

                        case TimeFormat.Rfc822:
                            return TimeUtils.Rfc822ToDateTime(value);

                        case TimeFormat.Rfc2822:
                            return TimeUtils.Rfc822ToDateTime(value);

                        case TimeFormat.UnixTime:
                            return TimeUtils.GetDateTimeFromUnixTime(value);

                        default:
                            throw new JsonSerializationException("Unsupported format " + Format);

                    }

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        private DateTimeOffset ParseDateTimeOffset(JsonReader reader) {

            switch (reader.TokenType) {

                // Return the default value of DateTimeOffset of the JSON value is NULL
                case JsonToken.Null:
                    return default(DateTimeOffset);

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Integer:
                    return TimeUtils.GetDateTimeOffsetFromUnixTime((long) reader.Value);

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Float:
                    return TimeUtils.GetDateTimeOffsetFromUnixTime((double) reader.Value);

                // Is the value already a date? JSON.net may automatically detect and parse some date formats
                case JsonToken.Date:

                    switch (reader.Value) {

                        case DateTime dt:
                            return dt;

                        case DateTimeOffset dto:
                            return dto;

                        default:
                            throw new JsonSerializationException("Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value.GetType());

                    }

                case JsonToken.String:

                    // Get the value as a string
                    string value = (string) reader.Value;

                    // Parse the string using the format of the converter
                    switch (Format) {

                        case TimeFormat.Iso8601:
                            return TimeUtils.Iso8601ToDateTimeOffset(value);

                        case TimeFormat.Rfc822:
                            return TimeUtils.Rfc822ToDateTimeOffset(value);

                        case TimeFormat.Rfc2822:
                            return TimeUtils.Rfc822ToDateTimeOffset(value);

                        case TimeFormat.UnixTime:
                            return TimeUtils.GetDateTimeOffsetFromUnixTime(value);

                        default:
                            throw new JsonSerializationException("Unsupported format " + Format);

                    }

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        private EssentialsDate ParseEssentialsDate(JsonReader reader) {

            switch (reader.TokenType) {

                // Return the default value if the JSON value is NULL
                case JsonToken.Null:
                    return default;

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Integer:
                    return new EssentialsDate(TimeUtils.GetDateTimeFromUnixTime((long) reader.Value));

                // If the token type is an integer, we assume UNIX time regardles of the format of the converter
                case JsonToken.Float:
                    return new EssentialsDate(TimeUtils.GetDateTimeFromUnixTime((double) reader.Value));

                // Is the value already a date? JSON.net may automatically detect and parse some date formats
                case JsonToken.Date:

                    switch (reader.Value) {

                        case DateTime dt:
                            return new EssentialsDate(dt);

                        case DateTimeOffset dto:
                            return new EssentialsDate(dto);

                        default:
                            throw new JsonSerializationException("Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value.GetType());

                    }

                case JsonToken.String:

                    // Get the value as a string
                    string value = (string) reader.Value;

                    // Parse the string using the format of the converter
                    switch (Format) {

                        case TimeFormat.Iso8601:
                            return EssentialsDate.Parse(value);

                        default:
                            throw new JsonSerializationException("Unsupported format " + Format);

                    }

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        private EssentialsDateTime ParseEssentialsDateTime(JsonReader reader) {
            return reader.TokenType == JsonToken.Null ? null : new EssentialsDateTime(ParseDateTime(reader));
        }

        private EssentialsTime ParseEssentialsTime(JsonReader reader) {
            return reader.TokenType == JsonToken.Null ? null : new EssentialsTime(ParseDateTimeOffset(reader));
        }

    }

}