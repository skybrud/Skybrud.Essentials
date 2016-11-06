using System;
using System.Globalization;

namespace Skybrud.Essentials.Dates {

    /// <summary>
    /// Static class with helper methods for working with dates.
    /// </summary>
    public static partial class DateHelpers {

        #region Constants

        /// <summary>
        ///     ISO 8601 date format.
        /// </summary>
        public const string IsoDateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";

        #endregion

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the age.</returns>
        public static int GetAge(DateTime dateOfBirth) {
            return GetAge(dateOfBirth, DateTime.Today);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <code>dt</code>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the age.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTime dt) {
            int age = dt.Year - dateOfBirth.Year;
            if (dt.Month < dateOfBirth.Month || (dt.Month == dateOfBirth.Month && dt.Day < dateOfBirth.Day)) age--;
            return age;
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTime date) {
            return date.Day + GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The the ordinal suffix.</returns>
        public static string GetDaySuffix(DateTime date) {
            switch (date.Day) {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        /// <summary>
        /// Gets the week number of the specified <code>date</code> according to the ISO8601 specification.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="Int32"/> representing the ISO8601 week number.</returns>
        public static int GetIso8601WeekNumber(DateTime date) {
            int day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is a weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is in the weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(DateTime date) {
            return !IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(DateTime date) {
            return IsLeapYear(date.Year);
        }

        /// <summary>
        /// Gets whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns <code>TRUE</code> if <code>year</code> is a leap year; otherwise <code>FALSE</code>.
        /// </returns>
        public static bool IsLeapYear(int year) {
            return (DateTime.DaysInMonth(year, 2).Equals(29));
        }


        /// <summary>
        /// Gets the amount elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the elapsed seconds since the input <see cref="DateTime"/>.</returns>
        public static double GetElapsedSeconds(DateTime date) {
            return DateTime.Now.Subtract(date).TotalSeconds;
        }

        /// <summary>
        /// Returns whether <code>date</code> is within the last number of specified <code>days</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns <code>true</code> if <code>date</code> is within the last number of days, otherwise <code>false</code>.
        /// </returns>
        public static bool IsDateWithinLastDays(DateTime date, int days) {
            double lastDays = (double)0 - days;
            DateTime startDate = date.AddDays(lastDays);
            return (date >= startDate);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(DateTime date) {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code>. Monday is considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date) {
            return GetFirstDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return date.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of the week.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date) {
            return GetLastDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        ///     Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date, CultureInfo culture) {
            return date.ToString("dddd", culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the date.</param>
        /// <param name="culture">The instance of <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
            return date.ToString("MMMM", culture);
        }

    }

}