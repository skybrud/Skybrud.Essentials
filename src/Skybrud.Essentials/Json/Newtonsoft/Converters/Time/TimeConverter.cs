using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.Rfc2822;
using Skybrud.Essentials.Time.Rfc822;
using Skybrud.Essentials.Time.UnixTime;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters.Time;

/// <summary>
/// Converts a timestamp (e.g. <see cref="DateTime"/> or <see cref="DateTimeOffset"/>) to <see cref="Format"/>.
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
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

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

        return type switch {
            "System.DateTime" => ParseDateTime(reader),
            "System.DateTimeOffset" => ParseDateTimeOffset(reader),
            "Skybrud.Essentials.Time.EssentialsTime" => ParseEssentialsTime(reader),
            "Skybrud.Essentials.Time.EssentialsDate" => ParseEssentialsDate(reader),
            _ => throw new JsonSerializationException($"Unsupported type: {objectType}")
        };

    }

    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns><see langword="true"/> if this instance can convert the specified object type; otherwise <see langword="false"/>.</returns>
    public override bool CanConvert(Type objectType) {
        return objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset) || objectType == typeof(EssentialsTime) || objectType == typeof(EssentialsDate);
    }

    private DateTime ParseDateTime(JsonReader reader) {

        switch (reader.TokenType) {

            // Return the default value of DateTime of the JSON value is NULL
            case JsonToken.Null:
                return default;

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Integer:
                return UnixTimeUtils.FromSeconds((long) reader.Value!).DateTime;

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Float:
                return UnixTimeUtils.FromSeconds((double) reader.Value!).DateTime;

            // Is the value already a date? JSON.net may automatically detect and parse some date formats
            case JsonToken.Date:

                return reader.Value switch {
                    DateTime dt => dt,
                    DateTimeOffset dto => dto.DateTime,
                    _ => throw new JsonSerializationException(
                        "Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value!.GetType())
                };

            case JsonToken.String:

                // Get the value as a string
                string value = (string) reader.Value!;

                // Parse the string using the format of the converter
                return Format switch {
                    TimeFormat.Iso8601 => Iso8601Utils.Parse(value).DateTime,
                    TimeFormat.Rfc822 => Rfc822Utils.Parse(value).DateTime,
                    TimeFormat.Rfc2822 => Rfc2822Utils.Parse(value).DateTime,
                    TimeFormat.UnixTime => UnixTimeUtils.FromSeconds(value).DateTime,
                    _ => throw new JsonSerializationException("Unsupported format " + Format)
                };

            default:
                throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

        }

    }

    private DateTimeOffset ParseDateTimeOffset(JsonReader reader) {

        switch (reader.TokenType) {

            // Return the default value of DateTimeOffset of the JSON value is NULL
            case JsonToken.Null:
                return default;

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Integer:
                return UnixTimeUtils.FromSeconds((long) reader.Value!);

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Float:
                return UnixTimeUtils.FromSeconds((double) reader.Value!);

            // Is the value already a date? JSON.net may automatically detect and parse some date formats
            case JsonToken.Date:

                return reader.Value switch {
                    DateTime dt => dt,
                    DateTimeOffset dto => dto,
                    _ => throw new JsonSerializationException("Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value!.GetType())
                };

            case JsonToken.String:

                // Get the value as a string
                string value = (string) reader.Value!;

                // Parse the string using the format of the converter
                return Format switch {
                    TimeFormat.Iso8601 => Iso8601Utils.Parse(value),
                    TimeFormat.Rfc822 => Rfc822Utils.Parse(value),
                    TimeFormat.Rfc2822 => Rfc2822Utils.Parse(value),
                    TimeFormat.UnixTime => UnixTimeUtils.FromSeconds(value),
                    _ => throw new JsonSerializationException("Unsupported format " + Format)
                };

            default:
                throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

        }

    }

    private EssentialsDate? ParseEssentialsDate(JsonReader reader) {

        switch (reader.TokenType) {

            // Return the default value if the JSON value is NULL
            case JsonToken.Null:
                return null;

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Integer:
                return new EssentialsDate(UnixTimeUtils.FromSeconds((long) reader.Value!));

            // If the token type is an integer, we assume UNIX time regardless of the format of the converter
            case JsonToken.Float:
                return new EssentialsDate(UnixTimeUtils.FromSeconds((double) reader.Value!));

            // Is the value already a date? JSON.net may automatically detect and parse some date formats
            case JsonToken.Date:
                return reader.Value switch {
                    DateTime dt => new EssentialsDate(dt),
                    DateTimeOffset dto => new EssentialsDate(dto),
                    _ => throw new JsonSerializationException(
                        "Value doesn't match an instance of DateTime or DateTimeOffset: " + reader.Value!.GetType())
                };

            case JsonToken.String:

                // Get the value as a string
                string value = (string) reader.Value!;

                // Parse the string using the format of the converter
                return Format switch {
                    TimeFormat.Iso8601 => EssentialsDate.Parse(value),
                    _ => throw new JsonSerializationException("Unsupported format " + Format)
                };

            default:
                throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

        }

    }

    private EssentialsTime? ParseEssentialsTime(JsonReader reader) {
        return reader.TokenType == JsonToken.Null ? null : new EssentialsTime(ParseDateTimeOffset(reader));
    }

}