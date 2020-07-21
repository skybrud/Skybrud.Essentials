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
        /// Parses a string of numeric values into an array of <see cref="double"/>. Values in the list that can't be
        /// converted to <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="double"/>.</returns>
        public static double[] ToDoubleArray(this string str) {
            return StringUtils.ParseDoubleArray(str);
        }

        /// <summary>
        /// Parses a string of numeric values into an array of <see cref="double"/>. Values in the list that can't be
        /// converted to <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="double"/>.</returns>
        public static double[] ToDoubleArray(this string str, params char[] separators) {
            return StringUtils.ParseDoubleArray(str, separators);
        }

    }

}