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
        /// Parses a string of numeric values into an array of <see cref="long"/>. Values in the list that can't be
        /// converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="long"/>.</returns>
        public static long[] ToInt64Array(this string str) {
            return StringUtils.ParseInt64Array(str);
        }

        /// <summary>
        /// Parses a string of numeric values into an array of <see cref="long"/>. Values in the list that can't be
        /// converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="long"/>.</returns>
        public static long[] ToInt64Array(this string str, params char[] separators) {
            return StringUtils.ParseInt64Array(str, separators);
        }

    }

}