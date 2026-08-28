using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Skybrud.Essentials.Time.Xml;

/// <summary>
/// Class with various utility methods for working with XML schema.
/// </summary>
/// <see>
///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
/// </see>
public class XmlSchemaUtils {

    /// <summary>
    /// Parses the specified <paramref name="input"/> string into a corresponding <see cref="TimeSpan"/> instance.
    /// </summary>
    /// <param name="input">The duration using the XML schema format.</param>
    /// <returns>An instance of <see cref="TimeSpan"/>.</returns>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
    /// </see>
    public static TimeSpan ParseDuration(string input) {
        return XmlConvert.ToTimeSpan(input);
    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="input"/> string into a corresponding <see cref="TimeSpan"/> structure.
    /// </summary>
    /// <param name="input">The duration using the XML schema format.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="TimeSpan"/> structure if successful; otherwise, <see cref="TimeSpan.Zero"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDuration(string? input, out TimeSpan result) {

        if (string.IsNullOrWhiteSpace(input)) {
            result = TimeSpan.Zero;
            return false;
        }

        try {
            result = XmlConvert.ToTimeSpan(input);
            return true;
        } catch {
            result = TimeSpan.Zero;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="input"/> string into a corresponding <see cref="TimeSpan"/> structure.
    /// </summary>
    /// <param name="input">The duration using the XML schema format.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="TimeSpan"/> structure if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseDuration(string? input, [NotNullWhen(true)] out TimeSpan? result) {

        if (string.IsNullOrWhiteSpace(input)) {
            result = null;
            return false;
        }

        try {
            result = XmlConvert.ToTimeSpan(input);
            return true;
        } catch {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Converts the specified <paramref name="duration"/> to a corresponding XML schema duration.
    /// </summary>
    /// <param name="duration">The duration to be converted.</param>
    /// <returns>A <see cref="string"/> representing the XML schema duration.</returns>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
    /// </see>
    public static string ToString(TimeSpan duration) {
        return XmlConvert.ToString(duration);
    }

}