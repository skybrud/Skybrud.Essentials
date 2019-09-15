using System;
using System.Globalization;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {
        
        /// <summary>
        /// Gets whether the string matches an integer (<see cref="int"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches an integer; otherwise <c>false</c>.</returns>
        public static bool IsInt32(string str) {
            return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Alias of <see cref="IsInt32"/>. Gets whether the string matches an integer (<see cref="int"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches an integer; otherwise <c>false</c>.</returns>
        public static bool IsInteger(string str) {
            return IsInt32(str);
        }
        
        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="int"/>. If the conversion fails,
        /// <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int ToInt32(this string input) {
            return StringUtils.ParseInt32(input);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="int"/>. If the conversion fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="int"/>.</returns>
        public static int ToInt32(this string input, int fallback) {
            return StringUtils.ParseInt32(input, fallback);
        }

        /// <summary>
        /// Parses a string of numeric values into an array of <see cref="int"/>. Values in the list that can't be
        /// converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        public static int[] ToInt32Array(this string str) {
            return StringUtils.ParseInt32Array(str);
        }

        /// <summary>
        /// Parses a string of numeric values into an array of <see cref="int"/>. Values in the list that can't be
        /// converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        public static int[] ToInt32Array(this string str, params char[] separators) {
            return StringUtils.ParseInt32Array(str, separators);
        }

    }

}