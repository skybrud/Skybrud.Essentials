﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 64-bit unsigned integer
        /// (<see cref="ulong"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 64-bit unsigned integer (<see cref="ulong"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsUInt64(string? input) {
            return TryParseUInt64(input, out ulong _);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
        /// conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong ParseUInt64(string? input) {
            return TryParseUInt64(input, out ulong result) ? result : default;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="ulong"/>.</returns>
        public static ulong ParseUInt64(string? input, ulong fallback) {
            return TryParseUInt64(input, out ulong value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="ulong"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ulong? ParseUInt64OrNull(string? input) {
            return TryParseUInt64(input, out ulong value) ? value : null;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
        /// unsigned integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="ulong.MinValue"/> or greater than <see cref="ulong.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt64(string? input, out ulong result) {
            return ulong.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
        /// unsigned integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 64-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="ulong.MinValue"/> or greater than <see cref="ulong.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt64(string? input, [NotNullWhen(true)] out ulong? result) {
            if (ulong.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out ulong v)) {
                result = v;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit unsigned integer values (<see cref="ulong"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="ulong"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
        public static ulong[] ParseUInt64Array(string? input) {
            return ParseUInt64Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 64-bit unsigned integer values (<see cref="ulong"/>). Values in the list that can't be converted to
        /// <see cref="ulong"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
        public static ulong[] ParseUInt64Array(string? input, params char[] separators) {
            return ParseUInt64List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit unsigned integer values (<see cref="ulong"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="ulong"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
        public static List<ulong> ParseUInt64List(string? input) {
            return ParseUInt64List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 64-bit unsigned integer values (<see cref="ulong"/>). Values in the list that can't be converted to
        /// <see cref="ulong"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
        public static List<ulong> ParseUInt64List(string? input, params char[] separators) {

            List<ulong> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (TryParseUInt64(piece, out ulong result)) temp.Add(result);
            }

            return temp;

        }

    }

}