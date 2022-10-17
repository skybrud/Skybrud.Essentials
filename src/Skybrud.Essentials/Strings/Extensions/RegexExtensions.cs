#nullable enable

using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Skybrud.Essentials.Strings.Extensions {

    /// <summary>
    /// Class with extension methods for working with regular expressions.
    /// </summary>
    public static class RegexExtensions {

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="match">The match.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string input, [RegexPattern] string pattern, out Match match) {
            return RegexUtils.IsMatch(input, pattern, out match);
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="match">The match.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string input, [RegexPattern] string pattern, RegexOptions options, out Match match) {
            return RegexUtils.IsMatch(input, pattern, options, out match);
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string input, [RegexPattern] string pattern, out MatchCollection matches) {
            return RegexUtils.IsMatch(input, pattern, out matches);
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string input, [RegexPattern] string pattern, RegexOptions options, out MatchCollection matches) {
            return RegexUtils.IsMatch(input, pattern, options, out matches);
        }

    }

}