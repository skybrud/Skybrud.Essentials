using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Text.RegularExpressions;

/// <summary>
/// Static class with various extension methods for the <see cref="Regex"/> class.
/// </summary>
public static class RegexExtensions {

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="match">Holds an instance of <see cref="Match"/> representing the matches values.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string? input, out Match match) {
        match = regex.Match(input ?? string.Empty);
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result2">When this method returns, holds the value of the match group with index <c>2</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1, out string result2) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        result2 = match.Groups[2].Value;
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result2">When this method returns, holds the value of the match group with index <c>2</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result3">When this method returns, holds the value of the match group with index <c>3</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1, out string result2, out string result3) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        result2 = match.Groups[2].Value;
        result3 = match.Groups[3].Value;
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result2">When this method returns, holds the value of the match group with index <c>2</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result3">When this method returns, holds the value of the match group with index <c>3</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result4">When this method returns, holds the value of the match group with index <c>4</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1, out string result2, out string result3, out string result4) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        result2 = match.Groups[2].Value;
        result3 = match.Groups[3].Value;
        result4 = match.Groups[4].Value;
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result2">When this method returns, holds the value of the match group with index <c>2</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result3">When this method returns, holds the value of the match group with index <c>3</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result4">When this method returns, holds the value of the match group with index <c>4</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result5">When this method returns, holds the value of the match group with index <c>5</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1, out string result2, out string result3, out string result4, out string result5) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        result2 = match.Groups[2].Value;
        result3 = match.Groups[3].Value;
        result4 = match.Groups[4].Value;
        result5 = match.Groups[5].Value;
        return match.Success;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches the regular expression.
    /// </summary>
    /// <param name="regex">The regular expression.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="result1">When this method returns, holds the value of the match group with index <c>1</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result2">When this method returns, holds the value of the match group with index <c>2</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result3">When this method returns, holds the value of the match group with index <c>3</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result4">When this method returns, holds the value of the match group with index <c>4</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result5">When this method returns, holds the value of the match group with index <c>5</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <param name="result6">When this method returns, holds the value of the match group with index <c>6</c>, or an empty string if the match group doesn't exist or the input string didn't match.</param>
    /// <returns><see langword="true"/> if the input string matches; otherwise, <see langword="false"/>.</returns>
    public static bool IsMatch(this Regex regex, string input, out string result1, out string result2, out string result3, out string result4, out string result5, out string result6) {
        Match match = regex.Match(input);
        result1 = match.Groups[1].Value;
        result2 = match.Groups[2].Value;
        result3 = match.Groups[3].Value;
        result4 = match.Groups[4].Value;
        result5 = match.Groups[5].Value;
        result6 = match.Groups[6].Value;
        return match.Success;
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string replacement) {
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string replacement, RegexOptions options) {
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout) {
        return Regex.Replace(input, pattern, replacement, options);
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, MatchEvaluator evaluator) {
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, MatchEvaluator evaluator, RegexOptions options) {
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
    public static string Replace(this string input, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, MatchEvaluator evaluator, RegexOptions options, TimeSpan matchTimeout) {
        return Regex.Replace(input, pattern, evaluator, options);
    }

}