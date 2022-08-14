using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a lower case string.
    /// </summary>
    public class EnumLowerCaseConverter : EnumStringConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public EnumLowerCaseConverter() : base(TextCasing.LowerCase) { }

    }

}