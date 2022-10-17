using Newtonsoft.Json;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a corresponding string value.
    /// </summary>
    public class EnumStringConverter : EnumBaseCaseConverter {

        /// <summary>
        /// The casing to be used when serializing to JSON. Default is <see cref="TextCasing.PascalCase"/>.
        /// </summary>
        public TextCasing Casing { get; }

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public EnumStringConverter() {
            Casing = TextCasing.PascalCase;
        }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="casing">The casing to be used when serializing to JSON.</param>
        public EnumStringConverter(TextCasing casing) {
            Casing = casing;
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

            writer.WriteValue(StringUtils.ToCasing(value.ToString(), Casing));

        }

    }

}