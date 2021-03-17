using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Utility class with various static helper methods for working with strings.
    /// </summary>
    public static partial class StringUtils {

        /// <summary>
        /// Parses string of multiple values into an array of <see cref="string"/>. Supported separators are
        /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
        /// 
        /// Empty entries are automatically removed from the output array.
        /// </summary>
        /// <param name="str">The string containing the values.</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static string[] ParseStringArray(string str) {
            return ParseStringArray(str, ',', ' ', '\r', '\n', '\t');
        }

        /// <summary>
        /// Parses string of multiple values into an array of <see cref="string"/>, using the specified array of
        /// <paramref name="separators"/>.
        /// 
        /// Empty entries are automatically removed from the output array.
        /// </summary>
        /// <param name="str">The string containing the values.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static string[] ParseStringArray(string str, params char[] separators) {
            return str == null ? new string[0] : str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        
        /// <summary>
        /// Converts a singular word to the plural counterpart (for English words only).
        /// </summary>
        /// <param name="word">The singular word.</param>
        /// <returns>The plural word.</returns>
        public static string ToPlural(string word) {

            // Declare a list of rules
            var rules = new[] {
                new { Pattern = "mouse$", Replacement = "mice" },
                new { Pattern = "bus$", Replacement = "buses" },
                new { Pattern = "index$", Replacement = "indeces" },
                new { Pattern = "radius$", Replacement = "radii" },
                new { Pattern = "quiz$", Replacement = "quizzes" },
                new { Pattern = "phenomenon$", Replacement = "phenomena" },
                new { Pattern = "bacterium$", Replacement = "bacteria" },
                new { Pattern = "seraph$", Replacement = "seraphim" },
                new { Pattern = "chateau$", Replacement = "chateaux" },
                new { Pattern = "(x|ch|ss|sh)$", Replacement = "$1es" }, // search, switch, fix, box, process, address
                new { Pattern = "series$", Replacement = "series" },
                new { Pattern = "([^aeiouy]|qu)y$", Replacement = "$1ies" }, // query, ability, agency
                new { Pattern = "(?:([^f])fe|([lr])f)$", Replacement = "$1$2ves" }, // half, safe, wife
                new { Pattern = "sis$", Replacement = "ses" }, // basis, diagnosis
                new { Pattern = "([ti])um$", Replacement = "$1a" }, // datum, medium
                new { Pattern = "person$", Replacement = "people" }, // person, salesperson
                new { Pattern = "man$", Replacement = "men" }, // man, woman, spokesman
                new { Pattern = "child$", Replacement = "children" }, // child
                new { Pattern = "(.*)status$", Replacement = "$1statuses" },
                new { Pattern = "s$", Replacement = "s" }, // no change (compatibility)
                new { Pattern = "$", Replacement = "s" }
            };

            // Iterate through each rule, and if it matches, do the replacement
            foreach (var rule in rules.Where(rule => Regex.IsMatch(word, rule.Pattern))) {
                return Regex.Replace(word, rule.Pattern, rule.Replacement);
            }

            return word;

        }

        /// <summary>
        /// Converts a plural word to the singular counterpart (for English words only).
        /// </summary>
        /// <param name="word">The plural word.</param>
        /// <returns>The singular word.</returns>
        public static string ToSingular(string word) {

            // Declare a list of rules
            var rules = new[] {
                new { Pattern = "mice$", Replacement = "mouse" },
                new { Pattern = "indeces$", Replacement = "index" },
                new { Pattern = "radii$", Replacement = "radius" },
                new { Pattern = "quizzes$", Replacement = "quiz" },
                new { Pattern = "phenomena$", Replacement = "phenomenon" },
                new { Pattern = "bacteria$", Replacement = "bacterium" },
                new { Pattern = "seraphim$", Replacement = "seraph" },
                new { Pattern = "chateaux$", Replacement = "chateau" },
                new { Pattern = "statuses", Replacement = "status" },
                new { Pattern = "people$", Replacement = "person" },
                new { Pattern = "(buses|busses)$", Replacement = "bus" },
                new { Pattern = "children$", Replacement = "child" },
                new { Pattern = "men$", Replacement = "man" }, // men, women, spokesmen
                new { Pattern = "(halves)$", Replacement = "half" },
                new { Pattern = "(sa|wi)ves$", Replacement = "$1fe" },
                new { Pattern = "(mov|ser)ies$", Replacement = "$1ie" },
                new { Pattern = "([^aeiouy]|qu)ies$", Replacement = "$1y" }, // queries, abilities, agencies
                new { Pattern = "esses$", Replacement = "ess" },
                new { Pattern = "ses$", Replacement = "sis" },
                new { Pattern = "([ti])a$", Replacement = "$1um" }, // data, media
                new { Pattern = "(x|ch|ss|sh)es$", Replacement = "$1" }, // searches, switches, fixes, boxes, processes, addresses
                new { Pattern = "es", Replacement = "e" },
                new { Pattern = "s$", Replacement = string.Empty },
            };

            // Iterate through each rule, and if it matches, do the replacement
            foreach (var rule in rules.Where(rule => Regex.IsMatch(word, rule.Pattern))) {
                return Regex.Replace(word, rule.Pattern, rule.Replacement);
            }

            return word;

        }

        /// <summary>
        /// Counts number of words in the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <returns>An integer with the number of words found.</returns>
        public static int WordCount(string str) {

            // See: http://stackoverflow.com/a/8784654

            // Trim the text a bit
            str = str.Trim();
            
            int count = 0, index = 0;

            while (index < str.Length) {
                
                // Check if current char is part of a word
                while (index < str.Length && !char.IsWhiteSpace(str[index])) index++;

                // Increment the counter
                count++;

                // Skip whitespace until next word
                while (index < str.Length && char.IsWhiteSpace(str[index])) index++;
            
            }

            return count;
        
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
            if (string.IsNullOrWhiteSpace(input) || keywords == null) return input;
            return HighlightKeywords(input, className, keywords.ToArray());
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

            if (string.IsNullOrWhiteSpace(input) || keywords == null) return input;

            // Loop through the keywords
            foreach (string keyword in keywords) {
                input = Regex.Replace(input, keyword, string.Format("<span class=\"{1}\">{0}</span>", "$0", className), RegexOptions.IgnoreCase);
            }

            return input;

        }

        /// <summary>
        /// Alias of <see cref="IsDouble"/>. Gets whether the string matches a double (<see cref="double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a double; otherwise <c>false</c>.</returns>
        public static bool IsNumeric(string str) {
            return long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out long _);
        }

        /// <summary>
        /// Gets whether the specified string is alphanumeric - meaning it only consists of numbers and letters.
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> is alphanumeric; otherwise <c>false</c>.</returns>
        public static bool IsAlphanumeric(string str) {
            return Regex.IsMatch(str ?? string.Empty, "^[0-9a-zA-Z]+$");
        }

        /// <summary>
        /// Returns whether the specified <paramref name="value"/> is alphabetic - meaning it only consists of letters.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is alphanumeric; otherwise <c>false</c>.</returns>
        public static bool IsAlphabetic(string value)  {
            return Regex.IsMatch(value ?? string.Empty, "^[a-zA-Z]+$");
        }

        /// <summary>
        /// Computes the Levenshtein distance between two strings.
        ///
        /// The Levenshtein distance is defined as the minimal number of characters you have to replace, insert or delete to transform <paramref name="s"/> into <paramref name="t"/>.
        /// </summary>
        /// <param name="s">The first string.</param>
        /// <param name="t">The second string.</param>
        /// <returns>The Levenshtein distance between <paramref name="s"/> into <paramref name="t"/>.</returns>
        /// <see>
        ///     <cref>http://www.dotnetperls.com/levenshtein</cref>
        /// </see>
        public static int Levenshtein(string s, string t) {
            
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Verify arguments
            if (n == 0) return m;
            if (m == 0) return n;

            // Initialize arrays
            for (int i = 0; i <= n; d[i, 0] = i++) { }
            for (int j = 0; j <= m; d[0, j] = j++) { }

            // Begin looping
            for (int i = 1; i <= n; i++) {
                
                for (int j = 1; j <= m; j++) {

                    // Compute the cost
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);

                }

            }

            // Return the cost
            return d[n, m];

        }

