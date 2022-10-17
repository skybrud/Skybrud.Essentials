#nullable enable

using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public partial class StringUtils {

        private static readonly string[] _fileSizesKibi = { "B", "KiB", "MiB", "GiB", "TiB" };
        private static readonly string[] _fileSizesKilo = { "B", "KB", "MB", "GB", "TB" };

        /// <summary>
        /// Formats the specified <paramref name="bytes"/> into a textual representation using kibibytes, but units like <c>KB</c>, <c>MB</c> etc.
        ///
        /// Teachnically this is wrong as 1 kibibyte (1024 bytes) should use the unit <c>KiB</c>, but <c>KB</c> is commonly used instead.
        /// </summary>
        /// <param name="bytes">The bytes to format.</param>
        /// <returns>A string representing the formatted file size.</returns>
        public static string FormatFileSize(long bytes) {
            return FormatFileSizeInternal(bytes, 1024, _fileSizesKilo, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the specified <paramref name="bytes"/> into a textual representation using kibibytes, but units like <c>KB</c>, <c>MB</c> etc.
        ///
        /// Teachnically this is wrong as 1 kibibyte (1024 bytes) should use the unit <c>KiB</c>, but <c>KB</c> is commonly used instead.
        /// </summary>
        /// <param name="bytes">The bytes to format.</param>
        /// <param name="culture">The culture to be used when formatting the file size.</param>
        /// <returns>A string representing the formatted file size.</returns>
        public static string FormatFileSize(long bytes, CultureInfo culture) {
            return FormatFileSizeInternal(bytes, 1024, _fileSizesKilo, culture);
        }

        /// <summary>
        /// Formats <paramref name="bytes"/> into a textual representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="bytes">The bytes to format.</param>
        /// <param name="format">The format - eg. <see cref="FileSizeFormat.Kibi"/> or <see cref="FileSizeFormat.Kilo"/>.</param>
        /// <returns>A string representing the formatted file size.</returns>
        public static string FormatFileSize(long bytes, FileSizeFormat format) {
            return FormatFileSize(bytes, format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats <paramref name="bytes"/> into a textual representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="bytes">The bytes to format.</param>
        /// <param name="format">The format - eg. <see cref="FileSizeFormat.Kibi"/> or <see cref="FileSizeFormat.Kilo"/>.</param>
        /// <param name="culture">The culture to be used when formatting the file size.</param>
        /// <returns>A string representing the formatted file size.</returns>
        public static string FormatFileSize(long bytes, FileSizeFormat format, CultureInfo culture) {
            return format switch {
                FileSizeFormat.Kibi => FormatFileSizeInternal(bytes, 1024, _fileSizesKibi, culture),
                FileSizeFormat.Kilo => FormatFileSizeInternal(bytes, 1000, _fileSizesKilo, culture),
                _ => FormatFileSizeInternal(bytes, 1024, _fileSizesKilo, culture)
            };
        }

        private static string FormatFileSizeInternal(long bytes, long next, IReadOnlyList<string> sizes, CultureInfo culture) {

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (bytes == 0) return "0 bytes";
            if (bytes == 1) return "1 byte";
            if (bytes < next) return $"{bytes} bytes";

            double len = bytes;
            int order = 0;

            while (len >= next && order < sizes.Count - 1) {
                order++;
                len /= next;
            }

            return string.Format(culture, "{0:0.00} {1}", len, sizes[order]);

        }

    }

}