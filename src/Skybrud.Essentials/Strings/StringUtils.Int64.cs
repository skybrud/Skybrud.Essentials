using System;
using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches a long (<see cref="long"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a long; otherwise <c>false</c>.</returns>
        public static bool IsInt64(string str) {
            return long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="long"/>. If the parsing fails,
        /// the default value of <see cref="long"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ParseInt64(string str) {
            long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out long value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="long"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ParseInt64(string str, long fallback) {
            return long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out long value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ParseInt64Array(string input) {
            return ParseInt64Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ParseInt64Array(string input, params char[] separators) {
            return ParseInt64List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ParseInt64List(string input) {
            return ParseInt64List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ParseInt64List(string input, params char[] separators) {

            List<long> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (long.TryParse(piece, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result)) {
                    temp.Add(result);
                }
            }

            return temp;

        }

    }

}