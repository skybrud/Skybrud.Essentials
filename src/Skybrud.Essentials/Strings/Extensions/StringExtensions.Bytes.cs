#nullable enable

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Converts the specified array of <paramref name="bytes"/> to a corresponding HEX string.
        /// </summary>
        /// <param name="bytes">The array of bytes.</param>
        /// <returns>The HEX string.</returns>
        public static string ToHexString(this byte[] bytes) {
            return StringUtils.ToHexString(bytes);
        }

        /// <summary>
        /// Converts the specified array of <paramref name="bytes"/> to a corresponding HEX string.
        /// </summary>
        /// <param name="bytes">The array of bytes.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The HEX string.</returns>
        public static string ToHexString(this byte[] bytes, HexFormat format) {
            return StringUtils.ToHexString(bytes, format);
        }

    }

}