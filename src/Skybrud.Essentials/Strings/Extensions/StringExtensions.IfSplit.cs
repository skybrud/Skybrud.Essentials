using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings.Extensions;

public partial class StringExtensions {

    /// <summary>
    /// Attempts to split the specified <paramref name="input"/> string into two parts based on the specified <paramref name="separator"/>.
    /// </summary>
    /// <param name="input">The input string to be split.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="first">When this method returns, holds the first string value if successful; otherwise, <see langword="null"/>.</param>.
    /// <param name="second">When this method returns, holds the second string value if successful; otherwise, <see langword="null"/>.</param>.
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool IfSplit(this string? input, char separator, [NotNullWhen(true)] out string? first, [NotNullWhen(true)] out string? second) {

        if (string.IsNullOrEmpty(input)) {
            first = null;
            second = null;
            return false;
        }

        string[] pieces = input!.Split(separator);

        if (pieces.Length < 2) {
            first = null;
            second = null;
            return false;
        }

        first = pieces[0];
        second = pieces[1];
        return true;

    }

    /// <summary>
    /// Attempts to split the specified <paramref name="input"/> string into two parts based on the specified <paramref name="separator"/>.
    /// </summary>
    /// <param name="input">The input string to be split.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="first">When this method returns, holds the first string value converted to a <see cref="int"/> if successful; otherwise, <see cref="Guid.Empty"/>.</param>.
    /// <param name="second">When this method returns, holds the second string value if successful; otherwise, <see langword="null"/>.</param>.
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool IfSplit(this string? input, char separator, out int first, [NotNullWhen(true)] out string? second) {

        if (string.IsNullOrEmpty(input)) {
            first = 0;
            second = null;
            return false;
        }

        string[] pieces = input!.Split(separator);

        if (pieces.Length >= 2 && int.TryParse(pieces[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out first)) {
            second = pieces[1];
            return true;
        }

        first = 0;
        second = null;
        return false;

    }

    /// <summary>
    /// Attempts to split the specified <paramref name="input"/> string into two parts based on the specified <paramref name="separator"/>.
    /// </summary>
    /// <param name="input">The input string to be split.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="first">When this method returns, holds the first string value converted to a <see cref="long"/> if successful; otherwise, <see cref="Guid.Empty"/>.</param>.
    /// <param name="second">When this method returns, holds the second string value if successful; otherwise, <see langword="null"/>.</param>.
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool IfSplit(this string? input, char separator, out long first, [NotNullWhen(true)] out string? second) {

        if (string.IsNullOrEmpty(input)) {
            first = 0;
            second = null;
            return false;
        }

        string[] pieces = input!.Split(separator);

        if (pieces.Length >= 2 && long.TryParse(pieces[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out first)) {
            second = pieces[1];
            return true;
        }

        first = 0;
        second = null;
        return false;

    }

    /// <summary>
    /// Attempts to split the specified <paramref name="input"/> string into two parts based on the specified <paramref name="separator"/>.
    /// </summary>
    /// <param name="input">The input string to be split.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="first">When this method returns, holds the first string value converted to a <see cref="Guid"/> if successful; otherwise, <see cref="Guid.Empty"/>.</param>.
    /// <param name="second">When this method returns, holds the second string value if successful; otherwise, <see langword="null"/>.</param>.
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool IfSplit(this string? input, char separator, out Guid first, [NotNullWhen(true)] out string? second) {

        if (string.IsNullOrEmpty(input)) {
            first = Guid.Empty;
            second = null;
            return false;
        }

        string[] pieces = input!.Split(separator);

        if (pieces.Length >= 2 && Guid.TryParse(pieces[0], out first)) {
            second = pieces[1];
            return true;
        }

        first = Guid.Empty;
        second = null;
        return false;

    }

}