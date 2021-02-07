using System;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        [Obsolete("Use Iso8601.DateTimeFormat constant instead.")]
        public const string Iso8601DateFormat = Iso8601Constants.DateTimeFormat;

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        [Obsolete("Use Iso8601Utils.ToString(DateTime) method instead.")]
        public static string ToIso8601(DateTime timestamp) {
            return Iso8601Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        [Obsolete("Use Iso8601Utils.ToString(DateTimeOffset) method instead.")]
        public static string ToIso8601(DateTimeOffset timestamp) {
            return Iso8601Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        [Obsolete("Use EssentialsTime class instead of EssentialsDateTime.")]
        public static string ToIso8601(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            return Iso8601Utils.ToString(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8601 formatted string.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use Iso8601Utils.Parse(string) method instead.")]
        public static DateTime Iso8601ToDateTime(string iso8601) {
            return Iso8601Utils.Parse(iso8601).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8106 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use Iso8601Utils.Parse(string) method instead.")]
        public static DateTimeOffset Iso8601ToDateTimeOffset(string iso8601) {
            if (string.IsNullOrWhiteSpace(iso8601)) throw new ArgumentNullException(nameof(iso8601));
            return Iso8601Utils.Parse(iso8601);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the start of the specified
        /// <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use Iso8601Utils.FromWeekNumber(int,int) method instead.")]
        public static DateTime GetDateTimeFromIso8601Week(int year, int week) {
            return Iso8601Utils.FromWeekNumber(year, week).DateTime;
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use Iso8601Utils.FromWeekNumber(int,int) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromIso8601Week(int year, int week) {
            return Iso8601Utils.FromWeekNumber(year, week);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="offset">The offset to convert the <see cref="DateTimeOffset"/> value to.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use Iso8601Utils.FromWeekNumber(int,int,TimeSpan) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromIso8601Week(int year, int week, TimeSpan offset) {
            return Iso8601Utils.FromWeekNumber(year, week, offset);
        }

    }

}