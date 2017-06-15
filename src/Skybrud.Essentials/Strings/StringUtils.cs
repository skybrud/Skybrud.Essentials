using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Utility class with various static helper methods for working with strings.
    /// </summary>
    public static class StringUtils {

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="System.Boolean"/>. The string is
        /// considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches either <code>true</code>, <code>1</code> or
        /// <code>t</code> (case insensitive).</returns>
        public static bool ParseBoolean(string str) {
            str = (str ?? "").ToLower();
            return str == "true" || str == "1" || str == "t";
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="System.Boolean"/>. The value
        /// is considered <code>true</code> if it matches either <code>1</code>, <code>t</code> or <code>true</code>
        /// (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns><code>true</code> if <paramref name="value"/> matches either <code>true</code>, <code>1</code> or
        /// <code>t</code> (case insensitive).</returns>
        public static bool ParseBoolean(object value) {
            return ParseBoolean(value + "");
        }

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="Int32"/>.</returns>
        public static int[] CsvToInt(string str) {
            return (
                from piece in (str ?? "").Split(new[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select Int32.Parse(piece)
            ).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
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
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
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
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(Enum value) {
            return ToPascalCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(string str) {

            // Replace invalid characters
            str = Regex.Replace(str ?? "", "[\\W_]+", " ").Trim();

            // Replace multiple whitespaces
            str = Regex.Replace(str, "[ ]{2,}", " ");

            // Convert to lowercase (with uppercase letters prefixed with underscore)
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1_$2").Replace(" ", "_").Replace("__", "_").ToLower();

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
        /// Uppercases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is
        /// either <code>null</code> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        public static string FirstCharToUpper(string str) {
            return String.IsNullOrEmpty(str) ? "" : String.Concat(str.Substring(0, 1).ToUpper(), str.Substring(1));
        }

        /// <summary>
        /// URL encodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The URL encoded string.</returns>
        public static string UrlEncode(string str) {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The URL decoded string.</returns>
        public static string UrlDecode(string str) {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// Counts number of words in the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <returns>An integer with the number of words found.</returns>
        public static int WordCount(string str) {

            // See: http://stackoverflow.com/a/8784654

            // Trim the text a bit
            str = str.Trim();
            
            int count = 0, index = 0;

            while (index < str.Length) {
                
                // Check if current char is part of a word
                while (index < str.Length && !char.IsWhiteSpace(str[index])) index++;

                // Increment the counter
                count++;

                // Skip whitespace until next word
                while (index < str.Length && char.IsWhiteSpace(str[index])) index++;
            
            }

            return count;
        
        }

        /// <summary>
        /// Highlights specified <paramref name="keywords"/> in the <paramref name="input"/> string with the specified
        /// <paramref name="className"/> by using a <code>&lt;span&gt;</code> element.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="className">The class name.</param>
        /// <param name="keywords">The keywords to highlight.</param>
        /// <returns>The input string with highlighted keywords.</returns>
        public static string HighlightKeywords(string input, string className, IEnumerable<string> keywords) {
            if (String.IsNullOrWhiteSpace(input) || keywords == null) return input;
            return HighlightKeywords(input, className, keywords.ToArray());
        }

        /// <summary>
        /// Highlights specified <paramref name="keywords"/> in the <paramref name="input"/> string with the specified
        /// <paramref name="className"/> by using a <code>&lt;span&gt;</code> element.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="className">The class name.</param>
        /// <param name="keywords">The keywords to highlight.</param>
        /// <returns>The input string with highlighted keywords.</returns>
        public static string HighlightKeywords(string input, string className, params string[] keywords) {

            if (String.IsNullOrWhiteSpace(input) || keywords == null) return input;

            // Loop through the keywords
            foreach (string keyword in keywords) {
                input = Regex.Replace(input, keyword, String.Format("<span class=\"{1}\">{0}</span>", "$0", className), RegexOptions.IgnoreCase);
            }

            return input;

        }

        /// <summary>
        /// Gets whether the string matches an integer (<see cref="Int32"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches an integer; otherwise <code>false</code>.</returns>
        public static bool IsInt32(string str) {
            int result;
            return Int32.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Alias of <see cref="IsInt32"/>. Gets whether the string matches an integer (<see cref="Int32"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches an integer; otherwise <code>false</code>.</returns>
        public static bool IsInteger(string str) {
            return IsInt32(str);
        }

        /// <summary>
        /// Gets whether the string matches a long (<see cref="Int64"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches a long; otherwise <code>false</code>.</returns>
        public static bool IsInt64(string str) {
            long result;
            return Int64.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Gets whether the string matches a double (<see cref="Double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches a double; otherwise <code>false</code>.</returns>
        public static bool IsDouble(string str) {
            double result;
            return Double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Alias of <see cref="IsDouble"/>. Gets whether the string matches a double (<see cref="Double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> matches a double; otherwise <code>false</code>.</returns>
        public static bool IsNumeric(string str) {
            long result;
            return Int64.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Gets whether the specified string is alphanumeric - meaning it only consists of numbers and letters.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><code>true</code> if <paramref name="str"/> is alphanumeric; otherwise <code>false</code>.</returns>
        public static bool IsAlphanumeric(string str) {
            return Regex.IsMatch(str ?? "", "^[0-9a-zA-Z]+$");
        }

        /// <summary>
        /// Strips all HTML elements from the specified <paramref name="html"/> string.
        /// </summary>
        /// <param name="html">The input string containing HTML.</param>
        /// <returns>The input string without any HTML markup.</returns>
        public static string StripHtml(string html) {
            string text = Regex.Replace(html, "<.*?>", "");
            return HttpUtility.HtmlDecode(text);
        }

    }

}