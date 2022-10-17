using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a single-precision floating-point
        /// number (<see cref="float"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a single-precision floating-point number;
        /// otherwise <c>false</c>.</returns>
        public static bool IsFloat(this string? input) {
            return StringUtils.IsFloat(input);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a single-precision floating-point
        /// number (<see cref="float"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">The converted value if the conversion was successful; otherwise <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a single-precision floating-point number
        /// (<see cref="float"/>); otherwise <c>false</c>.</returns>
        public static bool IsFloat(this string? input, out float result) {
            return StringUtils.TryParseFloat(input, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a single-precision floating-point
        /// number (<see cref="float"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">The converted value if the conversion was successful; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a single-precision floating-point number
        /// (<see cref="float"/>); otherwise <c>false</c>.</returns>
        public static bool IsFloat(this string? input, [NotNullWhen(true)] out float? result) {
            return StringUtils.TryParseFloat(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's single-precision floating-point number
        /// equivalent (<see cref="float"/>). If the conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ToFloat(this string? input) {
            return StringUtils.ParseFloat(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's single-precision floating-point number
        /// equivalent (<see cref="float"/>). If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="float"/>.</returns>
        public static float ToFloat(this string? input, float fallback) {
            return StringUtils.ParseFloat(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's single-precision floating-point number
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the single-precision floating-point number
        /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the
        /// conversion failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="float.MinValue"/> or greater than <see cref="float.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseFloat(this string? input, out float result) {
            return StringUtils.TryParseFloat(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's single-precision floating-point number
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the single-precision floating-point number
        /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c>
        /// if the conversion failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="float.MinValue"/> or greater than <see cref="float.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseFloat(this string? input, [NotNullWhen(true)] out float? result) {
            return StringUtils.TryParseFloat(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// single-precision floating-point values (<see cref="float"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="float"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of single-precision floating-point values (<see cref="float"/>).</returns>
        public static float[] ToFloatArray(this string? input) {
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
        public static float[] ToFloatArray(this string? input, params char[] separators) {
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
        public static List<float> ToFloatList(this string? input) {
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
        public static List<float> ToFloatList(this string? input, params char[] separators) {
            return StringUtils.ParseFloatList(input, separators);
        }

    }

}