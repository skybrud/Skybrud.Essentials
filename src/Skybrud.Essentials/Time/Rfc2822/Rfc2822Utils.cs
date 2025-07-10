using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time.Rfc822;

namespace Skybrud.Essentials.Time.Rfc2822;

/// <summary>
/// Static class for working with date and time according to the <strong>RFC 2822</strong> specification.
/// </summary>
public static class Rfc2822Utils {

    /// <summary>
    /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
    /// </summary>
    /// <param name="timestamp">The timestamp to be converted.</param>
    /// <returns>The timestamp formatted as an RFC 822 date string.</returns>
    public static string ToString(DateTime timestamp) {
        return Rfc822Utils.ToString(timestamp);
    }

    /// <summary>
    /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
    /// </summary>
    /// <param name="timestamp">The timestamp to be converted.</param>
    /// <returns>The timestamp formatted as an RFC 822 date string.</returns>
    public static string ToString(DateTimeOffset timestamp) {
        return Rfc822Utils.ToString(timestamp);
    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> formatted date to a corresponding instance of <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="value">The string with the RFC 2822 formatted date.</param>
    /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
    public static DateTimeOffset Parse(string? value) {
        if (TryParse(value, out DateTimeOffset result)) return result;
        throw new FormatException($"String '{value}' was not recognized as a valid DateTime.");
    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> formatted date to its <see cref="DateTime"/>
    /// equivalent and returns a value that indicates whether the conversion
    /// succeeded.
    /// </summary>
    /// <param name="value">The string with the RFC 2822 formatted date.</param>
    /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value
    /// equivalent to the date and time contained in <paramref name="value"/>, if the conversion succeeded, or
    /// <see cref="DateTime.MinValue"/> if the conversion failed.</param>
    /// <returns><see langword="true"/> if the <paramref name="value"/> parameter was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(string? value, out DateTime result) {
        return Rfc822Utils.TryParse(value, out result);
    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> formatted date to its <see cref="DateTimeOffset"/>
    /// equivalent and returns a value that indicates whether the conversion
    /// succeeded.
    /// </summary>
    /// <param name="value">The string with the RFC 2822 formatted date.</param>
    /// <param name="result">When this method returns, contains the <see cref="DateTimeOffset"/> value
    /// equivalent to the date and time contained in <paramref name="value"/>, if the conversion succeeded, or
    /// <see cref="DateTimeOffset.MinValue"/> if the conversion failed.</param>
    /// <returns><see langword="true"/> if the <paramref name="value"/> parameter was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(string? value, out DateTimeOffset result) {
        return Rfc822Utils.TryParse(value, out result);
    }

}