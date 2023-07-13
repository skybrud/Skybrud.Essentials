using System;
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

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="replacement"/> is <see langword="null"/>.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, string replacement) {
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="replacement"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="options"/> is not a valid bitwise combination of <see cref="RegexOptions"/> values.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, string replacement, RegexOptions options) {
            return Regex.Replace(input, pattern, replacement, options);
        }

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Additional parameters specify options that modify the matching operation and a time-out interval if no match is found.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matchTimeout">A time-out interval, or <see cref="Regex.InfiniteMatchTimeout"/> to indicate that the method should not time out.</param>
        /// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="replacement"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">options is not a valid bitwise combination of System.Text.RegularExpressions.RegexOptions values.-or-matchTimeout is negative, zero, or greater than approximately 24 days.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout) {
            return Regex.Replace(input, pattern, replacement, options, matchTimeout);
        }

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with a string returned by a <see cref="MatchEvaluator"/> delegate.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="evaluator"/> is <see langword="null"/>.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, MatchEvaluator evaluator) {
            return Regex.Replace(input, pattern, evaluator);
        }

        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular expression with a string returned by a <see cref="MatchEvaluator"/> delegate. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns>A new string that is identical to the input string, except that a replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="evaluator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">options is not a valid bitwise combination of <see cref="RegexOptions"/> values.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, MatchEvaluator evaluator, RegexOptions options) {
            return Regex.Replace(input, pattern, evaluator, options);
        }

        /// <summary>
        /// In a specified input string, replaces all substrings that match a specified regular expression with a string returned by a <see cref="MatchEvaluator"/> delegate. Additional parameters specify options that modify the matching operation and a time-out interval if no match is found.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <param name="options">A bitwise combination of enumeration values that provide options for matching.</param>
        /// <param name="matchTimeout">A time-out interval, or System.Text.RegularExpressions.Regex.InfiniteMatchTimeout to indicate that the method should not time out.</param>
        /// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="input"/>, <paramref name="pattern"/>, or <paramref name="evaluator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">options is not a valid bitwise combination of <see cref="RegexOptions"/> values.-or-<paramref name="matchTimeout"/> is negative, zero, or greater than approximately 24 days.</exception>
        /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
        public static string RegexReplace(this string input, [RegexPattern] string pattern, MatchEvaluator evaluator, RegexOptions options, TimeSpan matchTimeout) {
            return Regex.Replace(input, pattern, evaluator, options, matchTimeout);
        }

    }

}