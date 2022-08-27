﻿using System.Collections.Generic;
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
        /// Returns whether the specified <paramref name="value"/> matches an integer.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="result">The converted <see cref="int"/> value, of <c>0</c> if <paramref name="value"/> doesn't match an integer.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches an integer; otherwise <c>false</c>.</returns>
        public static bool IsInt32(string value, out int result) {
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="value"/> matches an integer.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="result">The converted <see cref="int"/> value, of <c>0</c> if <paramref name="value"/> doesn't match an integer.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches an integer; otherwise <c>false</c>.</returns>
        public static bool IsInt32(string value, out int? result) {
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int v)) {
                result = v;
                return true;
            }
            result = null;
            return false;
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
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 32-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(this string input, out int result) {
            return StringUtils.TryParseInt32(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 32-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt32(this string input, out int? result) {
            return StringUtils.TryParseInt32(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static int[] ToInt32Array(this string input) {
            return StringUtils.ParseInt32Array(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Values in the list that can't be converted to
        /// <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static int[] ToInt32Array(this string input, params char[] separators) {
            return StringUtils.ParseInt32Array(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static List<int> ToInt32List(this string input) {
            return StringUtils.ParseInt32List(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit signed integer values (<see cref="int"/>). Values in the list that can't be converted to
        /// <see cref="int"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="int"/>).</returns>
        public static List<int> ToInt32List(this string input, params char[] separators) {
            return StringUtils.ParseInt32List(input, separators);
        }

    }

}