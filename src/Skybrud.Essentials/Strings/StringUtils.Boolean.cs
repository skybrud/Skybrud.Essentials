#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Converts the specified <paramref name="input"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or
        /// <c>on</c> (case insensitive); otherwise, <c>false</c>.</returns>
        public static bool ParseBoolean(string? input) {
            return TryParseBoolean(input, out bool result) ? result : default;
        }

        /// <summary>
        /// Converts <paramref name="input"/> into an instance of <see cref="bool"/>. The input string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="input"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(string? input, bool fallback) {
            return TryParseBoolean(input, out bool result) ? result : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The value
        /// is considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case
        /// insensitive).
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>
        /// (case insensitive); otherwise, <c>false</c>.</returns>
        public static bool ParseBoolean(object? value) {
            return ParseBoolean(value?.ToString() ?? string.Empty);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="value"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(object? value, bool fallback) {
            return ParseBoolean(value?.ToString() ?? string.Empty, fallback);
        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBoolean(string? input, out bool result) {

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
                    result = false;
                    return false;

            }

        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
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

}