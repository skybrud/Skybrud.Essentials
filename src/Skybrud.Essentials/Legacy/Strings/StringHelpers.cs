using System;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Utility class with various static helper methods for working with strings.
    /// </summary>
    [Obsolete("Use the StringHelper class instead.")]
    public static class StringHelpers {

        /// <summary>
        /// Parses the specified <code>str</code> into an instance of <see cref="System.Boolean"/>. The string is
        /// considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns <code>true</code> if <code>str</code> matches either <code>true</code>, <code>1</code>
        /// or <code>t</code> (case insensitive).</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static bool ParseBoolean(string str) {
            return StringUtils.ParseBoolean(str);
        }

        /// <summary>
        /// Parses the specified <code>value</code> into an instance of <see cref="System.Boolean"/>. The value is
        /// considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns>Returns <code>true</code> if <code>value</code> matches either <code>true</code>, <code>1</code>
        /// or <code>t</code> (case insensitive).</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static bool ParseBoolean(object value) {
            return StringUtils.ParseBoolean(value);
        }

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>Returns an array of <see cref="Int32"/>.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static int[] CsvToInt(string str) {
            return StringUtils.CsvToInt(str);
        }

        /// <summary>
        /// Converts the specified <code>str</code> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToCamelCase(string str) {
            return StringUtils.ToCamelCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToCamelCase(Enum value) {
            return StringUtils.ToCamelCase(value);
        }

        /// <summary>
        /// Converts the specified <code>str</code> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToPascalCase(string str) {
            return StringUtils.ToPascalCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToPascalCase(Enum value) {
            return StringUtils.ToPascalCase(value);
        }

        /// <summary>
        /// Converts the specified <code>str</code> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToUnderscore(string str) {
            return StringUtils.ToUnderscore(str);
        }

        /// <summary>
        /// Converts the specified enum value to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string ToUnderscore(Enum value) {
            return StringUtils.ToUnderscore(value);
        }

        /// <summary>
        /// Uppercases the first character of a the specified <code>str</code>. If <code>str</code> is either
        /// <code>null</code> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string FirstCharToUpper(string str) {
            return StringUtils.FirstCharToUpper(str);
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>Returns the encoded string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string UrlEncode(string str) {
            return StringUtils.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>Returns the decoded string.</returns>
        [Obsolete("Use the StringHelper class instead.")]
        public static string UrlDecode(string str) {
            return StringUtils.UrlDecode(str);
        }

    }

}