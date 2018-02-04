using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

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
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Double"/>. If the parsing fails,
        /// the default value of <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="Double"/>.</returns>
        public static double ParseDouble(string str) {
            double value;
            Double.TryParse(str, out value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Double"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="Double"/>.</returns>
        public static double ParseDouble(string str, double fallback) {
            double value;
            return Double.TryParse(str, out value) ? value : fallback;
        }

        /// <summary>
        /// Parses a string of integer values into an array of <see cref="Double"/>. Supported separators are
        /// <code>,</code>, <code> </code>, <code>\r</code>, <code>\n</code> and <code>\t</code>. Values in the list
        /// that can't be converted to <see cref="Double"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of integer values to be parsed.</param>
        /// <returns>An array of <see cref="Double"/>.</returns>
        public static double[] ParseDoubleArray(string str) {
            return ParseDoubleArray(str, ',', ' ', '\r', '\n', '\t');
        }

        /// <summary>
        /// Parses a string of double values into an array of <see cref="Double"/>. Values in the list that can't be
        /// converted to <see cref="Double"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of double values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Double"/>.</returns>
        public static double[] ParseDoubleArray(string str, params char[] separators) {
            return (
                from piece in (str ?? "").Split(separators, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select Double.Parse(piece)
            ).ToArray();
        }

    }

}