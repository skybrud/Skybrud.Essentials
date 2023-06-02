using System;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {

    /// <summary>
    /// JSON converter for serializing an enum value into a corresponding string value.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumStringConverter' converter instead.")]
    public class EnumStringConverter : Newtonsoft.Converters.Enums.EnumStringConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public EnumStringConverter() { }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="casing">The casing to be used when serializing to JSON.</param>
        public EnumStringConverter(TextCasing casing) : base(casing) { }

    }

}