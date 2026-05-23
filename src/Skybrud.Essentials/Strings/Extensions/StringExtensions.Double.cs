using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions;

public static partial class StringExtensions {

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a double-precision floating-point
    /// number (<see cref="double"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a float; otherwise <see langword="false"/>.</returns>
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
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a double; otherwise, <see langword="false"/>.</returns>
    public static bool IsDouble(this string? input, out double result) {
        return StringUtils.TryParseDouble(input, out result);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a double-precision floating-point
    /// number (<see cref="double"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="result">When this method returns, holds the converted <see cref="double"/> if successful;
    /// otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a double; otherwise, <see langword="false"/>.</returns>
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
    /// equivalent (<see cref="double"/>). If the parsing fails, <see langword="null"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be parsed.</param>
    /// <returns>An instance of <see cref="double"/> if successful; otherwise, <see langword="null"/>.</returns>
    public static double? ToDoubleOrNull(this string? input) {
        return StringUtils.ParseDoubleOrNull(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
    /// equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the double-precision floating-point number
    /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or zero if the
    /// conversion failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDouble(this string? input, out double result) {
        return StringUtils.TryParseDouble(input, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string into it's double-precision floating-point number
    /// equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="input">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the double-precision floating-point number
    /// equivalent of the number contained in <paramref name="input"/>, if the conversion succeeded, or <see langword="null"/>
    /// if the conversion failed. The conversion fails if the <paramref name="input"/> parameter is <see langword="null"/> or
    /// <see cref="string.Empty"/>, is not of the correct format, or represents a number less than
    /// <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDouble(this string? input, [NotNullWhen(true)] out double? result) {
        return StringUtils.TryParseDouble(input, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// double-precision floating-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
    /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
    /// be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <returns>An array of double-precision floating-point values (<see cref="double"/>).</returns>
    public static double[] ToDoubleArray(this string? input) {
        return StringUtils.ParseDoubleArray(input);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
    /// double-precision floating-point values (<see cref="double"/>). Values in the list that can't be converted to
    /// <see cref="double"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>An array of double-precision floating-point values (<see cref="double"/>).</returns>
    public static double[] ToDoubleArray(this string? input, params char[] separators) {
        return StringUtils.ParseDoubleArray(input, separators);
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
    /// double-precision floating-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
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
    /// double-precision floating-point values (<see cref="double"/>). Values in the list that can't be converted to
    /// <see cref="double"/> will be ignored.
    /// </summary>
    /// <param name="input">The string of numeric values to be parsed.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>A list of double-precision floating-point values (<see cref="double"/>).</returns>
    public static List<double> ToDoubleList(this string? input, params char[] separators) {
        return StringUtils.ParseDoubleList(input, separators);
    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of double-precision floating-point values. Supported separators are comma
    /// (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="double"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <returns>
    /// A <see cref="HashSet{Double}"/> containing the unique <see cref="double"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="double"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="double"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<double> ToDoubleSet(this string? input) {
        return StringUtils.ParseDoubleSet(input);
    }

    /// <summary>
    /// Converts the specified string of separated values into a corresponding set of double-precision floating-point values, using the specified <paramref name="separators"/>.
    /// </summary>
    /// <param name="input">The input string containing one or more <see cref="double"/> values separated by the specified separator characters. Can be <see langword="null"/> or empty.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>
    /// A <see cref="HashSet{Double}"/> containing the unique <see cref="double"/> values parsed from the input string. Returns an empty set if
    /// the input is <see langword="null"/> or contains no valid <see cref="double"/>.
    /// </returns>
    /// <remarks>Only valid <see cref="double"/> values are included in the returned set. Invalid or unparseable values are ignored.</remarks>
    public static HashSet<double> ToDoubleSet(this string? input, params char[] separators) {
        return StringUtils.ParseDoubleSet(input, separators);
    }

}