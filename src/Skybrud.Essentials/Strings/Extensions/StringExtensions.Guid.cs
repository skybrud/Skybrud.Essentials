using System;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Gets whether the string matches a GUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a GUID; otherwise <c>false</c>.</returns>
        public static bool IsGuid(string str) {
            return StringUtils.IsGuid(str);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="value"/> matches a GUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="result">The converted <see cref="Guid"/> value, of <see cref="Guid.Empty"/> if <paramref name="value"/> doesn't match a GUID.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches a GUID; otherwise <c>false</c>.</returns>
        public static bool IsGuid(string value, out Guid result) {
            return Guid.TryParse(value, out result);
        }

        /// <summary>
        /// Parses <paramref name="input"/> to an instance of <see cref="Guid"/>. If the conversion fails,
        /// <see cref="Guid.Empty"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(this string input) {
            return StringUtils.ParseGuid(input);
        }

        /// <summary>
        /// Naming of this method is wrong. Use the <see cref="ToGuid(string, Guid)"/> method instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        [Obsolete("Naming of this method is wrong. Use ToGuid() method instead.")]
        public static Guid ToInt32(this string input, Guid fallback) {
            return StringUtils.ParseGuid(input, fallback);
        }

        /// <summary>
        /// Parses <paramref name="input"/> to an instance of <see cref="Guid"/>. If the conversion fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(this string input, Guid fallback) {
            return StringUtils.ParseGuid(input, fallback);
        }

        /// <summary>
        /// Parses a string of multiple GUIDs into an array of <see cref="Guid"/>. Supported separators are
        /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
        /// 
        /// Values in <paramref name="str"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="str">The string containing the GUIDs.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this string str) {
            return StringUtils.ParseGuidArray(str);
        }

        /// <summary>
        /// Parses string of multiple GUIDs into an array of <see cref="Guid"/>, using the specified array of
        /// <paramref name="separators"/>.
        /// 
        /// Values in <paramref name="str"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="str">The string containing the GUIDs.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this string str, params char[] separators) {
            return StringUtils.ParseGuidArray(str, separators);
        }

    }

}