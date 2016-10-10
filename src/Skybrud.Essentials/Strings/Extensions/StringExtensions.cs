using System;

namespace Skybrud.Essentials.Strings.Extensions {
    
    public static class StringExtensions {

        /// <summary>
        /// Converts the specified <code>str</code> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        public static string ToCamelCase(this string str) {
            return StringHelpers.ToCamelCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        public static string ToCamelCase(Enum value) {
            return StringHelpers.ToCamelCase(value);
        }

        /// <summary>
        /// Converts the specified <code>str</code> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        public static string ToPascalCase(this string str) {
            return StringHelpers.ToPascalCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        public static string ToPascalCase(Enum value) {
            return StringHelpers.ToPascalCase(value);
        }

        /// <summary>
        /// Converts the specified <code>str</code> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string ToUnderscore(this string str) {
            return StringHelpers.ToUnderscore(str);
        }

        /// <summary>
        /// Converts the specified enum value to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string ToUnderscore(this Enum value) {
            return StringHelpers.ToUnderscore(value);
        }

        /// <summary>
        /// Uppercases the first character of a the specified <code>str</code>. If <code>str</code> is either
        /// <code>null</code> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        public static string FirstCharToUpper(this string str) {
            return StringHelpers.FirstCharToUpper(str);
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>Returns the encoded string.</returns>
        public static string UrlEncode(this string str) {
            return StringHelpers.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>Returns the decoded string.</returns>
        public static string UrlDecode(this string str) {
            return StringHelpers.UrlDecode(str);
        }

    }

}