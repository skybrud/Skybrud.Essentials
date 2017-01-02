using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Utility class with various static helper methods for working with date and time.
    /// </summary>
    [Obsolete("Use the TimeUtils class instead.")]
    public static partial class TimeHelper {

        #region Constants

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string Iso8601DateFormat = "yyyy-MM-ddTHH:mm:ssK";

        #endregion

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns the age based on the specified date of birth.</returns>
        public static int GetAge(DateTime dateOfBirth) {
            return TimeUtils.GetAge(dateOfBirth);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <code>dt</code>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>Returns the age based on the specified date of birth at the moment of <code>dt</code>.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTime dt) {
            return TimeUtils.GetAge(dateOfBirth, dt);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns the age based on the specified date of birth.</returns>
        public static int GetAge(EssentialsDateTime dateOfBirth) {
            return TimeUtils.GetAge(dateOfBirth);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <code>dt</code>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>Returns the age based on the specified date of birth at the moment of <code>dt</code>.</returns>
        public static int GetAge(EssentialsDateTime dateOfBirth, EssentialsDateTime dt) {
            return TimeUtils.GetAge(dateOfBirth, dt);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTime date) {
            return TimeUtils.GetDayNumberAndSuffix(date);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTimeOffset date) {
            return TimeUtils.GetDayNumberAndSuffix(date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day ordinal suffix.</returns>
        public static string GetDaySuffix(DateTime date) {
            return TimeUtils.GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day ordinal suffix.</returns>
        public static string GetDaySuffix(DateTimeOffset date) {
            return TimeUtils.GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the week number of <code>date</code> according to the ISO8601 specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        public static int GetIso8601WeekNumber(DateTime date) {
            return TimeUtils.GetIso8601WeekNumber(date);
        }

        /// <summary>
        /// Gets the week number of <code>date</code> according to the ISO8601 specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        public static int GetIso8601WeekNumber(DateTimeOffset date) {
            return TimeUtils.GetIso8601WeekNumber(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(DateTime date) {
            return TimeUtils.IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(DateTimeOffset date) {
            return TimeUtils.IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(DateTime date) {
            return TimeUtils.IsWeekend(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(DateTimeOffset date) {
            return TimeUtils.IsWeekend(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of the specified <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(DateTime date) {
            return TimeUtils.IsLeapYear(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of the specified <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(DateTimeOffset date) {
            return TimeUtils.IsLeapYear(date);
        }

        /// <summary>
        /// Gets whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified year is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(int year) {
            return TimeUtils.IsLeapYear(year);
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the elapsed seconds since <code>date</code>.</returns>
        public static double GetElapsedSeconds(DateTime date) {
            return TimeUtils.GetElapsedSeconds(date);
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the elapsed seconds since <code>date</code>.</returns>
        public static double GetElapsedSeconds(DateTimeOffset date) {
            return TimeUtils.GetElapsedSeconds(date);
        }

        /// <summary>
        /// Returns whether <code>date</code> is within the last number of specified <code>days</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns <code>true</code> if the date is within the last number of days, otherwise <code>false</code>.
        /// </returns>
        public static bool IsDateWithinLastDays(DateTime date, int days) {
            return TimeUtils.IsDateWithinLastDays(date, days);
        }

        /// <summary>
        /// Returns whether <code>date</code> is within the last number of specified <code>days</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns <code>true</code> if the date is within the last number of days, otherwise <code>false</code>.
        /// </returns>
        public static bool IsDateWithinLastDays(DateTimeOffset date, int days) {
            return TimeUtils.IsDateWithinLastDays(date, days);
        }

        #region GetFirstDayOfMonth

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(DateTime date) {
            return TimeUtils.GetFirstDayOfMonth(date);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the month.</returns>
        public static DateTimeOffset GetFirstDayOfMonth(DateTimeOffset date) {
            return TimeUtils.GetFirstDayOfMonth(date);
        }

        #endregion

        #region GetLastDayOfMonth

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(DateTime date) {
            return TimeUtils.GetLastDayOfMonth(date);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the month.</returns>
        public static DateTimeOffset GetLastDayOfMonth(DateTimeOffset date) {
            return TimeUtils.GetLastDayOfMonth(date);
        }

        #endregion

        #region GetFirstDayOfWeek

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date) {
            return TimeUtils.GetFirstDayOfWeek(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date) {
            return TimeUtils.GetFirstDayOfWeek(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetFirstDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            return TimeUtils.GetFirstDayOfWeek(date, startOfWeek);
        }

        #endregion

        #region GetLastDayOfWeek

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date) {
            return TimeUtils.GetLastDayOfWeek(date);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date) {
            return TimeUtils.GetLastDayOfWeek(date);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetLastDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            return TimeUtils.GetLastDayOfWeek(date, startOfWeek);
        }

        #endregion

        #region GetFirstWeekdayOfMonth

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(DateTime date, DayOfWeek dayOfWeek) {
            return TimeUtils.GetFirstWeekdayOfMonth(date, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetFirstWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return TimeUtils.GetFirstWeekdayOfMonth(date, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek) {
            return TimeUtils.GetFirstWeekdayOfMonth(year, month, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        public static DateTimeOffset GetFirstWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return TimeUtils.GetFirstWeekdayOfMonth(year, month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            return TimeUtils.GetFirstWeekdayOfMonth(year, month, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetFirstWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return TimeUtils.GetFirstWeekdayOfMonth(year, month, dayOfWeek, offset);
        }

        #endregion

        #region GetLastWeekdayOfMonth

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetLastWeekdayOfMonth(DateTime date, DayOfWeek dayOfWeek) {
            return TimeUtils.GetLastWeekdayOfMonth(date, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return TimeUtils.GetLastWeekdayOfMonth(date, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek) {
            return TimeUtils.GetLastWeekdayOfMonth(year, month, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return TimeUtils.GetLastWeekdayOfMonth(year, month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            return TimeUtils.GetLastWeekdayOfMonth(year, month, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return TimeUtils.GetLastWeekdayOfMonth(year, month, dayOfWeek, offset);
        }

        #endregion

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTime date) {
            return TimeUtils.GetDayName(date);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTimeOffset date) {
            return TimeUtils.GetDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date) {
            return TimeUtils.GetLocalDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date) {
            return TimeUtils.GetLocalDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalDayName(date, culture);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date, CultureInfo culture) {
            return TimeUtils.GetLocalDayName(date, culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTime date) {
            return TimeUtils.GetMonthName(date);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTimeOffset date) {
            return TimeUtils.GetMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date) {
            return TimeUtils.GetLocalMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date) {
            return TimeUtils.GetLocalMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(date, culture);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date, CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(date, culture);
        }

    }

}