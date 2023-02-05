using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Collections;

// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Returns whether the specified <paramref name="input"/> string matches a GUID (<see cref="Guid"/>).
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="input"/> matches a GUID; otherwise <c>false</c>.</returns>
        public static bool IsGuid(string? input) {
            return Guid.TryParse(input, out Guid _);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to an instance of <see cref="Guid"/>. If the
        /// conversion fails, <see cref="Guid.Empty"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ParseGuid(string? input) {
            _ = Guid.TryParse(input, out Guid value);
            return value;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to an instance of <see cref="Guid"/>. If the
        /// conversion fails, <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="fallback">The fallback value that will be returned if the conversion fails.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ParseGuid(string? input, Guid fallback) {
            return Guid.TryParse(input, out Guid value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to an instance of <see cref="Guid"/>. If the
        /// conversion fails, <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <returns>An instance of <see cref="Guid"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static Guid? ParseGuidOrNull(string? input) {
            return Guid.TryParse(input, out Guid value) ? value : null;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to the equivalent <see cref="Guid"/> value.
        /// </summary>
        /// <param name="input">The string containing the GUID.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful;
        /// otherwise, <see cref="Guid.Empty"/>.</param>
        /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
        public static bool TryParseGuid(string? input, out Guid result) {
            return Guid.TryParse(input, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to the equivalent <see cref="Guid"/> value.
        /// </summary>
        /// <param name="input">The string containing the GUID.</param>
        /// <param name="result">When this method returns, holds the converted <see cref="Guid"/> value if successful;
        /// otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
        public static bool TryParseGuid(string? input, [NotNullWhen(true)] out Guid? result) {
            if (Guid.TryParse(input, out Guid guid)) {
                result = guid;
                return true;
            }
            result = null;
            return false;
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
        public static Guid[] ParseGuidArray(string? input) {
            return ParseGuidArray(input, DefaultSeparators);
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
        public static Guid[] ParseGuidArray(string? input, params char[] separators) {

            if (string.IsNullOrWhiteSpace(input)) return ArrayUtils.Empty<Guid>();

            List<Guid> guids = new();
            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (Guid.TryParse(piece, out Guid guid)) guids.Add(guid);
            }

            return guids.ToArray();

        }

        /// <summary>
        /// Parses the specified <paramref name="input"/> string into a list of <see cref="Guid"/>. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <returns>A list of <see cref="Guid"/>.</returns>
        public static List<Guid> ParseGuidList(string? input) {
            return ParseGuidList(input, DefaultSeparators);
        }

        /// <summary>
        /// Parses the specified <paramref name="input"/> string into a list of <see cref="Guid"/>, using the specified
        /// array of <paramref name="separators"/>.
        ///
        /// Values in <paramref name="input"/> that can't be converted to <see cref="Guid"/> will be ignored.
        /// </summary>
        /// <param name="input">The string containing the GUIDs.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of <see cref="Guid"/>.</returns>
        public static List<Guid> ParseGuidList(string? input, params char[] separators) {

            List<Guid> temp = new();
            if (string.IsNullOrWhiteSpace(input)) return temp;

            foreach (string piece in input!.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (Guid.TryParse(piece, out Guid result)) temp.Add(result);
            }

            return temp;

        }

    }

}