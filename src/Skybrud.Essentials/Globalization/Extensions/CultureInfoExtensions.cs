using System.Globalization;
using Skybrud.Essentials.Strings.Extensions;

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

    /// <summary>
    /// Returns the native name of the language associated with the specified <paramref name="cultureInfo"/>.
    /// </summary>
    /// <param name="cultureInfo">The culture info.</param>
    /// <returns>The native language name.</returns>
    public static string GetNativeLanguageName(this CultureInfo cultureInfo) {
        return (cultureInfo.IsNeutralCulture ? cultureInfo.NativeName : cultureInfo.Parent.NativeName).FirstCharToUpper();
    }

}