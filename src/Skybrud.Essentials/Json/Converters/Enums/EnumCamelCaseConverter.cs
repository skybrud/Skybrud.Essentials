using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a camel cased string.
    /// </summary>
    public class EnumCamelCaseConverter : EnumStringConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public EnumCamelCaseConverter() : base(TextCasing.CamelCase) { }

    }

}