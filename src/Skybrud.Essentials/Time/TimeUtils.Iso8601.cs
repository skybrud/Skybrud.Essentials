using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string Iso8601DateFormat = "yyyy-MM-ddTHH:mm:ssK";

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToIso8601(DateTime timestamp) {
            return timestamp.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToIso8601(DateTimeOffset timestamp) {
            return timestamp.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToIso8601(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException("timestamp");
            return ToIso8601(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="iso8601">The string with the RFC 822 formatted string.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime Iso8601ToDateTime(string iso8601) {
            return Iso8601ToDateTimeOffset(iso8601).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8106 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Iso8601ToDateTimeOffset(string iso8601) {
            if (String.IsNullOrWhiteSpace(iso8601)) throw new ArgumentNullException("iso8601");
            return DateTimeOffset.ParseExact(iso8601, Iso8601DateFormat, CultureInfo.InvariantCulture);
        }

    }

}