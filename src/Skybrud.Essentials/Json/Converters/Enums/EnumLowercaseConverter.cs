using System;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a lower case string.
    /// </summary>
    [Obsolete("Use EnumStringConverter instead.")]
    public class EnumLowerCaseConverter : EnumBaseCaseConverter {

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

            writer.WriteValue((value + "").ToLower());

        }

    }

}