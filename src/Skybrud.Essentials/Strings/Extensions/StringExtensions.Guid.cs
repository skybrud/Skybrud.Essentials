using System;
using System.Collections.Generic;

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
        /// Converts the specified <paramref name="input"/> string to the equivalent <see cref="Guid"/> value.
        /// </summary>
        /// <param name="input">The string containing the GUID.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
        /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
        public static bool TryParseGuid(this string input, out Guid result) {
            return StringUtils.TryParseGuid(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to the equivalent <see cref="Guid"/> value.
        /// </summary>
        /// <param name="input">The string containing the GUID.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
        public static bool TryParseGuid(this string input, out Guid? result) {
            return StringUtils.TryParseGuid(input, out result);
        }

        /// <summary>
        /// Parses the specified <paramref name="input"/> string into an array of <see cref="Guid"/>. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this string input) {
            return StringUtils.ParseGuidArray(input);
        }

        /// <summary>
        /// Parses the specified <paramref name="input"/> string into an array of <see cref="Guid"/>, using the
        /// specified array of <paramref name="separators"/>.
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this string input, params char[] separators) {
            return StringUtils.ParseGuidArray(input, separators);
        }

        /// <summary>
        /// Parses a string of multiple GUIDs into a list of <see cref="Guid"/>. Supported separators are
        /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static List<Guid> ToGuidList(this string input) {
            return StringUtils.ParseGuidList(input);
        }

        /// <summary>
        /// Parses a string of multiple GUIDs into an array of <see cref="Guid"/>, using the specified array of
        /// <paramref name="separators"/>.
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static List<Guid> ToGuidList(this string input, params char[] separators) {
            return StringUtils.ParseGuidList(input, separators);
        }

    }

}