using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        #region Get ... of day

        public static DateTimeOffset GetStartOfDay(DateTimeOffset time) {
            return new DateTimeOffset(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);
        }

        public static DateTimeOffset GetStartOfDay(DateTimeOffset time, TimeZoneInfo? timeZone) {

            // Get the end of the day according to the current offset
            DateTimeOffset temp = GetStartOfDay(time);
            if (timeZone == null) return temp;

            // Adjust the time to the specified time zone
            temp = TimeZoneInfo.ConvertTime(temp, timeZone);

            // Adjust the hour (necessary when daylight saving starts or ends)
            if (temp.Hour == 23) temp = temp.AddHours(+1);
            if (temp.Hour == 01) temp = temp.AddHours(-1);

            return temp;

        }

        public static DateTimeOffset GetEndOfDay(DateTimeOffset time) {

            // Get the start of the current day
            DateTimeOffset temp = new(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);

            // Add a day, but subtract a single tick
            temp = temp.AddDays(1).AddTicks(-1);

            return temp;

        }

        public static DateTimeOffset GetEndOfDay(DateTimeOffset time, TimeZoneInfo? timeZone) {

            // Get the end of the day according to the current offset
            DateTimeOffset temp = GetEndOfDay(time);
            if (timeZone == null) return temp;

            // Adjust the time to the specified time zone
            temp = TimeZoneInfo.ConvertTime(temp, timeZone);

            // Adjust the hour (necessary when daylight saving starts or ends)
            if (temp.Hour == 0) temp = temp.AddHours(-1);

            return temp;

        }

        #endregion

        #region Get ... of week

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time) {
            return GetStartOfWeek(time, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, DayOfWeek startOfWeek) {

            // Get the days since the start of the week
            int diff = time.DayOfWeek - startOfWeek;

            // Adjust if the difference is negative
            if (diff < 0) diff += 7;

            // Get the first day of the week
            time = time.AddDays(-1 * diff);

            // Get the start of the week
            return new DateTimeOffset(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);

        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, TimeZoneInfo? timeZone) {
            return GetStartOfWeek(time, timeZone, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, TimeZoneInfo? timeZone, DayOfWeek startOfWeek) {

            // Get the start of the week
            time = GetStartOfWeek(time, startOfWeek);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 23) time = time.AddHours(+1);
            if (time.Hour == 01) time = time.AddHours(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time) {
            return GetEndOfWeek(time, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, DayOfWeek startOfWeek) {
            return GetStartOfWeek(time, startOfWeek).AddDays(7).AddTicks(-1);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, TimeZoneInfo? timeZone) {
            return GetEndOfWeek(time, timeZone, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, TimeZoneInfo? timeZone, DayOfWeek startOfWeek) {

            // Get the end of the week
            time = GetEndOfWeek(time, startOfWeek);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 22) time = time.AddHours(+1);
            if (time.Hour == 00) time = time.AddHours(-1);

            return time;

        }

        #endregion

        #region Get ... of month

        public static DateTimeOffset GetStartOfMonth(DateTimeOffset time) {
            return new DateTimeOffset(time.Year, time.Month, 1, 0, 0, 0, time.Offset);
        }

        public static DateTimeOffset GetStartOfMonth(DateTimeOffset time, TimeZoneInfo? timeZone) {

            // Get the start of the month
            time = GetStartOfMonth(time);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 23) time = time.AddHours(+1);
            if (time.Hour == 01) time = time.AddHours(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfMonth(DateTimeOffset time) {

            // Get the amount of days in the month
            int days = DateTime.DaysInMonth(time.Year, time.Month);

            // Get the start of the month, then add the amount of days
            time = GetStartOfMonth(time).AddDays(days).AddTicks(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfMonth(DateTimeOffset time, TimeZoneInfo? timeZone) {

            // Get the end of the month
            time = GetEndOfMonth(time);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 22) time = time.AddHours(+1);
            if (time.Hour == 00) time = time.AddHours(-1);

            return time;

        }

        #endregion

        #region Get ... of quarter

        /// <summary>
        /// Returns the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/> representing the timestamp.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(DateTimeOffset timestamp) {
            return (int) Math.Ceiling(timestamp.Month / 3d);
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
        public static DateTimeOffset GetStartOfQuarter(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {

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
        public static DateTimeOffset GetEndOfQuarter(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {

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

        #endregion

        #region Is...

        /// <summary>
        /// Returns whether <paramref name="first"/> and <paramref name="second"/> represents the same day.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns><c>true</c> if <paramref name="first"/> and <paramref name="second"/> represents the same day; otherwise, <c>false</c>.</returns>
        public static bool IsSameDay(DateTimeOffset first, DateTimeOffset second) {
            return first.Year == second.Year && first.Month == second.Month && first.Day == second.Day;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is today.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is today; otherwise, <c>false</c>.</returns>
        public static bool IsToday(DateTimeOffset date) {
            return IsSameDay(date, DateTimeOffset.Now);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is tomorrow.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is tomorrow; otherwise, <c>false</c>.</returns>
        public static bool IsTomorrow(DateTimeOffset date) {
            return IsSameDay(date, DateTimeOffset.Now.AddDays(1));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is yesterday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is yesterday; otherwise, <c>false</c>.</returns>
        public static bool IsYesterday(DateTimeOffset date) {
            return IsSameDay(date, DateTimeOffset.Now.AddDays(-1));
        }

        #endregion

        #region Min...

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first <see cref="DateTimeOffset"/> value.</param>
        /// <param name="b">The second <see cref="DateTimeOffset"/> value.</param>
        /// <returns>The minimum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Min(DateTimeOffset a, DateTimeOffset b) {
            return a < b ? a : b;
        }

        /// <summary>
        /// Returns the minimum value of the specified <see cref="DateTimeOffset"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">An array of <see cref="DateTimeOffset"/> values.</param>
        /// <returns>The minimum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Min(params DateTimeOffset[] values) {
            return values.Min(x => x);
        }

        /// <summary>
        /// Returns the minimum value of the specified <see cref="DateTimeOffset"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">A collection of <see cref="DateTimeOffset"/> values.</param>
        /// <returns>The minimum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Min(IEnumerable<DateTimeOffset> values) {
            return values.Min(x => x);
        }

        #endregion

        #region Max...

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first <see cref="DateTimeOffset"/> value.</param>
        /// <param name="b">The second <see cref="DateTimeOffset"/> value.</param>
        /// <returns>The maximum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Max(DateTimeOffset a, DateTimeOffset b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the maximum value of the specified <see cref="DateTimeOffset"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">An array of <see cref="DateTimeOffset"/> values.</param>
        /// <returns>The maximum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Max(params DateTimeOffset[] values) {
            return values.Max(x => x);
        }

        /// <summary>
        /// Returns the maximum value of the specified <see cref="DateTimeOffset"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">A collection of <see cref="DateTimeOffset"/> values.</param>
        /// <returns>The maximum <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset Max(IEnumerable<DateTimeOffset> values) {
            return values.Max(x => x);
        }

        #endregion

    }

}