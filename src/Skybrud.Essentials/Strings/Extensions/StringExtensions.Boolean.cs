using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string representation can be converted to a logical
        /// value <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to test.</param>
        /// <returns><c>true</c> if <paramref name="input"/> can be converted to a <see cref="bool"/>; otherwise,
        /// <c>false</c>.</returns>
        public static bool IsBoolean(this string? input) {
            return StringUtils.TryParseBoolean(input, out bool _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string representation can be converted to a logical
        /// value <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains <c>true</c>. If the
        /// conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool IsBoolean(this string? input, out bool result) {
            return StringUtils.TryParseBoolean(input, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string representation can be converted to a logical
        /// value <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains <c>true</c>. If the
        /// conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool IsBoolean(this string? input, [NotNullWhen(true)] out bool? result) {
            return StringUtils.TryParseBoolean(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or
        /// <c>on</c> (case insensitive); otherwise, <c>false</c>.</returns>
        public static bool ToBoolean(this string? input) {
            return StringUtils.ParseBoolean(input, false);
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
        public static bool ToBoolean(this string? input, bool fallback) {
            return StringUtils.ParseBoolean(input, fallback);
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
        public static bool? ToBooleanOrNull(this string? input) {
            return StringUtils.ParseBooleanOrNull(input);
        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains <c>true</c>. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBoolean(this string? input, out bool result) {
            return StringUtils.TryParseBoolean(input, out result);
        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains <c>true</c>. If the conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBoolean(this string? input, [NotNullWhen(true)] out bool? result) {
            return StringUtils.TryParseBoolean(input, out result);
        }

    }

}