using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a Pascal cased string.
    /// </summary>
    public class EnumPascalCaseConverter : EnumStringConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public EnumPascalCaseConverter() : base(TextCasing.PascalCase) { }

    }

}