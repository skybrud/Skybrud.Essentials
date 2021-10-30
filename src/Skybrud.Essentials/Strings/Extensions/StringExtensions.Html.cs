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

        /// <summary>
        /// HTML encodes the text and replaces text line breaks with HTML line breaks.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns> The HTML encoded text with text line breaks replaced with HTML line breaks (<c>&lt;br /&gt;</c>).</returns>
        public static string ReplaceLineBreaks(this string input) {
            return StringUtils.ReplaceLineBreaks(input);
        }
        
#if NET_FRAMEWORK

        /// <summary>
        /// Returns a new <see cref="System.Web.IHtmlString"/> wrapping the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be wrapped.</param>
        /// <returns>An instance of <see cref="System.Web.IHtmlString"/>.</returns>
        public static System.Web.IHtmlString ToHtmlString(this string input) {
            return new  System.Web.HtmlString(input ?? string.Empty);
        }

#endif

    }

}