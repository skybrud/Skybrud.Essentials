using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings;

public static partial class StringUtils {

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a 16-bit unsigned integer (<see cref="ushort"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a 16-bit unsigned integer (<see cref="ushort"/>);
    /// otherwise, <see langword="false"/>.</returns>
    public static bool IsUInt16(string? input) {
        return TryParseUInt16(input, out ushort _);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the
    /// conversion fails, <c>0</c> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns>An instance of <see cref="ushort"/>.</returns>
    public static ushort ParseUInt16(string? input) {
        return TryParseUInt16(input, out ushort value) ? value : default;
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the
    /// conversion fails, <paramref name="fallback"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
    /// <returns>An instance of <see cref="ushort"/>.</returns>
    public static ushort ParseUInt16(string? input, ushort fallback) {
        return TryParseUInt16(input, out ushort value) ? value : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into its 16-bit unsigned integer equivalent. If the
    /// conversion fails, <see langword="null"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns>An instance of <see cref="ushort"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static ushort? ParseUInt16OrNull(string? input) {
        return TryParseUInt16(input, out ushort value) ? value : null;
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit signed
    /// integer equivalent (<see cref="ushort"/>). A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the 16-bit unsigned integer value equivalent of the
    /// number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the conversion
    /// failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="ushort.MinValue"/> or greater than <see cref="ushort.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt16(string? input, out ushort result) {
        return ushort.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string representation of a number to its 16-bit signed
    /// integer equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the 16-bit unsigned integer value equivalent of the
    /// number contained in <paramref name="input"/>, if the conversion succeeded, or <see langword="null"/> if the conversion
    /// failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="ushort.MinValue"/> or greater than <see cref="ushort.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseUInt16(string? input, [NotNullWhen(true)] out ushort? result) {
        if (ushort.TryParse(input, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out ushort temp)) {
            result = temp;
            return true;
        }
        result = null;
        return false;
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// 16-bit unsigned integer values (<see cref="ushort"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
    /// <c>\n</c> and <c>\t</c>. Values in the list
    /// that can't be converted to <see cref="ushort"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <returns>An array of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
    public static ushort[] ParseUInt16Array(string? input) {
        return ParseUInt16Array(input, DefaultSeparators);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// 16-bit unsigned integer values (<see cref="ushort"/>). Values in the list that can't be converted to
    /// <see cref="ushort"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>An array of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
    public static ushort[] ParseUInt16Array(string? input, params char[] separators) {
        return [.. ParseUInt16List(input, separators)];
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
    /// 16-bit unsigned integer values (<see cref="ushort"/>). Supported separators are <c>,</c>, <c> </c>, <c>\r</c>,
    /// <c>\n</c> and <c>\t</c>. Values in the list
    /// that can't be converted to <see cref="ushort"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <returns>A list of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
    public static List<ushort> ParseUInt16List(string? input) {
        return ParseUInt16List(input, DefaultSeparators);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
    /// 16-bit unsigned integer values (<see cref="ushort"/>). Values in the list that can't be converted to
    /// <see cref="ushort"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>A list of 16-bit unsigned integer values (<see cref="ushort"/>).</returns>
    public static List<ushort> ParseUInt16List(string? input, params char[] separators) {

        List<ushort> temp = [];
        if (string.IsNullOrWhiteSpace(input)) return temp;

        foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
            if (TryParseUInt16(piece, out ushort result)) temp.Add(result);
        }

        return temp;

    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of unsigned 16-bit integer values. Supported separators are comma
    /// (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="ushort"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <returns>
    /// A <see cref="HashSet{UInt16}"/> containing the unique <see cref="ushort"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="ushort"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="ushort"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<ushort> ParseUInt16Set(string? input) {
        return ParseUInt16Set(input, DefaultSeparators);
    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of unsigned 16-bit integer values, using the specified <paramref name="separators"/>.
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="ushort"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>
    /// A <see cref="HashSet{UInt16}"/> containing the unique <see cref="ushort"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="ushort"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="ushort"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<ushort> ParseUInt16Set(string? input, params char[] separators) {

        HashSet<ushort> temp = [];
        if (string.IsNullOrWhiteSpace(input)) return temp;

        foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
            if (ushort.TryParse(piece, out ushort result)) temp.Add(result);
        }

        return temp;

    }

}