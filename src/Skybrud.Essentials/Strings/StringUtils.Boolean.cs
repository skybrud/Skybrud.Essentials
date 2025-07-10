using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings;

public static partial class StringUtils {

    /// <summary>
    /// Converts the specified <paramref name="input"/> into an instance of <see cref="bool"/>. The string is
    /// considered <see langword="true"/> if it matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c> (case-insensitive).
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches either <see langword="true"/>, <c>1</c>, <c>t</c> or
    /// <c>on</c> (case-insensitive); otherwise, <see langword="false"/>.</returns>
    public static bool ParseBoolean(string? input) {
        return TryParseBoolean(input, out bool result) && result;
    }

    /// <summary>
    /// Converts <paramref name="input"/> into an instance of <see cref="bool"/>. The input string is
    /// considered <see langword="true"/> if it matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c>, or <see langword="false"/>
    /// if it matches either <see langword="false"/>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case-insensitive.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c>,
    /// <see langword="false"/> if <paramref name="input"/> matches either <see langword="false"/>, <c>0</c>, <c>f</c> or <c>off</c>. For
    /// all other values, <paramref name="fallback"/> is returned instead.</returns>
    public static bool ParseBoolean(string? input, bool fallback) {
        return TryParseBoolean(input, out bool result) ? result : fallback;
    }

    /// <summary>
    /// Converts the specified <paramref name="input"/> into an instance of <see cref="bool"/>. The method checks
    /// against a number of known string values that either represent a <see langword="true"/> value or a
    /// <see langword="false"/> value. If the parsing fails, <see langword="null"/> will be returned instead.
    /// </summary>
    /// <param name="input">The string to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a string value that is known to
    /// represent a <see langword="true"/> value; <see langword="false"/> if <paramref name="input"/> matches a
    /// string value that is known to represent a <see langword="false"/>; or if not recognized,
    /// <see langword="null"/>.</returns>
    public static bool? ParseBooleanOrNull(string? input) {
        return TryParseBoolean(input, out bool result) ? result : null;
    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The value
    /// is considered <see langword="true"/> if it matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c> (case-insensitive).
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c>
    /// (case-insensitive); otherwise, <see langword="false"/>.</returns>
    public static bool ParseBoolean(object? value) {
        return ParseBoolean(value?.ToString());
    }

    /// <summary>
    /// Converts the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The string is
    /// considered <see langword="true"/> if it matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c>, or <see langword="false"/>
    /// if it matches either <see langword="false"/>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case-insensitive.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> matches either <see langword="true"/>, <c>1</c>, <c>t</c> or <c>on</c>,
    /// <see langword="false"/> if <paramref name="value"/> matches either <see langword="false"/>, <c>0</c>, <c>f</c> or <c>off</c>. For
    /// all other values, <paramref name="fallback"/> is returned instead.</returns>
    public static bool ParseBoolean(object? value, bool fallback) {
        return ParseBoolean(value?.ToString() ?? string.Empty, fallback);
    }

    /// <summary>
    /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
    /// </summary>
    /// <param name="input">A string containing the value to convert.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseBoolean(string? input, out bool result) {

        switch (input?.ToLower()) {

            case "true":
            case "1":
            case "t":
            case "on":
            case "yes":
            case "y":
                result = true;
                return true;

            case "false":
            case "0":
            case "f":
            case "off":
            case "no":
            case "n":
                result = false;
                return true;

            default:
                result = false;
                return false;

        }

    }

    /// <summary>
    /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
    /// </summary>
    /// <param name="input">A string containing the value to convert.</param>
    /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if value was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParseBoolean(string? input, [NotNullWhen(true)] out bool? result) {

        switch (input?.ToLower()) {

            case "true":
            case "1":
            case "t":
            case "on":
                result = true;
                return true;

            case "false":
            case "0":
            case "f":
            case "off":
                result = false;
                return true;

            default:
                result = null;
                return false;

        }

    }

}