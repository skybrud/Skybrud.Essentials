using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Strings.Extensions {

    /// <summary>
    /// Static class with various extension methods for <see cref="String"/>.
    /// </summary>
    public static partial class StringExtensions {
        
        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string UrlEncode(this string str) {
            return StringUtils.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The decoded string.</returns>
        public static string UrlDecode(this string str) {
            return StringUtils.UrlDecode(str);
        }

        /// <summary>
        /// HTML encodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string HtmlEncode(this string str) {
            return StringUtils.HtmlEncode(str);
        }

        /// <summary>
        /// HTML decodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The decoded string.</returns>
        public static string HtmlDecode(this string str) {
            return StringUtils.HtmlDecode(str);
        }

        /// <summary>
        /// Counts number of words in the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <returns>An integer with the number of words found.</returns>
        public static int WordCount(this string str) {
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
        public static string HighlightKeywords(string input, string className, IEnumerable<string> keywords) {
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
        public static string HighlightKeywords(string input, string className, params string[] keywords) {
            return StringUtils.HighlightKeywords(input, className, keywords);
        }

        /// <summary>
        /// Gets whether the <paramref name="input"/> string has a value. This extension method is equal to calling
        /// <see cref="string.IsNullOrWhiteSpace"/>.
        /// </summary>
        /// <param name="input">The input string to test.</param>
        /// <returns><c>true</c> if <paramref name="input"/> has a value; otherwise <c>false</c>.</returns>
        public static bool HasValue(this string input) {
            return string.IsNullOrWhiteSpace(input) == false;
        }

        /// <summary>
        /// Gets whether the <paramref name="input"/> string has a value.
        ///
        /// This method may be use to improve the readability of your code - eg. instead of declaring a variable first, and then calling <see cref="HasValue(string)"/> afterwards.
        /// </summary>
        /// <param name="input">The input string to test.</param>
        /// <param name="result">When this method returns, contains the input value.</param>
        /// <returns><c>true</c> if <paramref name="input"/> has a value; otherwise <c>false</c>.</returns>
        public static bool HasValue(this string input, out string result) {
            result = input;
            return string.IsNullOrWhiteSpace(input) == false;
        }

        /// <summary>
        /// Gets whether the <paramref name="input"/> string has a value. This extension method is equal to calling
        /// <see cref="string.IsNullOrWhiteSpace"/>.
        /// </summary>
        /// <param name="input">The input string to test.</param>
        /// <returns><c>true</c> if <paramref name="input"/> has a value; otherwise <c>false</c>.</returns>
        public static bool IsNullOrWhiteSpace(this string input) {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a double (<see cref="double"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a double; otherwise <c>false</c>.</returns>
        public static bool IsNumeric(this string input) {
            return StringUtils.IsNumeric(input);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="input"/> string is alphanumeric - meaning it only consists of numbers and letters.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> is alphanumeric; otherwise <c>false</c>.</returns>
        public static bool IsAlphanumeric(this string input) {
            return StringUtils.IsAlphanumeric(input);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string is alphabetic - meaning it only consists of letters.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> is alphanumeric; otherwise <c>false</c>.</returns>
        public static bool IsAlphabetic(this string input)  {
            return StringUtils.IsAlphabetic(input);
        }

    }

}