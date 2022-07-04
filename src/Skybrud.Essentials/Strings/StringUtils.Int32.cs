using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches an integer (<see cref="int"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a long; otherwise <c>false</c>.</returns>
        public static bool IsInt32(string str) {
            return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="int"/>. If the parsing fails,
        /// the default value of <see cref="int"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int ParseInt32(string str) {
            int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="int"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int ParseInt32(string str, int fallback) {
            return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value) ? value : fallback;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value
        /// indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(string input, out int result) {
            return int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. A return value
        /// indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(string input, out int? result) {
            if (int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out int temp)) {
                result = temp;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Parses a string of integer values into an array of <see cref="int"/>. Supported separators are
        /// <c>,</c>, <c> </c>, <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of integer values to be parsed.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        public static int[] ParseInt32Array(string str) {
            return ParseInt32Array(str, ',', ' ', '\r', '\n', '\t');
        }

        /// <summary>
        /// Parses a string of integer values into an array of <see cref="int"/>. Values in the list that can't be
        /// converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of integer values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        public static int[] ParseInt32Array(string str, params char[] separators) {
            return (
                from piece in (str ?? string.Empty).Split(separators, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select int.Parse(piece, NumberStyles.Integer, CultureInfo.InvariantCulture)
            ).ToArray();
        }

    }

}