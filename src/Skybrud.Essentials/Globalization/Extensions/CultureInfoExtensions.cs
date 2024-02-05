using System.Globalization;

namespace Skybrud.Essentials.Globalization.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="CultureInfo"/>.
/// </summary>
public static class CultureInfoExtensions {

    /// <summary>
    /// Returns whether the language of the specified <paramref name="culture"/> is <strong>Danish</strong>.
    /// </summary>
    /// <param name="culture">The culture info.</param>
    /// <returns><see langword="true"/> if <paramref name="culture"/> matches <strong>Danish</strong>; otherwise, <see langword="null"/>.</returns>
    public static bool IsDanish(this CultureInfo? culture) {
        return culture is { TwoLetterISOLanguageName: "da" };
    }

    /// <summary>
    /// Returns whether the language of the specified <paramref name="culture"/> is <strong>English</strong>.
    /// </summary>
    /// <param name="culture">The culture info.</param>
    /// <returns><see langword="true"/> if <paramref name="culture"/> matches <strong>English</strong>; otherwise, <see langword="null"/>.</returns>
    public static bool IsEnglish(this CultureInfo? culture) {
        return culture is { TwoLetterISOLanguageName: "en" };
    }

    /// <summary>
    /// Returns whether the language of the specified <paramref name="culture"/> is <strong>German</strong>.
    /// </summary>
    /// <param name="culture">The culture info.</param>
    /// <returns><see langword="true"/> if <paramref name="culture"/> matches <strong>German</strong>; otherwise, <see langword="null"/>.</returns>
    public static bool IsGerman(this CultureInfo? culture) {
        return culture is { TwoLetterISOLanguageName: "de" };
    }

}