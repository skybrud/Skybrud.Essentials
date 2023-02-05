using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 16-bit signed integer (<see cref="short"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 16-bit signed integer (<see cref="short"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsInt16(string? input) {
            return TryParseInt16(input, out short _);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit signed integer equivalent. If the
        /// conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short ParseInt16(string? input) {
            return TryParseInt16(input, out short value) ? value : default;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit signed integer equivalent. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="short"/>.</returns>
        public static short ParseInt16(string? input, short fallback) {
            return TryParseInt16(input, out short value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit signed integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="short"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static short? ParseInt16OrNull(string? input) {
            return TryParseInt16(input, out short value) ? value : null;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit signed
        /// integer equivalent (<see cref="short"/>). A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="short.MinValue"/> or greater than <see cref="short.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt16(string? input, out short result) {
            return short.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit signed
        /// integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit signed integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="short.MinValue"/> or greater than <see cref="short.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt16(string? input, [NotNullWhen(true)] out short? result) {
            if (short.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out short temp)) {
                result = temp;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 16-bit signed integer values (<see cref="short"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="short"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 16-bit signed integer values (<see cref="short"/>).</returns>
        public static short[] ParseInt16Array(string? input) {
            return ParseInt16Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 16-bit signed integer values (<see cref="short"/>). Values in the list that can't be converted to
        /// <see cref="short"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 16-bit signed integer values (<see cref="short"/>).</returns>
        public static short[] ParseInt16Array(string? input, params char[] separators) {
            return ParseInt16List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 16-bit signed integer values (<see cref="short"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="short"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 16-bit signed integer values (<see cref="short"/>).</returns>
        public static List<short> ParseInt16List(string? input) {
            return ParseInt16List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 16-bit signed integer values (<see cref="short"/>). Values in the list that can't be converted to
        /// <see cref="short"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 16-bit signed integer values (<see cref="short"/>).</returns>
        public static List<short> ParseInt16List(string? input, params char[] separators) {

            List<short> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (TryParseInt16(piece, out short result)) temp.Add(result);
            }

            return temp;

        }

    }

}