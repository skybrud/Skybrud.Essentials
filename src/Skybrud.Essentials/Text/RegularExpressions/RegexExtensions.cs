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

}