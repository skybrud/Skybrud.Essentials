using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 16-bit unsigned integer (<see cref="ushort"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 16-bit unsigned integer (<see cref="ushort"/>); otherwise, <c>false</c>.</returns>
        public static bool IsUInt16(this string? input) {
            return StringUtils.TryParseUInt16(input, out ushort _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 16-bit unsigned integer (<see cref="ushort"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="ushort"/> if successful; otherwise, <c>0</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 16-bit unsigned integer (<see cref="ushort"/>); otherwise, <c>false</c>.</returns>
        public static bool IsUInt16(this string? input, out ushort result) {
            return StringUtils.TryParseUInt16(input, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a 16-bit unsigned integer (<see cref="ushort"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="ushort"/> if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a 16-bit unsigned integer (<see cref="ushort"/>); otherwise, <c>false</c>.</returns>
        public static bool IsUInt16(this string? input, [NotNullWhen(true)] out ushort? result) {
            return StringUtils.TryParseUInt16(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the conversion fails, <c>0</c> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort ToUInt16(this string? input) {
            return StringUtils.ParseUInt16(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="ushort"/>.</returns>
        public static ushort ToUInt16(this string? input, ushort fallback) {
            return StringUtils.ParseUInt16(input, fallback);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static ushort? ToUInt16OrNull(this string? input) {
            return StringUtils.ParseUInt16OrNull(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit unsigned integer equivalent (<see cref="ushort"/>). A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="ushort.MinValue"/> or greater than <see cref="ushort.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt16(this string? input, out ushort result) {
            return StringUtils.TryParseUInt16(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 16-bit unsigned integer value equivalent of the
        /// number contained in <paramref name="input"/>, if the conversion succeeded, or <c>null</c> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is <c>null</c> or
        /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
        /// <see cref="ushort.MinValue"/> or greater than <see cref="ushort.MaxValue"/>.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseUInt16(this string? input, [NotNullWhen(true)] out ushort? result) {
            return StringUtils.TryParseUInt16(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 16-bit unsigned integer values (<see cref="ushort"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="ushort"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
        public static ushort[] ToUInt16Array(this string? input) {
            return StringUtils.ParseUInt16Array(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// 16-bit unsigned integer values (<see cref="ushort"/>). Values in the list that can't be converted to
        /// <see cref="ushort"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
        public static ushort[] ToUInt16Array(this string? input, params char[] separators) {
            return StringUtils.ParseUInt16Array(input, separators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 16-bit unsigned integer values (<see cref="ushort"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
        /// <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="ushort"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
        public static List<ushort> ToUInt16List(this string? input) {
            return StringUtils.ParseUInt16List(input);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// 16-bit unsigned integer values (<see cref="ushort"/>). Values in the list that can't be converted to
        /// <see cref="ushort"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
        public static List<ushort> ToUInt16List(this string? input, params char[] separators) {
            return StringUtils.ParseUInt16List(input, separators);
        }

    }

}