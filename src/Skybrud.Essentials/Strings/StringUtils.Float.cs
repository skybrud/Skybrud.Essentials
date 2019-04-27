using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches an integer (<see cref="Single"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a long; otherwise <c>false</c>.</returns>
        public static bool IsFloat(string str) {
            return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }
        
        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Single"/>. If the parsing fails,
        /// the default value of <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="Single"/>.</returns>
        public static float ParseFloat(string str) {
            float.TryParse(str, out float value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Single"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="Single"/>.</returns>
        public static float ParseFloat(string str, int fallback) {
            return float.TryParse(str, out float value) ? value : fallback;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Single"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="Single"/>.</returns>
        public static float ParseFloat(string str, float fallback) {
            return float.TryParse(str, out float value) ? value : fallback;
        }

        /// <summary>
        /// Parses a string of float values into an array of <see cref="Single"/>. Supported separators are
        /// <c>,</c>, <c> </c>, <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="Single"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of float values to be parsed.</param>
        /// <returns>An array of <see cref="Single"/>.</returns>
        public static float[] ParseFloatArray(string str) {
            return ParseFloatArray(str, ',', ' ', '\r', '\n', '\t');
        }

        /// <summary>
        /// Parses a string of float values into an array of <see cref="Single"/>. Values in the list that can't be
        /// converted to <see cref="Single"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of float values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Single"/>.</returns>
        public static float[] ParseFloatArray(string str, params char[] separators) {
            return (
                from piece in (str ?? "").Split(separators, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select float.Parse(piece)
            ).ToArray();
        }

    }

}