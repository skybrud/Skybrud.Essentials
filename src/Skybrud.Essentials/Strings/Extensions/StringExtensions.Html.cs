namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {
      
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

    }

}