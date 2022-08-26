using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Gets whether the string matches a double (<see cref="double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a double; otherwise <c>false</c>.</returns>
        public static bool IsDouble(this string str) {
            return StringUtils.IsDouble(str);
        }

        /// <summary>
        /// Gets whether the string matches a double (<see cref="double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <param name="result">The converted value <paramref name="str"/> matches a <see cref="double"/>; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a double; otherwise <c>false</c>.</returns>
        public static bool IsDouble(this string str, out double result) {
            return double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="double"/>. If the conversion fails,
        /// <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ToDouble(this string input) {
            return StringUtils.ParseDouble(input);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="double"/>. If the conversion fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ToDouble(this string input, double fallback) {
            return StringUtils.ParseDouble(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static double[] ToDoubleArray(this string input) {
            return StringUtils.ParseDoubleArray(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Values in the list that can't be converted to
        /// <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static double[] ToDoubleArray(this string input, params char[] separators) {
            return StringUtils.ParseDoubleArray(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="double"/>).</returns>
        public static List<double> ToDoubleList(this string input) {
            return StringUtils.ParseDoubleList(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Values in the list that can't be converted to
        /// <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static List<double> ToDoubleList(this string input, params char[] separators) {
            return StringUtils.ParseDoubleList(input, separators);
        }

    }

}