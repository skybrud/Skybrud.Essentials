using System;
using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches an integer (<see cref="float"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a long; otherwise <c>false</c>.</returns>
        public static bool IsFloat(string str) {
            return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="float"/>. If the parsing fails,
        /// the default value of <see cref="float"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ParseFloat(string str) {
            float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out float value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="float"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ParseFloat(string str, int fallback) {
            return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out float value) ? value : fallback;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="float"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ParseFloat(string str, float fallback) {
            return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out float value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="float"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of single-precision floating-point values (<see cref="float"/>).</returns>
        public static float[] ParseFloatArray(string input) {
            return ParseFloatArray(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Values in the list that can't be converted to
        /// <see cref="float"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of single-precision floating-point values (<see cref="float"/>).</returns>
        public static float[] ParseFloatArray(string input, params char[] separators) {
            return ParseFloatList(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="float"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="float"/>).</returns>
        public static List<float> ParseFloatList(string input) {
            return ParseFloatList(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Values in the list that can't be converted to
        /// <see cref="float"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of single-precision floating-point values (<see cref="float"/>).</returns>
        public static List<float> ParseFloatList(string input, params char[] separators) {

            List<float> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (float.TryParse(piece, NumberStyles.Any, CultureInfo.InvariantCulture, out float result)) {
                    temp.Add(result);
                }
            }

            return temp;

        }

    }

}