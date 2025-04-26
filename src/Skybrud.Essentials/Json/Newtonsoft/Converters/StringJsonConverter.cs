using System;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;
using Skybrud.Essentials.Enums;
using System.Collections.Specialized;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters;

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
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

        switch (value) {

            case null:
                writer.WriteNull();
                break;

            case NameValueCollection nvc:
                writer.WriteValue(StringUtils.ToUrlEncodedString(nvc));
                break;

            default:
                writer.WriteValue(string.Format(CultureInfo.InvariantCulture, "{0}", value));
                break;

        }

    }

    /// <inheritdoc />
    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {

        if (objectType == typeof(NameValueCollection)) {
            string? temp = reader.Value?.ToString();
            return temp is null ? [] : System.Web.HttpUtility.ParseQueryString(temp);
        }

        if (objectType.GetTypeInfo().IsEnum) {
            string? temp = reader.Value?.ToString();
            return EnumUtils.ParseEnum(temp ?? string.Empty, objectType);
        }

        throw new Exception($"Unsupported type: {objectType}");

    }

}