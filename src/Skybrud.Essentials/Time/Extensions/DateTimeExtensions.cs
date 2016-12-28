using System;
using System.Globalization;

namespace Skybrud.Essentials.Time.Extensions {
    
    /// <summary>
    /// Static class with various extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions {

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the age.</returns>
        public static int GetAge(this DateTime dateOfBirth) {
            return TimeUtils.GetAge(dateOfBirth);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <code>dt</code>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the age.</returns>
        public static int GetAge(this DateTime dateOfBirth, DateTime dt) {
            return TimeUtils.GetAge(dateOfBirth, dt);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(this DateTime date) {
            return TimeUtils.GetDayNumberAndSuffix(date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The the ordinal suffix.</returns>
        public static string GetDaySuffix(this DateTime date) {
            return TimeUtils.GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the week number of the specified <code>date</code> according to the ISO8601 specification.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the ISO8601 week number.</returns>
        public static int GetIso8601WeekNumber(this DateTime date) {
            return TimeUtils.GetIso8601WeekNumber(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is a weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(this DateTime date) {
            return TimeUtils.IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is in the weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(this DateTime date) {
            return TimeUtils.IsWeekend(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(this DateTime date) {
            return TimeUtils.IsLeapYear(date);
        }

        /// <summary>
        /// Gets whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns <code>TRUE</code> if <code>year</code> is a leap year; otherwise <code>FALSE</code>.
        /// </returns>
        public static bool IsLeapYear(this int year) {
            return TimeUtils.IsLeapYear(year);
        }


        /// <summary>
        /// Gets the amount elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the elapsed seconds since the input <see cref="DateTime"/>.</returns>
        public static double GetElapsedSeconds(this DateTime date) {
            return TimeUtils.GetElapsedSeconds(date);
        }

        /// <summary>
        /// Returns whether <code>date</code> is within the last number of specified <code>days</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is within the last number of days, otherwise <code>false</code>.
        /// </returns>
        public static bool IsDateWithinLastDays(this DateTime date, int days) {
            return TimeUtils.IsDateWithinLastDays(date, days);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date) {
            return TimeUtils.GetFirstDayOfMonth(date);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime date) {
            return TimeUtils.GetLastDayOfMonth(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code>. Monday is considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date) {
            return TimeUtils.GetFirstDayOfWeek(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetFirstDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(this DateTime date) {
            return TimeUtils.GetLastDayOfWeek(date);
        }

        /// <summary>
        ///     Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(this DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetLastDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(this DateTime date) {
            return TimeUtils.GetDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(this DateTime date) {
            return TimeUtils.GetLocalDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalDayName(date, culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(this DateTime date) {
            return TimeUtils.GetMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(this DateTime date) {
            return TimeUtils.GetLocalMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(date, culture);
        }

    }

}