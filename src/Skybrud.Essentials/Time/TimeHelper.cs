using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Utility class with various static helper methods for working with date and time.
    /// </summary>
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
            return GetAge(dateOfBirth, DateTime.Today);
        }

        // TODO: Implement GetAge for DateTimeOffset?

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <code>dt</code>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>Returns the age based on the specified date of birth at the moment of <code>dt</code>.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTime dt) {
            int age = dt.Year - dateOfBirth.Year;
            if (dt.Month < dateOfBirth.Month || (dt.Month == dateOfBirth.Month && dt.Day < dateOfBirth.Day)) age--;
            return age;
        }

        // TODO: Implement GetAge for DateTimeOffset?

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTime date) {
            return date.Day + GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTimeOffset date) {
            return GetDayNumberAndSuffix(date.Date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day ordinal suffix.</returns>
        public static string GetDaySuffix(DateTime date) {
            switch (date.Day) {
                case 1: case 21: case 31: return "st";
                case 2: case 22: return "nd";
                case 3: case 23: return "rd";
                default: return "th";
            }
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day ordinal suffix.</returns>
        public static string GetDaySuffix(DateTimeOffset date) {
            return GetDaySuffix(date.Date);
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
            int day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
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
            return GetIso8601WeekNumber(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekday; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekday(DateTimeOffset date) {
            return IsWeekday(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(DateTime date) {
            return !IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified day is weekend; otherwise <code>false</code>.
        /// </returns>
        public static bool IsWeekend(DateTimeOffset date) {
            return IsWeekend(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of the specified <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(DateTime date) {
            return IsLeapYear(date.Year);
        }

        /// <summary>
        /// Gets whether the specified <code>date</code> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <code>true</code> if the year of the specified <code>date</code> is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(DateTimeOffset date) {
            return IsLeapYear(date.Date);
        }

        /// <summary>
        /// Gets whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns <code>true</code> if the specified year is a leap year; otherwise <code>false</code>.
        /// </returns>
        public static bool IsLeapYear(int year) {
            return (DateTime.DaysInMonth(year, 2).Equals(29));
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the elapsed seconds since <code>date</code>.</returns>
        public static double GetElapsedSeconds(DateTime date) {
            return DateTime.Now.Subtract(date).TotalSeconds;
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the elapsed seconds since <code>date</code>.</returns>
        public static double GetElapsedSeconds(DateTimeOffset date) {
            // TODO: Should this be based on DateTimeOffset? And is there a difference?
            return GetElapsedSeconds(date.DateTime);
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
            double lastDays = (double) 0 - days;
            DateTime startDate = date.AddDays(lastDays);
            return (date >= startDate);
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
            return IsDateWithinLastDays(date.DateTime, days);
        }

        #region GetFirstDayOfMonth

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the month.</returns>
        public static DateTimeOffset GetFirstDayOfMonth(DateTimeOffset date) {
            return new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, date.Offset);
        }

        #endregion

        #region GetLastDayOfMonth

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(DateTime date) {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the month.</returns>
        public static DateTimeOffset GetLastDayOfMonth(DateTimeOffset date) {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTimeOffset(date.Year, date.Month, daysInMonth, 23, 59, 59, date.Offset);
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
            return GetFirstDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date) {
            return GetFirstDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return date.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return date.AddDays(-1 * diff).Date;
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
            return GetLastDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date) {
            return GetLastDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
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
            return GetFirstWeekdayOfMonth(date.Year, date.Month, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetFirstWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return GetFirstWeekdayOfMonth(date.Year, date.Month, dayOfWeek, date.Offset);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek) {
            return GetFirstWeekdayOfMonth(year, (int) month, dayOfWeek);
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
            return GetFirstWeekdayOfMonth(year, (int) month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the first day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            DateTime dt = new DateTime(year, month, 1);
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(1);
            }
            return dt;
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
            DateTimeOffset dt = new DateTimeOffset(year, month, 1, 0, 0, 0, offset);
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(1);
            }
            return dt;
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
            return GetLastWeekdayOfMonth(date.Year, date.Month, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return GetLastWeekdayOfMonth(date.Year, date.Month, dayOfWeek, date.Offset);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, EssentialsDateMonth month, DayOfWeek dayOfWeek) {
            return GetLastWeekdayOfMonth(year, (int) month, dayOfWeek);
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
            return GetLastWeekdayOfMonth(year, (int) month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the last day of the month that matches <code>dayOfWeek</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            DateTime dt = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }
            return dt;
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
            DateTimeOffset dt = new DateTimeOffset(year, month, DateTime.DaysInMonth(year, month), 0, 0, 0, offset);
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }
            return dt;
        }

        #endregion

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTimeOffset date) {
            return date.ToString("dddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date) {
            return date.ToString("dddd", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date, CultureInfo culture) {
            return date.ToString("dddd", culture);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date, CultureInfo culture) {
            return date.ToString("dddd", culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTimeOffset date) {
            return date.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date) {
            return date.ToString("MMMM", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
            return date.ToString("MMMM", culture);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date, CultureInfo culture) {
            return date.ToString("MMMM", culture);
        }

    }

}