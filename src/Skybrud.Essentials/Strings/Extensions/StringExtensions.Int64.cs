using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 64-bit signed integer
        /// (<see cref="long"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 64-bit signed integer (<see cref="long"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsInt64(this string? input) {
            return StringUtils.TryParseInt64(input, out long _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 64-bit signed integer
        /// (<see cref="long"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="long"/> if successful;
        /// otherwise, <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 64-bit signed integer (<see cref="long"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsInt64(this string? input, out long result) {
            return StringUtils.TryParseInt64(input, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 64-bit signed integer
        /// (<see cref="long"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="long"/> if successful;
        /// otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 64-bit signed integer (<see cref="long"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsInt64(this string? input, [NotNullWhen(true)] out long? result) {
            return StringUtils.TryParseInt64(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ToInt64(this string? input) {
            return StringUtils.ParseInt64(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ToInt64(this string? input, long fallback) {
            return StringUtils.ParseInt64(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static long? ToInt64OrNull(this string? input) {
            return StringUtils.ParseInt64OrNull(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="long.MinValue"/> or greater than <see cref="long.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt64(this string? input, out long result) {
            return StringUtils.TryParseInt64(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
        /// signed integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="long.MinValue"/> or greater than <see cref="long.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt64(this string? input, [NotNullWhen(true)] out long? result) {
            return StringUtils.TryParseInt64(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ToInt64Array(this string? input) {
            return StringUtils.ParseInt64Array(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ToInt64Array(this string? input, params char[] separators) {
            return StringUtils.ParseInt64Array(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ToInt64List(this string? input) {
            return StringUtils.ParseInt64List(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ToInt64List(this string? input, params char[] separators) {
            return StringUtils.ParseInt64List(input, separators);
        }

    }

}