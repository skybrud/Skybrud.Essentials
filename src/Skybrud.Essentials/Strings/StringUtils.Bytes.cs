#nullable enable

using System;
using System.Linq;

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

        /// <summary>
        /// Parse the specified HEX string into a corresponding array of <see cref="byte"/>.
        /// </summary>
        /// <param name="hex">The HEX string to parse.</param>
        /// <returns></returns>
        public static byte[] ParseHexString(string hex) {

            if (string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException(nameof(hex));

            // Detect whether the HEX string uses hyphens
            int mod = hex.Length > 2 && hex[2] == '-' ? 3 : 2;

            return Enumerable.Range(0, hex.Length)
                .Where(x => x % mod == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();

        }

    }

}