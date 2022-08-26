using System;

// ReSharper disable InvertIf

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Returns the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/> representing the timestamp.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(DateTime timestamp) {
            return (int) Math.Ceiling(timestamp.Month / 3d);
        }

        /// <summary>
        /// Returns the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/> representing the timestamp.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(DateTimeOffset timestamp) {
            return (int) Math.Ceiling(timestamp.Month / 3d);
        }

        /// <summary>
        /// Returns the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="EssentialsTime"/> representing the timestamp.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(EssentialsTime timestamp) {
            return GetQuarter(timestamp.DateTimeOffset);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the start of the quarter identified by the specified <paramref name="year"/> and <paramref name="quarter"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTimeOffset GetStartOfQuarter(int year, int quarter) {
            return GetStartOfQuarter(year, quarter, TimeSpan.Zero);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the start of the quarter identified by the specified <paramref name="year"/> and <paramref name="quarter"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <param name="offset">The offset to UTC.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTimeOffset GetStartOfQuarter(int year, int quarter, TimeSpan offset) {
            return new DateTimeOffset(year, 3 * quarter - 2, 1, 0, 0, 0, offset);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> representing the start of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the start of the quarter.</returns>
        public static DateTime GetStartOfQuarter(DateTime timestamp) {
            return GetStartOfQuarter(timestamp.Year, GetQuarter(timestamp)).DateTime;
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the start of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTimeOffset GetStartOfQuarter(DateTimeOffset timestamp) {
            return new DateTimeOffset(timestamp.Year, 3 * GetQuarter(timestamp) - 2, 1, 0, 0, 0, timestamp.Offset);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the start of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone for which the reuslt should be adjusted.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTimeOffset GetStartOfQuarter(DateTimeOffset timestamp, TimeZoneInfo timeZone) {

            // Get the start of the quarter
            var start = GetStartOfQuarter(timestamp);

            // Adjust to the specified time zone
            start = timeZone == null ? start : TimeZoneInfo.ConvertTime(start, timeZone);

            // Adjust for dayligt savings
            if (start.Hour == 23) start = start.AddHours(+1);
            if (start.Hour == 01) start = start.AddHours(-1);

            return start;

        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the start of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the quarter.</returns>
        public static EssentialsTime GetStartOfQuarter(EssentialsTime timestamp) {
            return new EssentialsTime(GetStartOfQuarter(timestamp.DateTimeOffset, timestamp.TimeZone), timestamp.TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the end of the quarter identified by the specified <paramref name="year"/> and <paramref name="quarter"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the end of the quarter.</returns>
        public static DateTimeOffset GetEndOfQuarter(int year, int quarter) {
            return GetEndOfQuarter(year, quarter, TimeSpan.Zero);
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the end of the quarter identified by the specified <paramref name="year"/> and <paramref name="quarter"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="quarter">The quarter.</param>
        /// <param name="offset">The offset to UTC.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the end of the quarter.</returns>
        public static DateTimeOffset GetEndOfQuarter(int year, int quarter, TimeSpan offset) {

            int month = 3 * quarter + 1;

            if (month == 13) {
                year++;
                month = 1;
            }

            return new DateTimeOffset(year, month, 1, 0, 0, 0, offset).AddTicks(-1);

        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> representing the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTime GetEndOfQuarter(DateTime timestamp) {
            return GetEndOfQuarter(timestamp.Year, GetQuarter(timestamp)).DateTime;
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the end of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the end of the quarter.</returns>
        public static DateTimeOffset GetEndOfQuarter(DateTimeOffset timestamp) {
            return GetEndOfQuarter(timestamp.Year, GetQuarter(timestamp));
        }

        /// <summary>
        /// Returns a new <see cref="DateTimeOffset"/> representing the end of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone for which the reuslt should be adjusted.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the end of the quarter.</returns>
        public static DateTimeOffset GetEndOfQuarter(DateTimeOffset timestamp, TimeZoneInfo timeZone) {

            // Get the end of the quarter
            var end = GetEndOfQuarter(timestamp);

            // Adjust to the specified time zone
            end = timeZone == null ? end : TimeZoneInfo.ConvertTime(end, timeZone);

            // Adjust for dayligt savings
            switch (end.Hour) {
                case 22: end = end.AddHours(+1); break;
                case 00: end = end.AddHours(-1); break;
                case 01: end = end.AddHours(-2); break;
            }

            return end;

        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the end of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the quarter.</returns>
        public static EssentialsTime GetEndOfQuarter(EssentialsTime timestamp) {
            return new EssentialsTime(GetEndOfQuarter(timestamp.DateTimeOffset, timestamp.TimeZone), timestamp.TimeZone);
        }

    }

}