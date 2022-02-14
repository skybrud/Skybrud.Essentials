using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches a GUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a GUID; otherwise <c>false</c>.</returns>
        public static bool IsGuid(string str) {
            return Guid.TryParse(str, out Guid _);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Guid"/>. If the parsing fails,
        /// the default value of <see cref="Guid"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="Single"/>.</returns>
        public static Guid ParseGuid(string str) {
            Guid.TryParse(str, out Guid value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Guid"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="Single"/>.</returns>
        public static Guid ParseGuid(string str, Guid fallback) {
            return Guid.TryParse(str, out Guid value) ? value : fallback;
        }

        /// <summary>
        /// Parses a string of multiple GUIDs into an array of <see cref="Guid"/>. Supported separators are
        /// comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and tab (<c>\t</c>).
        /// 
        /// Values in <paramref name="str"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="str">The string containing the GUIDs.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ParseGuidArray(string str) {
            return ParseGuidArray(str, new[] { ',', ' ', '\r', '\n', '\t' });
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
        public static Guid[] ParseGuidArray(string str, params char[] separators) {
            List<Guid> guids = new List<Guid>();
            foreach (string piece in (str ?? string.Empty).Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (Guid.TryParse(piece, out Guid guid)) guids.Add(guid);
            }
            return guids.ToArray();
        }

    }

}