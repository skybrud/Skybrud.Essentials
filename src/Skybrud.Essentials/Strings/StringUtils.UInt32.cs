using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 32-bit unsigned integer
        /// (<see cref="uint"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 32-bit unsigned integer (<see cref="uint"/>);
        /// otherwise, <c>false</c>.</returns>
        public static bool IsUInt32(string? input) {
            return TryParseUInt32(input, out uint _);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 32-bit unsigned integer equivalent. If the
        /// conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint ParseUInt32(string? input) {
            return TryParseUInt32(input, out uint value) ? value : default;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 32-bit unsigned integer equivalent. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="uint"/>.</returns>
        public static uint ParseUInt32(string? input, uint fallback) {
            return TryParseUInt32(input, out uint value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 32-bit unsigned integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="uint"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static uint? ParseUInt32OrNull(string? input) {
            return TryParseUInt32(input, out uint value) ? value : null;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 32-bit signed
        /// integer equivalent (<see cref="uint"/>). A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt32(string? input, out uint result) {
            return uint.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 32-bit signed
        /// integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt32(string? input, [NotNullWhen(true)] out uint? result) {
            if (uint.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out uint temp)) {
                result = temp;
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit unsigned integer values (<see cref="uint"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="uint"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 32-bit unsigned integer values (<see cref="uint"/>).</returns>
        public static uint[] ParseUInt32Array(string? input) {
            return ParseUInt32Array(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 32-bit unsigned integer values (<see cref="uint"/>). Values in the list that can't be converted to
        /// <see cref="uint"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 32-bit unsigned integer values (<see cref="uint"/>).</returns>
        public static uint[] ParseUInt32Array(string? input, params char[] separators) {
            return ParseUInt32List(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit unsigned integer values (<see cref="uint"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="uint"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit unsigned integer values (<see cref="uint"/>).</returns>
        public static List<uint> ParseUInt32List(string? input) {
            return ParseUInt32List(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 32-bit unsigned integer values (<see cref="uint"/>). Values in the list that can't be converted to
        /// <see cref="uint"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 32-bit unsigned integer values (<see cref="uint"/>).</returns>
        public static List<uint> ParseUInt32List(string? input, params char[] separators) {

            List<uint> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (TryParseUInt32(piece, out uint result)) temp.Add(result);
            }

            return temp;

        }

    }

}