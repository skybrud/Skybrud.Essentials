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
        /// Strips all HTML elements from the specified <paramref name="html"/> string.
        /// </summary>
        /// <param name="html">The input string containing HTML.</param>
        /// <returns>The input string without HTML markup.</returns>
        public static string StripHtml(this string html) {
            return StringUtils.StripHtml(html);
        }

        /// <summary>
        /// Strips all HTML elements from the specified <paramref name="html"/> string, but keeps the HTML tags as
        /// specified in <paramref name="ignore"/>.
        /// </summary>
        /// <param name="html">The input string containing the HTML.</param>
        /// <param name="ignore">An of tag names (without the brackets, like <c>div</c>) to ignore.</param>
        /// <returns>The stripped result.</returns>
        public static string StripHtml(this string html, params string[] ignore) {
            return StringUtils.StripHtml(html, ignore);
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
        /// Gets whether the <paramref name="input"/> string has a value. This extension method is equal to calling
        /// <see cref="string.IsNullOrWhiteSpace"/>.
        /// </summary>
        /// <param name="input">The input string to test.</param>
        /// <returns><c>true</c> if <paramref name="input"/> has a value; otherwise <c>false</c>.</returns>
        public static bool IsNullOrWhiteSpace(this string input) {
            return string.IsNullOrWhiteSpace(input);
        }

    }

}