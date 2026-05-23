using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Skybrud.Essentials.Strings.Extensions;

/// <summary>
/// Static class with various extension methods for <see cref="string"/>.
/// </summary>
public static partial class StringExtensions {

    /// <summary>
    /// Encodes a URL string.
    /// </summary>
    /// <param name="str">The string to be encoded.</param>
    /// <returns>The encoded string.</returns>
    [return: NotNullIfNotNull(nameof(str))]
    public static string? UrlEncode(this string? str) {
        return StringUtils.UrlEncode(str);
    }

    /// <summary>
    /// Decodes a URL string.
    /// </summary>
    /// <param name="str">The string to be decoded.</param>
    /// <returns>The decoded string.</returns>
    [return: NotNullIfNotNull(nameof(str))]
    public static string? UrlDecode(this string? str) {
        return StringUtils.UrlDecode(str);
    }

    /// <summary>
    /// HTML encodes the specified <paramref name="str"/>.
    /// </summary>
    /// <param name="str">The string to be encoded.</param>
    /// <returns>The encoded string.</returns>
    [return: NotNullIfNotNull(nameof(str))]
    public static string? HtmlEncode(this string? str) {
        return StringUtils.HtmlEncode(str);
    }

    /// <summary>
    /// HTML decodes the specified <paramref name="str"/>.
    /// </summary>
    /// <param name="str">The string to be decoded.</param>
    /// <returns>The decoded string.</returns>
    [return: NotNullIfNotNull(nameof(str))]
    public static string? HtmlDecode(this string? str) {
        return StringUtils.HtmlDecode(str);
    }

    /// <summary>
    /// Returns a URL encoded value of the specified <paramref name="collection"/>,
    /// </summary>
    /// <param name="collection">The name value collection.</param>
    /// <returns>The URL encoded string.</returns>
    public static string ToUrlEncodedString(this NameValueCollection? collection) {
        return StringUtils.ToUrlEncodedString(collection);
    }

    /// <summary>
    /// Returns a <see cref="NameValueCollection"/> from the specified URL <paramref name="encoded"/> string.
    /// </summary>
    /// <param name="encoded">The URL encoded string.</param>
    /// <returns>The name value collection.</returns>
    public static NameValueCollection ToNameValueCollection(this string? encoded) {
        return string.IsNullOrWhiteSpace(encoded) ? [] : System.Web.HttpUtility.ParseQueryString(encoded);
    }

    /// <summary>
    /// Counts number of words in the specified <paramref name="str"/>.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    /// <returns>An integer with the number of words found.</returns>
    public static int WordCount(this string? str) {
        return StringUtils.WordCount(str);
    }

