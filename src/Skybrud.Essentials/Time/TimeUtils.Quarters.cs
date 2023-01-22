using System;

// ReSharper disable InvertIf

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        internal static int GetStartMonthOfQuarter(int quarter) {
            return 3 * quarter - 2;
        }

        internal static int GetStartMonthOfQuarter(DateTime date) {
            return GetStartMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetStartMonthOfQuarter(DateTimeOffset date) {
            return GetStartMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetStartMonthOfQuarter(EssentialsDate date) {
            return GetStartMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetStartMonthOfQuarter(EssentialsTime date) {
            return GetStartMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetEndMonthOfQuarter(int quarter) {
            return 3 * quarter + 1;
        }

        internal static int GetEndMonthOfQuarter(DateTime date) {
            return GetEndMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetEndMonthOfQuarter(DateTimeOffset date) {
            return GetEndMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetEndMonthOfQuarter(EssentialsDate date) {
            return GetEndMonthOfQuarter(GetQuarter(date));
        }

        internal static int GetEndMonthOfQuarter(EssentialsTime date) {
            return GetEndMonthOfQuarter(GetQuarter(date));
        }

        /// <summary>
        /// Returns the quarter of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsTime"/> representing the date.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(EssentialsDate date) {
            return (int) Math.Ceiling(date.Month / 3d);
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
        /// Returns a new <see cref="EssentialsTime"/> representing the end of the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the quarter.</returns>
        public static EssentialsTime GetEndOfQuarter(EssentialsTime timestamp) {
            return new EssentialsTime(GetEndOfQuarter(timestamp.DateTimeOffset, timestamp.TimeZone), timestamp.TimeZone);
        }

    }

}