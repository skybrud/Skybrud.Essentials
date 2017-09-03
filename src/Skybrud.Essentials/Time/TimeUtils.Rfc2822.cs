using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc2822(DateTime timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture) + " " + timestamp.ToString("zzzz", CultureInfo.InvariantCulture).Replace(":", "");
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc2822(DateTimeOffset timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture) + " " + timestamp.ToString("zzzz", CultureInfo.InvariantCulture).Replace(":", "");
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc2822(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            return ToRfc2822(timestamp.DateTime);
        }

    }

}