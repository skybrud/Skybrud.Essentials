using System;
using System.Globalization;
using Newtonsoft.Json;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// Abstract class serving as a base converter for other enum converters in Skybrud.Essentials.
    /// </summary>
    public abstract class EnumBaseCaseConverter : JsonConverter {

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

            writer.WriteValue(StringHelper.ToPascalCase(value + ""));

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

            // Trow an exception if the token type is NULL
            if (reader.TokenType == JsonToken.Null) {
                throw new JsonSerializationException(String.Format(CultureInfo.InvariantCulture, "Cannot convert null value to {0}.", objectType));
            }

            // Try to parse the sepcified enum value
            try {
                if (reader.TokenType == JsonToken.String) {
                    return EnumUtils.ParseEnum(reader.Value.ToString(), objectType);
                }
            } catch (Exception ex) {
                throw new JsonSerializationException(String.Format(CultureInfo.InvariantCulture, "Error converting value {0} to type '{1}'.", reader.Value, objectType), ex);
            }


            // Trow an exception if we didn't find a match
            throw new JsonSerializationException(String.Format(CultureInfo.InvariantCulture, "Unexpected token {0} when parsing enum.", reader.TokenType));

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><code>true</code> if this instance can convert the specified object type; otherwise
        /// <code>false</code>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Enum);
        }

    }

}