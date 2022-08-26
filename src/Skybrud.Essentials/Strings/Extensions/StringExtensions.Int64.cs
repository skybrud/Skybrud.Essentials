using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Gets whether the string matches a long (<see cref="long"/>).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches a <see cref="long"/> value; otherwise <c>false</c>.</returns>
        public static bool IsInt64(string value) {
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="value"/> matches a <see cref="long"/> value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="result">The converted <see cref="long"/> value, of <c>0</c> if <paramref name="value"/> doesn't match a <see cref="long"/> value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches an <see cref="long"/> value; otherwise <c>false</c>.</returns>
        public static bool IsInt64(string value, out long result) {
            return long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="long"/>. If the conversion fails,
        /// <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ToInt64(this string input) {
            return StringUtils.ParseInt64(input);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="long"/>. If the conversion fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ToInt64(this string input, long fallback) {
            return StringUtils.ParseInt64(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ToInt64Array(this string input) {
            return StringUtils.ParseInt64Array(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ToInt64Array(this string input, params char[] separators) {
            return StringUtils.ParseInt64Array(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ToInt64List(this string input) {
            return StringUtils.ParseInt64List(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ToInt64List(this string input, params char[] separators) {
            return StringUtils.ParseInt64List(input, separators);
        }

    }

}