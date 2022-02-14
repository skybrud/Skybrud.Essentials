using Skybrud.Essentials.Time.Rfc822;
using System;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("Use Rfc822Utils.ToString(DateTime) method instead.")]
        public static string ToRfc822(DateTime timestamp) {
            return Rfc822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("Use Rfc822Utils.ToString(DateTimeOffset) method instead.")]
        public static string ToRfc822(DateTimeOffset timestamp) {
            return Rfc822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        [Obsolete("Use Rfc822Utils.ToString(EssentialsDateTime) method instead.")]
        public static string ToRfc822(EssentialsDateTime timestamp) {
            return Rfc822Utils.ToString(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> date to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted string.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use Rfc822Utils.Parse(string) method instead.")]
        public static DateTime Rfc822ToDateTime(string rfc822) {
            return Rfc822Utils.Parse(rfc822).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use Rfc822Utils.Parse(string) method instead.")]
        public static DateTimeOffset Rfc822ToDateTimeOffset(string rfc822) {
            return Rfc822Utils.Parse(rfc822);
        }

        /// <summary>
        /// The RFC 822 specification describes a number of predefined time zones - eg. <c>EST</c>
        /// (Eastern Standard Time), <c>UT</c> (Universal Time) and <c>GMT</c>
        /// (Greenwich Mean Time) - which <see cref="DateTimeOffset"/> isn't able to parse on it's own,
        /// so we need to convert the time zone to an offset instead - eg <c>+01:00</c>.
        /// </summary>
        /// <param name="timezone">The time zone value to be normalized.</param>
        /// <returns>The normalized time zone.</returns>
        /// <see>
        ///     <cref>https://www.w3.org/Protocols/rfc822/#z28</cref>
        /// </see>
        [Obsolete("Use Rfc822Utils.NormalizeTimeZone(string) method instead.")]
        public static string NormalizeRfc822TimeZone(string timezone) {
            return Rfc822Utils.NormalizeTimeZone(timezone);
        }

    }

}