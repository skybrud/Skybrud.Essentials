using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions;

public static partial class StringExtensions {

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a 64-bit unsigned integer (<see cref="ulong"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a 64-bit unsigned integer (<see cref="ulong"/>);
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsUInt64(this string? input) {
        return StringUtils.TryParseUInt64(input, out ulong _);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a 64-bit unsigned integer (<see cref="ulong"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="ulong"/> if successful;
    /// otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a 64-bit unsigned integer (<see cref="ulong"/>);
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsUInt64(this string? input, out ulong result) {
        return StringUtils.TryParseUInt64(input, out result);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a 64-bit unsigned integer (<see cref="ulong"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="ulong"/> if successful;
    /// otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a 64-bit unsigned integer (<see cref="ulong"/>);
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsUInt64(this string? input, [NotNullWhen(true)] out ulong? result) {
        return StringUtils.TryParseUInt64(input, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
    /// conversion fails, <c>0</c> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns>An instance of <see cref="ulong"/>.</returns>
    public static ulong ToUInt64(this string? input) {
        return StringUtils.ParseUInt64(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
    /// conversion fails, <paramref name="fallback"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
    /// <returns>An instance of <see cref="ulong"/>.</returns>
    public static ulong ToUInt64(this string? input, ulong fallback) {
        return StringUtils.ParseUInt64(input, fallback);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 64-bit unsigned integer equivalent. If the
    /// conversion fails, <see langword="null"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns>An instance of <see cref="ulong"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static ulong? ToUInt64OrNull(this string? input) {
        return StringUtils.ParseUInt64OrNull(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
    /// unsigned integer equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the 64-bit unsigned integer value equivalent of the
    /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
    /// failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="ulong.MinValue"/> or greater than <see cref="ulong.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt64(this string? input, out ulong result) {
        return StringUtils.TryParseUInt64(input, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into it's representation of a number to its 64-bit
    /// unsigned integer equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the 64-bit unsigned integer value equivalent of the
    /// number contained in <paramref name="input"/>, if the conversion succeeded, or <see langword="null"/> if the conversion
    /// failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="ulong.MinValue"/> or greater than <see cref="ulong.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt64(this string? input, [NotNullWhen(true)] out ulong? result) {
        return StringUtils.TryParseUInt64(input, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// 64-bit unsigned integer values (<see cref="ulong"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
    /// <c>\n</c> and <c>\t</c>. Values in the list
    /// that can't be converted to <see cref="ulong"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <returns>An array of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
    public static ulong[] ToUInt64Array(this string? input) {
        return StringUtils.ParseUInt64Array(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// 64-bit unsigned integer values (<see cref="ulong"/>). Values in the list that can't be converted to
    /// <see cref="ulong"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>An array of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
    public static ulong[] ToUInt64Array(this string? input, params char[] separators) {
        return StringUtils.ParseUInt64Array(input, separators);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
    /// 64-bit unsigned integer values (<see cref="ulong"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
    /// <c>\n</c> and <c>\t</c>. Values in the list
    /// that can't be converted to <see cref="ulong"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <returns>A list of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
    public static List<ulong> ToUInt64List(this string? input) {
        return StringUtils.ParseUInt64List(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
    /// 64-bit unsigned integer values (<see cref="ulong"/>). Values in the list that can't be converted to
    /// <see cref="ulong"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>A list of 64-bit unsigned integer values (<see cref="ulong"/>).</returns>
    public static List<ulong> ToUInt64List(this string? input, params char[] separators) {
        return StringUtils.ParseUInt64List(input, separators);
    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of unsigned 64-bit integer values. Supported separators are comma
    /// (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="ulong"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <returns>
    /// A <see cref="HashSet{Int64}"/> containing the unique <see cref="ulong"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="ulong"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="ulong"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<ulong> ToUInt64Set(this string? input) {
        return StringUtils.ParseUInt64Set(input);
    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of unsigned 64-bit integer values, using the specified <paramref name="separators"/>.
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="ulong"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>
    /// A <see cref="HashSet{Int64}"/> containing the unique <see cref="ulong"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="ulong"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="ulong"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<ulong> ToUInt64Set(this string? input, params char[] separators) {
        return StringUtils.ParseUInt64Set(input, separators);
    }

}