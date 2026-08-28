#if NETSTANDARD2_0_OR_GREATER || NET45_OR_GREATER || NET5_0_OR_GREATER

using System.Globalization;

namespace Skybrud.Essentials.Globalization;

/// <summary>
/// Static class with various utility methods for working with globalization and internationalization.
/// </summary>
public static class GlobalizationUtils {

    private static readonly IdnMapping _idn = new();

    /// <summary>
    /// Converts the specified <paramref name="value"/> from Punycode to Unicode.
    /// </summary>
    /// <param name="value">The Punycode string to convert.</param>
    /// <returns>The converted Unicode string.</returns>
    public static string FromPunycode(string value) {

        if (string.IsNullOrWhiteSpace(value)) return value;

        string[] parts = value.Split('.');
        for (int i = 0; i < parts.Length; i++) {
            parts[i] = _idn.GetUnicode(parts[i]);
        }

        return string.Join(".", parts);

    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> from Unicode to Punycode.
    /// </summary>
    /// <param name="value">The Unicode string to convert.</param>
    /// <returns>The converted Punycode string.</returns>
    public static string ToPunycode(string value) {

        if (string.IsNullOrWhiteSpace(value)) return value;

        string[] parts = value.Split('.');
        for (int i = 0; i < parts.Length; i++) {
            parts[i] = _idn.GetAscii(parts[i]);
        }

        return string.Join(".", parts);
    }

}

#endif