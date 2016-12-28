using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        #region RFC 822

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc822(DateTime timestamp) {

            // Get the offset from UTC in hours
            int offsetHours = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;

            // Get the offset from UTC in minutes (excluding hours)
            int offsetMinutes = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Minutes;

            // Generate the output string
            return String.Format(
                CultureInfo.InvariantCulture,
                "{0} {1}{2:00}{3:00}",
                timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                offsetHours < 0 || offsetMinutes < 0 ? "-" : "+",
                Math.Abs(offsetHours),
                Math.Abs(offsetMinutes)
            );

        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc822(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException("timestamp");
            return ToRfc822(timestamp.DateTime);
        }

        #endregion

    }

}