namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).</returns>
        public static bool ParseBoolean(string str) {
            return TryParseBoolean(str, out bool result) ? result : default;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="str"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(string str, bool fallback) {
            return TryParseBoolean(str, out bool result) ? result : fallback;
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The value
        /// is considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).</returns>
        public static bool ParseBoolean(object value) {
            return ParseBoolean(value?.ToString() ?? string.Empty);
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="bool"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="value"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(object value, bool fallback) {
            return ParseBoolean(value?.ToString() ?? string.Empty, fallback);
        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>false</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBoolean(string input, out bool result) {

            switch (input?.ToLower()) {

                case "true":
                case "1":
                case "t":
                case "on":
                    result = true;
                    return true;

                case "false":
                case "0":
                case "f":
                case "off":
                    result = false;
                    return true;

                default:
                    result = false;
                    return false;

            }

        }

        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see cref="bool"/> equivalent.
        /// </summary>
        /// <param name="input">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains the parsed boolean value. If the conversion failed, contains <c>null</c>.</param>
        /// <returns><c>true</c> if value was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBoolean(string input, out bool? result) {

            switch (input?.ToLower()) {

                case "true":
                case "1":
                case "t":
                case "on":
                    result = true;
                    return true;

                case "false":
                case "0":
                case "f":
                case "off":
                    result = false;
                    return true;

                default:
                    result = null;
                    return false;

            }

        }

    }

}