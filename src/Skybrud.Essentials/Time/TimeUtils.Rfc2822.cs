using System;
using Skybrud.Essentials.Time.Rfc2822;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("use Rfc2822Utils.ToString(DateTime) method instead.")]
        public static string ToRfc2822(DateTime timestamp) {
            return Rfc2822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("use Rfc2822Utils.ToString(DateTimeOffset) method instead.")]
        public static string ToRfc2822(DateTimeOffset timestamp) {
            return Rfc2822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("use Rfc2822Utils.ToString(EssentialsDateTime) method instead.")]
        public static string ToRfc2822(EssentialsDateTime timestamp) {
            return Rfc2822Utils.ToString(timestamp);
        }

    }

}