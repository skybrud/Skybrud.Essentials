using System;
using System.Collections.Generic;
using System.Globalization;

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
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 32-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(string input, out int result) {
            return int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 32-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(string input, out int? result) {
            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int temp)) {
                result = temp;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static int[] ParseInt32Array(string input) {
            return ParseInt32Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Values in the list that can't be converted to
        /// <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static int[] ParseInt32Array(string input, params char[] separators) {
            return ParseInt32List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static List<int> ParseInt32List(string input) {
            return ParseInt32List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Values in the list that can't be converted to
        /// <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static List<int> ParseInt32List(string input, params char[] separators) {

            List<int> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (int.TryParse(piece, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                    temp.Add(result);
                }
            }

            return temp;

        }

    }

}