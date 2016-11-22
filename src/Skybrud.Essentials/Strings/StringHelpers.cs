using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Static class with various string related helper methods.
    /// </summary>
    public static class StringHelpers {

        /// <summary>
        /// Parses the specified <code>str</code> into an instance of <see cref="System.Boolean"/>. The string is
        /// considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns <code>true</code> if <code>str</code> matches either <code>true</code>, <code>1</code>
        /// or <code>t</code> (case insensitive).</returns>
        public static bool ParseBoolean(string str) {
            str = (str ?? "").ToLower();
            return str == "true" || str == "1" || str == "t";
        }

        /// <summary>
        /// Parses the specified <code>value</code> into an instance of <see cref="System.Boolean"/>. The value is
        /// considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns>Returns <code>true</code> if <code>value</code> matches either <code>true</code>, <code>1</code>
        /// or <code>t</code> (case insensitive).</returns>
        public static bool ParseBoolean(object value) {
            return ParseBoolean(value + "");
        }

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>Returns an array of <see cref="Int32"/>.</returns>
        public static int[] CsvToInt(string str) {
            return (
                from piece in (str ?? "").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select Int32.Parse(piece)
            ).ToArray();
        }

        /// <summary>
        /// Converts the specified <code>str</code> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        public static string ToCamelCase(string str) {

            // Convert the string to lowercase initially for better results (eg. if the string is already camel cased)
            str = ToUnderscore(str);

            // Split the string by space or underscore
            string[] pieces = str.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

            // Join the pieces again and uppercase the first character of each piece but the first
            return String.Join("", pieces.Select((t, i) => i == 0 ? t : FirstCharToUpper(t)));

        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the camel cased string.</returns>
        public static string ToCamelCase(Enum value) {
            return ToCamelCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified <code>str</code> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        public static string ToPascalCase(string str) {

            // Convert the string to lowercase initially for better results (eg. if the string is already camel cased)
            str = ToUnderscore(str);

            // Split the string by space or underscore
            string[] pieces = str.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);

            // Join the pieces again and uppercase the first character of each piece
            return String.Join("", from piece in pieces select FirstCharToUpper(piece));

        }

        /// <summary>
        /// Converts the name of the specified enum <code>value</code> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the Pascal cased string.</returns>
        public static string ToPascalCase(Enum value) {
            return ToPascalCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified <code>str</code> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string ToUnderscore(string str) {
            return Regex.Replace(str ?? "", @"(\p{Ll})(\p{Lu})", "$1_$2").Replace(" ", "_").Replace("__", "_").ToLower();
        }

        /// <summary>
        /// Converts the specified enum value to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string ToUnderscore(Enum value) {
            return ToUnderscore(value.ToString());
        }

        /// <summary>
        /// Uppercases the first character of a the specified <code>str</code>. If <code>str</code> is either
        /// <code>null</code> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        public static string FirstCharToUpper(string str) {
            return String.IsNullOrEmpty(str) ? "" : String.Concat(str.Substring(0, 1).ToUpper(), str.Substring(1));
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>Returns the encoded string.</returns>
        public static string UrlEncode(string str) {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>Returns the decoded string.</returns>
        public static string UrlDecode(string str) {
            return HttpUtility.UrlDecode(str);
        }

    }

}