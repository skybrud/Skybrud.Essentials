using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a double-precision floating-point
        /// number (<see cref="double"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a float; otherwise <c>false</c>.</returns>
        public static bool IsDouble(this string? input) {
            return StringUtils.TryParseDouble(input, out double _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a double-precision floating-point
        /// number (<see cref="double"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="double"/> if successful;
        /// otherwise, <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a double; otherwise, <c>false</c>.</returns>
        public static bool IsDouble(this string? input, out double result) {
            return StringUtils.TryParseDouble(input, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a double-precision floating-point
        /// number (<see cref="double"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="double"/> if successful;
        /// otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a double; otherwise, <c>false</c>.</returns>
        public static bool IsDouble(this string? input, [NotNullWhen(true)] out double? result) {
            return StringUtils.TryParseDouble(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
        /// equivalent (<see cref="double"/>). If the conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ToDouble(this string? input) {
            return StringUtils.ParseDouble(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
        /// equivalent (<see cref="double"/>). If the parsing fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ToDouble(this string? input, double fallback) {
            return StringUtils.ParseDouble(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the double-precision floating-point number
        /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the
        /// conversion failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseDouble(this string? input, out double result) {
            return StringUtils.TryParseDouble(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the double-precision floating-point number
        /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c>
        /// if the conversion failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseDouble(this string? input, [NotNullWhen(true)] out double? result) {
            return StringUtils.TryParseDouble(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static double[] ToDoubleArray(this string? input) {
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
        public static double[] ToDoubleArray(this string? input, params char[] separators) {
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
        public static List<double> ToDoubleList(this string? input) {
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
        public static List<double> ToDoubleList(this string? input, params char[] separators) {
            return StringUtils.ParseDoubleList(input, separators);
        }

    }

}