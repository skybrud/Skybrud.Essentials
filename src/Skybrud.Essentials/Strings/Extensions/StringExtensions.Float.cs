using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Gets whether the string matches a float (<see cref="float"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a float; otherwise <c>false</c>.</returns>
        public static bool IsFloat(this string str) {
            return StringUtils.IsFloat(str);
        }

        /// <summary>
        /// Gets whether the string matches a float (<see cref="float"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <param name="result">The converted value <paramref name="str"/> matches a <see cref="float"/>; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a float; otherwise <c>false</c>.</returns>
        public static bool IsFloat(this string str, out float result) {
            return float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="float"/>. If the conversion fails,
        /// <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ToFloat(this string input) {
            return StringUtils.ParseFloat(input);
        }

        /// <summary>
        /// Converts <paramref name="input"/> to an instance of <see cref="float"/>. If the conversion fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ToFloat(this string input, float fallback) {
            return StringUtils.ParseFloat(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="float"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of single-precision floating-point values (<see cref="float"/>).</returns>
        public static float[] ToFloatArray(this string input) {
            return StringUtils.ParseFloatArray(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Values in the list that can't be converted to
        /// <see cref="float"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of single-precision floating-point values (<see cref="float"/>).</returns>
        public static float[] ToFloatArray(this string input, params char[] separators) {
            return StringUtils.ParseFloatArray(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="float"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="float"/>).</returns>
        public static List<float> ToFloatList(this string input) {
            return StringUtils.ParseFloatList(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Values in the list that can't be converted to
        /// <see cref="float"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of single-precision floating-point values (<see cref="float"/>).</returns>
        public static List<float> ToFloatList(this string input, params char[] separators) {
            return StringUtils.ParseFloatList(input, separators);
        }

    }

}