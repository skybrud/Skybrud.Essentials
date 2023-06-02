using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Skybrud.Essentials.Enums.EnumUtils;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters.Enums {

    /// <summary>
    /// JSON converter for deserializing a string representation of multiple enum values.
    /// </summary>
    public class EnumArrayJsonConverter : JsonConverter {

        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {

            // Validate the input type
            Type? itemType = objectType.GetElementType();
            if (objectType.IsArray == false || itemType == null) throw new Exception($"Property type {objectType} is not an array.");

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return null;

                case JsonToken.String:
                    return ParseEnumArray(reader.Value.ToString(), itemType);

                case JsonToken.StartArray:
                    return ParseEnumArray(JArray.Load(reader).ToObject<string[]>(), itemType);

                default:
                    throw new JsonSerializationException(string.Format(CultureInfo.InvariantCulture, "Unexpected token {0} when parsing enum.", reader.TokenType));

            }

        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) {
            return false;
        }

    }

}