    /// <summary>
    /// Highlights specified <paramref name="keywords"/> in the <paramref name="input"/> string with the specified
    /// <paramref name="className"/> by using a <c>&lt;span&gt;</c> element.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="className">The class name.</param>
    /// <param name="keywords">The keywords to highlight.</param>
    /// <returns>The input string with highlighted keywords.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    public static string? HighlightKeywords(this string? input, string className, IEnumerable<string>? keywords) {
        return StringUtils.HighlightKeywords(input, className, keywords);
    }

    /// <summary>
    /// Highlights specified <paramref name="keywords"/> in the <paramref name="input"/> string with the specified
    /// <paramref name="className"/> by using a <c>&lt;span&gt;</c> element.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="className">The class name.</param>
    /// <param name="keywords">The keywords to highlight.</param>
    /// <returns>The input string with highlighted keywords.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    public static string? HighlightKeywords(this string? input, string className, params string[]? keywords) {
        return StringUtils.HighlightKeywords(input, className, keywords);
    }

    /// <summary>
    /// Gets whether the <paramref name="input"/> string has a value. This extension method is equal to calling
    /// <see cref="string.IsNullOrWhiteSpace"/>.
    /// </summary>
    /// <param name="input">The input string to test.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> has a value; otherwise <see langword="false"/>.</returns>
    public static bool HasValue([NotNullWhen(true)] this string? input) {
        return string.IsNullOrWhiteSpace(input) == false;
    }

    /// <summary>
    /// Gets whether the <paramref name="input"/> string has a value.
    ///
    /// This method may be used to improve the readability of your code - e.g. instead of declaring a variable first, and then calling <see cref="HasValue(string)"/> afterwards.
    /// </summary>
    /// <param name="input">The input string to test.</param>
    /// <param name="result">When this method returns, contains the input value.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> has a value; otherwise <see langword="false"/>.</returns>
    public static bool HasValue([NotNullWhen(true)] this string? input, [NotNullWhen(true)] out string? result) {
        result = input;
        return string.IsNullOrWhiteSpace(input) == false;
    }

    /// <summary>
    /// Gets whether the <paramref name="input"/> string has a value. This extension method is equal to calling
    /// <see cref="string.IsNullOrWhiteSpace"/>.
    /// </summary>
    /// <param name="input">The input string to test.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> has a value; otherwise <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(true)] this string? input) {
        return string.IsNullOrWhiteSpace(input);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string matches a double (<see cref="double"/>).
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> matches a double; otherwise <see langword="false"/>.</returns>
    public static bool IsNumeric([NotNullWhen(true)] this string? input) {
        return StringUtils.IsNumeric(input);
    }

    /// <summary>
    /// Gets whether the specified <paramref name="input"/> string is alphanumeric - meaning it only consists of numbers and letters.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> is alphanumeric; otherwise <see langword="false"/>.</returns>
    public static bool IsAlphanumeric([NotNullWhen(true)] this string? input) {
        return StringUtils.IsAlphanumeric(input);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="input"/> string is alphabetic - meaning it only consists of letters.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> if <paramref name="input"/> is alphanumeric; otherwise <see langword="false"/>.</returns>
    public static bool IsAlphabetic([NotNullWhen(true)] this string? input) {
        return StringUtils.IsAlphabetic(input);
    }

    /// <summary>
    /// Parses string of multiple values into an array of <see cref="string"/>. Supported separators are
    /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
    ///
    /// Empty entries are automatically removed from the output array.
    /// </summary>
    /// <param name="input">The input string containing the values.</param>
    /// <returns>An array of <see cref="string"/>.</returns>
    public static string[] ToStringArray(this string? input) {
        return StringUtils.ParseStringArray(input);
    }

    /// <summary>
    /// Parses string of multiple values into an array of <see cref="string"/>, using the specified array of
    /// <paramref name="separators"/>.
    ///
    /// Empty entries are automatically removed from the output array.
    /// </summary>
    /// <param name="input">The input string containing the values.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>An array of <see cref="string"/>.</returns>
    public static string[] ToStringArray(this string? input, char[] separators) {
        return StringUtils.ParseStringArray(input, separators);
    }

    /// <summary>
    /// Parses string of multiple values into a list of <see cref="string"/>. Supported separators are
    /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
    ///
    /// Empty entries are automatically removed from the output list.
    /// </summary>
    /// <param name="input">The input string containing the values.</param>
    /// <returns>A list of <see cref="string"/>.</returns>
    public static List<string> ToStringList(this string? input) {
        return StringUtils.ParseStringList(input);
    }

    /// <summary>
    /// Parses string of multiple values into a list of <see cref="string"/>, using the specified list of
    /// <paramref name="separators"/>.
    ///
    /// Empty entries are automatically removed from the output list.
    /// </summary>
    /// <param name="input">The input string containing the values.</param>
    /// <param name="separators">A list of supported separators.</param>
    /// <returns>A list of <see cref="string"/>.</returns>
    public static List<string> ToStringList(this string? input, char[] separators) {
        return StringUtils.ParseStringList(input, separators);
    }

    /// <summary>
    /// Converts the specified string of separated values into a <see cref="HashSet{T}"/> of <see cref="string"/>.
    /// Supported separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>)
    /// and tab (<c>\t</c>).
    /// </summary>
    /// <param name="str">The input string containing the values.</param>
    /// <returns>A set of <see cref="string"/> values.</returns>
    public static HashSet<string> ToStringSet(this string? str) {
        return StringUtils.ParseStringSet(str);
    }

    /// <summary>
    /// Converts the specified string of separated values into a <see cref="HashSet{T}"/> of <see cref="string"/>, using
    /// the specified array of <paramref name="separators"/>.
    /// </summary>
    /// <param name="str">The input string containing the values.</param>
    /// <param name="separators">An array of supported separators.</param>
    /// <returns>A set of <see cref="string"/> values.</returns>
    public static HashSet<string> ToStringSet(this string? str, params char[] separators) {
        return StringUtils.ParseStringSet(str, separators);
    }

    /// <summary>
    /// If <paramref name="input"/> is longer than <paramref name="maxCharacters"/>, this method will return a
    /// truncated version of <paramref name="input"/> with <c>...</c> appended to the end, and where the overall
    /// length is exactly <paramref name="maxCharacters"/>. If the length <paramref name="input"/> is lower than or
    /// equal to <paramref name="maxCharacters"/>, <paramref name="input"/> os returned unmodified.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="maxCharacters">The maximum allowed amount of characters.</param>
    /// <returns>The truncated string if the length of <paramref name="input"/> exceeds <paramref name="maxCharacters"/>; otherwise <paramref name="input"/>.</returns>
    public static string Truncate(this string input, int maxCharacters) {
        return StringUtils.Truncate(input, maxCharacters);
    }

    /// <summary>
    /// If <paramref name="input"/> is longer than <paramref name="maxCharacters"/>, this method will return a
    /// truncated version of <paramref name="input"/> with <paramref name="end"/> appended to the end, and where the overall
    /// length is exactly <paramref name="maxCharacters"/>. If the length <paramref name="input"/> is lower than or
    /// equal to <paramref name="maxCharacters"/>, <paramref name="input"/> os returned unmodified.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="maxCharacters">The maximum allowed amount of characters.</param>
    /// <param name="end">The text to be appended to the end of the truncated string - e.g. <c>...</c>.</param>
    /// <returns>The truncated string if the length of <paramref name="input"/> exceeds <paramref name="maxCharacters"/>; otherwise <paramref name="input"/>.</returns>
    public static string Truncate(this string input, int maxCharacters, string? end) {
        return StringUtils.Truncate(input, maxCharacters, end);
    }

    /// <summary>
    /// Concatenates the string representations of each item in <paramref name="values"/>, using the specified
    /// <paramref name="separator"/> between each member.
    /// </summary>
    /// <param name="values">A collection of objects whose string representations will be concatenated.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in
    /// the returned string only if value has more than one element.</param>
    /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the
    /// <paramref name="separator"/> character, <see cref="string.Empty"/> if values has zero elements.</returns>
    public static string Join(this IEnumerable<object> values, string separator) {
        return string.Join(separator, values);
    }

    /// <summary>
    /// Concatenates the string representations of each item in <paramref name="values"/>, using the specified
    /// <paramref name="separator"/> between each member.
    /// </summary>
    /// <param name="values">A collection of objects whose string representations will be concatenated.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in
    /// the returned string only if value has more than one element.</param>
    /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the
    /// <paramref name="separator"/> character, <see cref="string.Empty"/> if values has zero elements.</returns>
    public static string Join(this IEnumerable<object> values, char separator) {
        return string.Join(separator.ToString(), values);
    }

    /// <summary>
    /// Concatenates the string representations of each item in <paramref name="values"/>, using the specified
    /// <paramref name="separator"/> between each member.
    /// </summary>
    /// <param name="values">A collection of objects whose string representations will be concatenated.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in
    /// the returned string only if value has more than one element.</param>
    /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the
    /// <paramref name="separator"/> character, <see cref="string.Empty"/> if values has zero elements.</returns>
    public static string Join<T>(this IEnumerable<T> values, string separator) {
        return string.Join(separator, values);
    }

    /// <summary>
    /// Concatenates the string representations of each item in <paramref name="values"/>, using the specified
    /// <paramref name="separator"/> between each member.
    /// </summary>
    /// <param name="values">A collection of objects whose string representations will be concatenated.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in
    /// the returned string only if value has more than one element.</param>
    /// <returns>A string that consists of the elements of <paramref name="values"/> delimited by the
    /// <paramref name="separator"/> character, <see cref="string.Empty"/> if values has zero elements.</returns>
    public static string Join<T>(this IEnumerable<T> values, char separator) {
        return string.Join(separator.ToString(), values);
    }

    /// <summary>
    /// Converts a singular word to the plural counterpart (for English words only).
    /// </summary>
    /// <param name="word">The singular word.</param>
    /// <returns>The plural word.</returns>
    public static string ToPlural(this string word) {
        return StringUtils.ToPlural(word);
    }

    /// <summary>
    /// Returns the plural counterpart of <paramref name="singular"/> if <paramref name="count"/> is exactly <c>1</c>. Works only with English words.
    /// </summary>
    /// <param name="singular">The singular word.</param>
    /// <param name="count">The count.</param>
    /// <returns>The plural word if <paramref name="count"/> is exactly <c>1</c>; otherwise <paramref name="singular"/>.</returns>
    public static string ToPlural(this string singular, int count) {
        return StringUtils.ToPlural(singular, count);
    }

    /// <summary>
    /// Returns the plural counterpart of <paramref name="singular"/> if <paramref name="condition"/> is <see langword="true"/>. Works only with English words.
    /// </summary>
    /// <param name="singular">The singular word.</param>
    /// <param name="condition">A boolean value.</param>
    /// <returns>The plural word if <paramref name="condition"/> is <see langword="true"/>; otherwise <paramref name="singular"/>.</returns>
    public static string ToPlural(this string singular, bool condition) {
        return StringUtils.ToPlural(singular, condition);
    }

    /// <summary>
    /// Converts a plural word to the singular counterpart (for English words only).
    /// </summary>
    /// <param name="word">The plural word.</param>
    /// <returns>The singular word.</returns>
    public static string ToSingular(this string word) {
        return StringUtils.ToSingular(word);
    }

    /// <summary>
    /// If the specified <paramref name="input"/> string is either <see langword="null"/> or white space, this method returns
    /// the specified <paramref name="fallback"/> value; otherwise returns the <paramref name="input"/> string
    /// untouched.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns><paramref name="fallback"/> if <paramref name="input"/> is <see langword="null"/> or white space; otherwise <paramref name="input"/>.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? IfNullOrWhiteSpace(this string? input, string? fallback) {
        return string.IsNullOrWhiteSpace(input) ? fallback : input;
    }

    /// <summary>
    /// If the specified <paramref name="input"/> string is either <see langword="null"/> or white space, this method returns
    /// value of the specified <paramref name="fallback"/> function; otherwise returns the <paramref name="input"/>
    /// string untouched.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="fallback">The fallback function.</param>
    /// <returns>The value returned by <paramref name="fallback"/> if <paramref name="input"/> is <see langword="null"/> or white space; otherwise <paramref name="input"/>.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    public static string? IfNullOrWhiteSpace(this string? input, Func<string?> fallback) {
        return string.IsNullOrWhiteSpace(input) ? fallback() : input;
    }

    /// <summary>
    /// Returns <see langword="null"/> if the specified <paramref name="input"/> string is empty or white space.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><see langword="null"/> if <paramref name="input"/> is empty or white space; otherwise <paramref name="input"/>.</returns>
    public static string? NullIfWhiteSpace(this string? input) {
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, char separator, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split(separator);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, char separator, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split(separator);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, char separator, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split(separator);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, char separator, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split(separator);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, char separator, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split(separator);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }


    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, char separator, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split([separator], options);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, char separator, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split([separator], options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, char separator, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split([separator], options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, char separator, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split([separator], options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separator"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separator">The separator to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, char separator, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split([separator], options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split(separators);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split(separators);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split(separators);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split(separators);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split(separators);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, char[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split(separators, StringSplitOptions.None);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split(separators, StringSplitOptions.None);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split(separators, StringSplitOptions.None);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split(separators, StringSplitOptions.None);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split(separators, StringSplitOptions.None);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
    }

    /// <summary>
    /// Splits the specified <paramref name="value"/> into multiple pieces using <paramref name="separators"/>.
    /// </summary>
    /// <param name="value">The value to be split.</param>
    /// <param name="separators">The separators to be used for splitting the string.</param>
    /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned; or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
    /// <param name="first">The first item resulting from the split.</param>
    /// <param name="second">The second item resulting from the split.</param>
    /// <param name="third">The third item resulting from the split.</param>
    /// <param name="fourth">The fourth item resulting from the split.</param>
    /// <param name="fifth">The fifth item resulting from the split.</param>
    public static void Split(this string? value, string[] separators, StringSplitOptions options, [NotNullIfNotNull(nameof(value))] out string? first, out string? second, out string? third, out string? fourth, out string? fifth) {
        string[]? array = value?.Split(separators, options);
        first = array?[0];
        second = array is { Length: > 1 } ? array[1] : null;
        third = array is { Length: > 2 } ? array[2] : null;
        fourth = array is { Length: > 3 } ? array[3] : null;
        fifth = array is { Length: > 4 } ? array[4] : null;
    }

    /// <summary>
    /// Returns a culture invariant string representation of the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>A culture invariant string representation of <paramref name="value"/>.</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string? ToInvariantString(this object? value) {
        return value is null ? null : string.Format(CultureInfo.InvariantCulture, "{0}", value);
    }

    /// <summary>
    /// Returns a culture invariant string representation of the specified <paramref name="value"/> formatted using <paramref name="format"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="format">The format to be used when converting <paramref name="value"/>.</param>
    /// <returns>A culture invariant string representation of <paramref name="value"/>.</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string? ToInvariantString(this IFormattable? value, string format) {
        return value?.ToString(format, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a culture invariant string representation of the specified <paramref name="value"/> formatted using <paramref name="format"/>.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="format">The format to be used when converting <paramref name="value"/>.</param>
    /// <returns>A culture invariant string representation of <paramref name="value"/>.</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string? ToInvariantString(this DateTime? value, [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format) {
        return value?.ToInvariantString(format);
    }

    /// <summary>
    /// Returns a culture invariant string representation of the specified <paramref name="value"/> formatted using <paramref name="format"/>.
    /// </summary>
    /// <param name="value">The <see cref="DateTimeOffset"/> value to convert.</param>
    /// <param name="format">The format to be used when converting <paramref name="value"/>.</param>
    /// <returns>A culture invariant string representation of <paramref name="value"/>.</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string? ToInvariantString(this DateTimeOffset? value, [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format) {
        return value?.ToInvariantString(format);
    }

    /// <summary>
    /// Returns a culture invariant string representation of the specified <paramref name="value"/> formatted using <paramref name="format"/>.
    /// </summary>
    /// <param name="value">The <see cref="TimeSpan"/> value to convert.</param>
    /// <param name="format">The format to be used when converting <paramref name="value"/>.</param>
    /// <returns>A culture invariant string representation of <paramref name="value"/>.</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string? ToInvariantString(this TimeSpan? value, [StringSyntax(StringSyntaxAttribute.TimeSpanFormat)] string format) {
        return value?.ToInvariantString(format);
    }

}