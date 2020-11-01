namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Converts <paramref name="str"/> into an instance of <see cref="bool"/>. The input string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).</returns>
        public static bool ToBoolean(this string str) {
            return StringUtils.ParseBoolean(str, false);
        }

        /// <summary>
        /// Converts <paramref name="str"/> into an instance of <see cref="bool"/>. The input string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="str"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(this string str, bool fallback) {
            return StringUtils.ParseBoolean(str, fallback);
        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="value">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains <c>true</c>. If the conversion failed, contains <c></c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool IsBoolean(this string value, out bool result) {
            return StringUtils.TryParseBoolean(value, out result);
        }

    }

}