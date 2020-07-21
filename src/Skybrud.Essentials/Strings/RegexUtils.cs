using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Utility class with various static helper methods for working with regular expressions.
    /// </summary>
    public static class RegexUtils {

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="match">The match.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, string pattern, out Match match) {
            match = Regex.Match(input ?? string.Empty, pattern);
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="match">The match.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, string pattern, RegexOptions options, out Match match) {
            match = Regex.Match(input ?? string.Empty, pattern, options);
            return match != null && match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, string pattern, out MatchCollection matches) {
            matches = Regex.Matches(input ?? string.Empty, pattern);
            return matches != null && matches.Count > 0;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, string pattern, RegexOptions options, out MatchCollection matches) {
            matches = Regex.Matches(input ?? string.Empty, pattern, options);
            return matches != null && matches.Count > 0;
        }

    }

}