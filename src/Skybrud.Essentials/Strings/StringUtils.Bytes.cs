using System;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Converts the specified array of <paramref name="bytes"/> to a corresponding HEX string.
        /// </summary>
        /// <param name="bytes">The array of bytes.</param>
        /// <returns>The HEX string.</returns>
        public static string ToHexString(byte[] bytes) {
            return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
        }

        /// <summary>
        /// Converts the specified array of <paramref name="bytes"/> to a corresponding HEX string.
        /// </summary>
        /// <param name="bytes">The array of bytes.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The HEX string.</returns>
        public static string ToHexString(byte[] bytes, HexFormat format) {
            return format switch {
                HexFormat.LowerCase => BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower(),
                HexFormat.UpperCase => BitConverter.ToString(bytes).Replace("-", string.Empty),
                _ => throw new Exception($"Unsupported format: {format}")
            };
        }

    }

}