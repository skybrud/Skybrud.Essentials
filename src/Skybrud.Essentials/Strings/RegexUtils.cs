using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Skybrud.Essentials.Strings.Extensions;

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
        public static bool IsMatch(string input, [RegexPattern] string pattern, out Match match) {
            match = Regex.Match(input ?? string.Empty, pattern);
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out string result1) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out string result1, out string result2) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out string result1, out string result2, out string result3) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out string result1, out string result2, out string result3, out string result4) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            result4 = match.Groups[4].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <param name="result5">The value of the fifth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out string result1, out string result2, out string result3, out string result4, out string result5) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            result4 = match.Groups[4].Value;
            result5 = match.Groups[5].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out int result1) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out int result1, out int result2) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out int result1, out int result2, out int result3) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out int result1, out int result2, out int result3, out int result4) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            result4 = match.Groups[4].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <param name="result5">The value of the fifth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out int result1, out int result2, out int result3, out int result4, out int result5) {
            Match match = Regex.Match(input ?? string.Empty, pattern);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            result4 = match.Groups[4].Value.ToInt32();
            result5 = match.Groups[5].Value.ToInt32();
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
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out Match match) {
            match = Regex.Match(input ?? string.Empty, pattern, options);
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out string result1) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out string result1, out string result2) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out string result1, out string result2, out string result3) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out string result1, out string result2, out string result3, out string result4) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            result4 = match.Groups[4].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <param name="result5">The value of the fifth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out string result1, out string result2, out string result3, out string result4, out string result5) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value;
            result2 = match.Groups[2].Value;
            result3 = match.Groups[3].Value;
            result4 = match.Groups[4].Value;
            result5 = match.Groups[5].Value;
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out int result1) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out int result1, out int result2) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out int result1, out int result2, out int result3) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out int result1, out int result2, out int result3, out int result4) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            result4 = match.Groups[4].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="result1">The value of the first group.</param>
        /// <param name="result2">The value of the second group.</param>
        /// <param name="result3">The value of the third group.</param>
        /// <param name="result4">The value of the fourth group.</param>
        /// <param name="result5">The value of the fifth group.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out int result1, out int result2, out int result3, out int result4, out int result5) {
            Match match = Regex.Match(input ?? string.Empty, pattern, options);
            result1 = match.Groups[1].Value.ToInt32();
            result2 = match.Groups[2].Value.ToInt32();
            result3 = match.Groups[3].Value.ToInt32();
            result4 = match.Groups[4].Value.ToInt32();
            result5 = match.Groups[5].Value.ToInt32();
            return match.Success;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of <paramref name="match"/>.</typeparam>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="match">When this method returns, holds an instance of <typeparamref name="TMatch"/> if successful; otherwise, the default value of <typeparamref name="TMatch"/>.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, out TMatch match) {

            Match m = Regex.Match(input ?? string.Empty, pattern);

            if (!m.Success) {
                match = default;
                return false;
            }

            match = (TMatch) Activator.CreateInstance(typeof(TMatch), m);
            return true;

        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of <paramref name="match"/>.</typeparam>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="match">When this method returns, holds an instance of <typeparamref name="TMatch"/> if successful; otherwise, the default value of <typeparamref name="TMatch"/>.</param>
        /// <returns><c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, RegexOptions options, out TMatch match) {

            Match m = Regex.Match(input ?? string.Empty, pattern, options);

            if (!m.Success) {
                match = default;
                return false;
            }

            match = (TMatch) Activator.CreateInstance(typeof(TMatch), m);
            return true;

        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, out MatchCollection matches) {
            matches = Regex.Matches(input ?? string.Empty, pattern);
            return matches.Count > 0;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds any matches in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matches">The matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(string input, [RegexPattern] string pattern, RegexOptions options, out MatchCollection matches) {
            matches = Regex.Matches(input ?? string.Empty, pattern, options);
            return matches.Count > 0;
        }

        /// <summary>
        /// Returns whether the specified regular expression finds one or more matches in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of each match.</typeparam>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="matches">When this method returns, holds a collection of <typeparamref name="TMatch"/> representing the found matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, out IEnumerable<TMatch> matches) {

            MatchCollection m = Regex.Matches(input ?? string.Empty, pattern);

            matches = (
                from Match match in m
                select (TMatch) Activator.CreateInstance(typeof(TMatch), match)
            ).ToList();

            return m.Count > 0;

        }

        /// <summary>
        /// Returns whether the specified regular expression finds one or more matches in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of each match.</typeparam>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="matches">When this method returns, holds an array of <typeparamref name="TMatch"/> representing the found matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, out TMatch[] matches) {

            MatchCollection m = Regex.Matches(input ?? string.Empty, pattern);

            TMatch[] array = new TMatch[m.Count];

            for (int i = 0; i < m.Count; i++) {
                array[i] = (TMatch) Activator.CreateInstance(typeof(TMatch), m[i]);
            }

            matches = array;

            return m.Count > 0;

        }

        /// <summary>
        /// Returns whether the specified regular expression finds one or more matches in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of each match.</typeparam>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matches">When this method returns, holds a collection of <typeparamref name="TMatch"/> representing the found matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, RegexOptions options, out IEnumerable<TMatch> matches) {

            MatchCollection m = Regex.Matches(input ?? string.Empty, pattern, options);

            matches = (
                from Match match in m
                select (TMatch) Activator.CreateInstance(typeof(TMatch), match)
            ).ToList();

            return m.Count > 0;

        }

        /// <summary>
        /// Returns whether the specified regular expression finds one or more matches in the specified input string.
        /// </summary>
        /// <typeparam name="TMatch">The type of each match.</typeparam>
        /// <param name="input">The string to search for matches.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <param name="matches">When this method returns, holds an array of <typeparamref name="TMatch"/> representing the found matches.</param>
        /// <returns><c>true</c> if the regular expression finds any matches; otherwise, <c>false</c>.</returns>
        public static bool IsMatch<TMatch>(string input, [RegexPattern] string pattern, RegexOptions options, out TMatch[] matches) {

            MatchCollection m = Regex.Matches(input ?? string.Empty, pattern, options);

            TMatch[] array = new TMatch[m.Count];

            for (int i = 0; i < m.Count; i++) {
                array[i] = (TMatch) Activator.CreateInstance(typeof(TMatch), m[i]);
            }

            matches = array;

            return m.Count > 0;

        }

    }

}