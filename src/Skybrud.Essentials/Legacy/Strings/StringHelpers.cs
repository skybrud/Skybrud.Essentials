using System;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Utility class with various static helper methods for working with strings.
    /// </summary>
    [Obsolete("Use the StringUtils class instead.")]
    public static class StringHelpers {

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="System.Boolean"/>. The string is
        /// considered <c>true</c> if it matches either <c>1</c>, <c>t</c> or <c>true</c> (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c> or <c>t</c> (case insensitive).</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static bool ParseBoolean(string str) {
            return StringUtils.ParseBoolean(str);
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="System.Boolean"/>. The value is
        /// considered <c>true</c> if it matches either <c>1</c>, <c>t</c> or <c>true</c> (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c> or <c>t</c> (case insensitive).</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static bool ParseBoolean(object value) {
            return StringUtils.ParseBoolean(value);
        }

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="Int32"/>.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static int[] CsvToInt(string str) {
            return StringUtils.CsvToInt(str);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToCamelCase(string str) {
            return StringUtils.ToCamelCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToCamelCase(Enum value) {
            return StringUtils.ToCamelCase(value);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToPascalCase(string str) {
            return StringUtils.ToPascalCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToPascalCase(Enum value) {
            return StringUtils.ToPascalCase(value);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToUnderscore(string str) {
            return StringUtils.ToUnderscore(str);
        }

        /// <summary>
        /// Converts the specified enum value to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string ToUnderscore(Enum value) {
            return StringUtils.ToUnderscore(value);
        }

        /// <summary>
        /// Uppercases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is either
        /// <c>null</c> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string FirstCharToUpper(string str) {
            return StringUtils.FirstCharToUpper(str);
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string UrlEncode(string str) {
            return StringUtils.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The decoded string.</returns>
        [Obsolete("Use the StringUtils class instead.")]
        public static string UrlDecode(string str) {
            return StringUtils.UrlDecode(str);
        }

    }

}