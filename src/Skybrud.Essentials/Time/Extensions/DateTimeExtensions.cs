using System;
using System.Globalization;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time.Extensions {

    /// <summary>
    /// Static class with various extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions {

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>An instance of <see cref="int"/> representing the age.</returns>
        public static int GetAge(this DateTime dateOfBirth) {
            return TimeUtils.GetAge(dateOfBirth);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <paramref name="dt"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>An instance of <see cref="int"/> representing the age.</returns>
        public static int GetAge(this DateTime dateOfBirth, DateTime dt) {
            return TimeUtils.GetAge(dateOfBirth, dt);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(this DateTime date) {
            return TimeUtils.GetDayNumberAndSuffix(date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The the ordinal suffix.</returns>
        public static string GetDaySuffix(this DateTime date) {
            return TimeUtils.GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the week number of the specified <paramref name="date"/> according to the <strong>ISO 8601</strong>
        /// specification.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>An instance of <see cref="int"/> representing the <strong>ISO 8601</strong> week number.</returns>
        public static int GetIso8601WeekNumber(this DateTime date) {
            return Iso8601Utils.GetWeekNumber(date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a weekday.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is a weekday; otherwise <c>false</c>. </returns>
        public static bool IsWeekday(this DateTime date) {
            return TimeUtils.IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is in the weekend.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is in the weekend; otherwise <c>false</c>.</returns>
        public static bool IsWeekend(this DateTime date) {
            return TimeUtils.IsWeekend(date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a leap year.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns><c>true</c> if the year of <paramref name="date"/> is a leap year; otherwise <c>false</c>.</returns>
        public static bool IsLeapYear(this DateTime date) {
            return TimeUtils.IsLeapYear(date);
        }

        /// <summary>
        /// Gets whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns><c>true</c> if <paramref name="year"/> is a leap year; otherwise <c>false</c>.</returns>
        public static bool IsLeapYear(this int year) {
            return TimeUtils.IsLeapYear(year);
        }


        /// <summary>
        /// Gets the amount elapsed seconds since the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The elapsed seconds since the input <see cref="DateTime"/>.</returns>
        public static double GetElapsedSeconds(this DateTime date) {
            return TimeUtils.GetElapsedSeconds(date);
        }

        /// <summary>
        /// Gets whether <paramref name="date"/> is within the last number of specified <paramref name="days"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is within the last number of
        /// <paramref name="days"/>, otherwise <c>false</c>.</returns>
        public static bool IsDateWithinLastDays(this DateTime date, int days) {
            return TimeUtils.IsDateWithinLastDays(date, days);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date) {
            return TimeUtils.GetFirstDayOfMonth(date);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime date) {
            return TimeUtils.GetLastDayOfMonth(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/>. <strong>Monday</strong> is
        /// considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date) {
            return TimeUtils.GetFirstDayOfWeek(date);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/> and based on
        /// <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetFirstDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/>. <strong>Monday</strong> is
        /// considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(this DateTime date) {
            return TimeUtils.GetLastDayOfWeek(date);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/> and based on
        /// <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(this DateTime date, DayOfWeek startOfWeek) {
            return TimeUtils.GetLastDayOfWeek(date, startOfWeek);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetDayName(this DateTime date) {
            return TimeUtils.GetDayName(date);
        }

        /// <summary>
        /// Gets the abbreviated English name of the day.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The abbreviated English name of the day.</returns>
        public static string GetAbbreviatedDayName(this DateTime date) {
            return TimeUtils.GetAbbreviatedDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(this DateTime date) {
            return TimeUtils.GetLocalDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalDayName(date, culture);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The local abbreviated name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(this DateTime date) {
            return TimeUtils.GetAbbreviatedLocalDayName(date);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local abbreviated name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetAbbreviatedLocalDayName(date, culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The English name of the month.</returns>
        public static string GetMonthName(this DateTime date) {
            return TimeUtils.GetMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(this DateTime date) {
            return TimeUtils.GetLocalMonthName(date);
        }

        /// <summary>
        /// Gets the name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(date, culture);
        }

        /// <summary>
        /// Gets the abbreviated English name of the month.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The English name of the month.</returns>
        public static string GetAbbreviatedMonthName(this DateTime date) {
            return TimeUtils.GetAbbreviatedMonthName(date);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(this DateTime date) {
            return TimeUtils.GetAbbreviatedLocalMonthName(date);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(this DateTime date, CultureInfo culture) {
            return TimeUtils.GetAbbreviatedLocalMonthName(date, culture);
        }

    }

}