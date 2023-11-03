using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Time {

    public partial class TimeUtils {

        #region Get ... of day

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the start of the day based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the start of day for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the start of the day.</returns>
        public static DateTime GetStartOfDay(DateTime time) {
            return new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, time.Kind);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the end of the day based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the end of day for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the end of the day.</returns>
        public static DateTime GetEndOfDay(DateTime time) {

            // Get the start of the current day
            DateTime temp = new(time.Year, time.Month, time.Day, 0, 0, 0, time.Kind);

            // Add a day, but subtract a single tick
            temp = temp.AddDays(1).AddTicks(-1);

            return temp;

        }

        #endregion

        #region Get ... of week

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the start of the week based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the start of week for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the start of the week.</returns>
        public static DateTime GetStartOfWeek(DateTime time) {
            return GetStartOfWeek(time, DayOfWeek.Monday);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the start of the week based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the start of week for.</param>
        /// <param name="startOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the start of the week.</returns>
        public static DateTime GetStartOfWeek(DateTime time, DayOfWeek startOfWeek) {

            // Get the days since the start of the week
            int diff = time.DayOfWeek - startOfWeek;

            // Adjust if the difference is negative
            if (diff < 0) diff += 7;

            // Get the first day of the week
            time = time.AddDays(-1 * diff);

            // Get the start of the week
            return new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);

        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the end of the week based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the end of week for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the end of the week.</returns>
        public static DateTime GetEndOfWeek(DateTime time) {
            return GetEndOfWeek(time, DayOfWeek.Monday);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the end of the week based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the end of week for.</param>
        /// <param name="startOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the end of the week.</returns>
        public static DateTime GetEndOfWeek(DateTime time, DayOfWeek startOfWeek) {
            return GetStartOfWeek(time, startOfWeek).AddDays(7).AddTicks(-1);
        }

        #endregion

        #region Get ... of month

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the start of the month based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the start of month for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the start of the month.</returns>
        public static DateTime GetStartOfMonth(DateTime time) {
            return new DateTime(time.Year, time.Month, 1, 0, 0, 0, time.Kind);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> representing the end of the month based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> to get the end of month for.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the end of the month.</returns>
        public static DateTime GetEndOfMonth(DateTime time) {

            // Get the amount of days in the month
            int days = DateTime.DaysInMonth(time.Year, time.Month);

            // Get the start of the month, then add the amount of days
            time = GetStartOfMonth(time).AddDays(days).AddTicks(-1);

            return time;

        }

        #endregion

        #region Get ... of quarter

        /// <summary>
        /// Returns the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/> representing the timestamp.</param>
        /// <returns>An <see cref="int"/> representing the quarter.</returns>
        public static int GetQuarter(DateTime timestamp) {
            return (int) Math.Ceiling(timestamp.Month / 3d);
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
        /// Returns a new <see cref="DateTime"/> representing the quarter of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the start of the quarter.</returns>
        public static DateTime GetEndOfQuarter(DateTime timestamp) {
            return GetEndOfQuarter(timestamp.Year, GetQuarter(timestamp)).DateTime;
        }

        #endregion

        #region Is...

        /// <summary>
        /// Returns whether <paramref name="first"/> and <paramref name="second"/> represents the same day.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns><see langword="true"/> if <paramref name="first"/> and <paramref name="second"/> represents the same day; otherwise, <see langword="false"/>.</returns>
        public static bool IsSameDay(DateTime first, DateTime second) {
            return first.Year == second.Year && first.Month == second.Month && first.Day == second.Day;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is today.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is today; otherwise, <c>false</c>.</returns>
        public static bool IsToday(DateTime date) {
            return IsSameDay(date, DateTime.Now);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is tomorrow.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is tomorrow; otherwise, <c>false</c>.</returns>
        public static bool IsTomorrow(DateTime date) {
            return IsSameDay(date, DateTime.Now.AddDays(1));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is yesterday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is yesterday; otherwise, <c>false</c>.</returns>
        public static bool IsYesterday(DateTime date) {
            return IsSameDay(date, DateTime.Now.AddDays(-1));
        }

        #endregion

        #region Min...

        /// <summary>
        /// Returns the minimum value of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first <see cref="DateTime"/> value.</param>
        /// <param name="b">The second <see cref="DateTime"/> value.</param>
        /// <returns>The minimum <see cref="DateTime"/> value.</returns>
        public static DateTime Min(DateTime a, DateTime b) {
            return a < b ? a : b;
        }

        /// <summary>
        /// Returns the minimum value of the specified <see cref="DateTime"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">An array of <see cref="DateTime"/> values.</param>
        /// <returns>The minimum <see cref="DateTime"/> value.</returns>
        public static DateTime Min(params DateTime[] values) {
            return values.Min(x => x);
        }

        /// <summary>
        /// Returns the minimum value of the specified <see cref="DateTime"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">A collection of <see cref="DateTime"/> values.</param>
        /// <returns>The minimum <see cref="DateTime"/> value.</returns>
        public static DateTime Min(IEnumerable<DateTime> values) {
            return values.Min(x => x);
        }

        #endregion

        #region Max...

        /// <summary>
        /// Returns the maximum value of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first <see cref="DateTime"/> value.</param>
        /// <param name="b">The second <see cref="DateTime"/> value.</param>
        /// <returns>The maximum <see cref="DateTime"/> value.</returns>
        public static DateTime Max(DateTime a, DateTime b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the maximum value of the specified <see cref="DateTime"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">An array of <see cref="DateTime"/> values.</param>
        /// <returns>The maximum <see cref="DateTime"/> value.</returns>
        public static DateTime Max(params DateTime[] values) {
            return values.Max(x => x);
        }

        /// <summary>
        /// Returns the maximum value of the specified <see cref="DateTime"/> <paramref name="values"/>.
        /// </summary>
        /// <param name="values">A collection of <see cref="DateTime"/> values.</param>
        /// <returns>The maximum <see cref="DateTime"/> value.</returns>
        public static DateTime Max(IEnumerable<DateTime> values) {
            return values.Max(x => x);
        }

        #endregion

    }

}