using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 64-bit signed integer
        /// (<see cref="long"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 64-bit signed integer (<see cref="long"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsInt64(string? input) {
            return TryParseInt64(input, out long _);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ParseInt64(string? input) {
            return TryParseInt64(input, out long result) ? result : default;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="long"/>.</returns>
        public static long ParseInt64(string? input, long fallback) {
            return TryParseInt64(input, out long value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit signed integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="long"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static long? ParseInt64OrNull(string? input) {
            return TryParseInt64(input, out long value) ? value : null;
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
        public static bool TryParseInt64(string? input, out long result) {
            return long.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
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
        public static bool TryParseInt64(string? input, [NotNullWhen(true)] out long? result) {
            if (long.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out long v)) {
                result = v;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ParseInt64Array(string? input) {
            return ParseInt64Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static long[] ParseInt64Array(string? input, params char[] separators) {
            return ParseInt64List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ParseInt64List(string? input) {
            return ParseInt64List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit signed integer values (<see cref="long"/>). Values in the list that can't be converted to
        /// <see cref="long"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 64-bit signed integer values (<see cref="long"/>).</returns>
        public static List<long> ParseInt64List(string? input, params char[] separators) {

            List<long> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (TryParseInt64(piece, out long result)) temp.Add(result);
            }

            return temp;

        }

    }

}