#if NET_FRAMEWORK

        /// <summary>
        /// URL encodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The URL encoded string.</returns>
        public static string UrlEncode(string str) {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The URL decoded string.</returns>
        public static string UrlDecode(string str) {
			return System.Web.HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// HTML encodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string HtmlEncode(string str) {
            return System.Web.HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// HTML decodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The decoded string.</returns>
        public static string HtmlDecode(string str) {
            return System.Web.HttpUtility.HtmlDecode(str);
        }

#endif

#if NET_STANDARD

		/// <summary>
		/// URL encodes the specified <paramref name="str"/>.
		/// </summary>
		/// <param name="str">The string to be encoded.</param>
		/// <returns>The URL encoded string.</returns>
        public static string UrlEncode(string str) {
            return System.Net.WebUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The URL decoded string.</returns>
        public static string UrlDecode(string str) {
			return System.Net.WebUtility.UrlDecode(str);
        }

        /// <summary>
        /// HTML encodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>The encoded string.</returns>
        public static string HtmlEncode(string str) {
            return System.Net.WebUtility.HtmlEncode(str);
        }

        /// <summary>
        /// HTML decodes the specified <paramref name="str"/>.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>The decoded string.</returns>
        public static string HtmlDecode(string str) {
            return System.Net.WebUtility.HtmlDecode(str);
        }

#endif
		
        /// <summary>
        /// Strips all HTML elements from the specified <paramref name="html"/> string.
        /// </summary>
        /// <param name="html">The input string containing the HTML.</param>
        /// <returns>The input string without any HTML markup.</returns>
        public static string StripHtml(string html) {
            return HtmlDecode(Regex.Replace(html, "<.*?>", string.Empty));
        }

        /// <summary>
        /// Strips all HTML elements from the specified <paramref name="html"/> string, but keeps the HTML tags as
        /// specified in <paramref name="ignore"/>.
        /// </summary>
        /// <param name="html">The input string containing the HTML.</param>
        /// <param name="ignore">An of tag names (without the brackets, like <c>div</c>) to ignore.</param>
        /// <returns>The stripped result.</returns>
        public static string StripHtml(string html, params string[] ignore) {
            if (ignore == null || ignore.Length == 0) return StripHtml(html);
            Regex regex = new Regex("<(?!(" + string.Join("|", from tag in ignore select "/?" + tag) + ")\\b)[^>]*>", RegexOptions.Singleline);
            return HtmlDecode(regex.Replace(html, string.Empty));
        }
        
        /// <summary>
        /// HTML encodes the text and replaces text line breaks with HTML line breaks.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns> The HTML encoded text with text line breaks replaced with HTML line breaks (<c>&lt;br /&gt;</c>).</returns>
        public static string ReplaceLineBreaks(string input) {

            // See: https://github.com/umbraco/Umbraco-CMS/blob/release-8.12.0/src/Umbraco.Web/HtmlStringUtilities.cs#L38

            string value = HtmlEncode(input)?
                .Replace("\r\n", "<br />")
                .Replace("\r", "<br />")
                .Replace("\n", "<br />");

            return value;

        }

    }

}