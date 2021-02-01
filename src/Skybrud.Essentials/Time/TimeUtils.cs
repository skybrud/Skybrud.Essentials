using System;
using System.Globalization;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.Rfc2822;
using Skybrud.Essentials.Time.Rfc822;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Utility class with various static helper methods for working with date and time.
    /// </summary>
    public static partial class TimeUtils {

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the date identified by the specified
        /// <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="then">The date.</param>
        /// <param name="year">The year of the date to compare against.</param>
        /// <param name="month">The year of the date to compare against.</param>
        /// <param name="day">The year of the date to compare against.</param>
        /// <returns>The calculated age between thespecified date and the current date.</returns>
        public static int GetAge(DateTime then, int year, int month, int day) {
            int age = year - then.Year;
            if (month < then.Month || month == then.Month && day < then.Day) age--;
            return age;
        }

        /// <summary>
        /// Returns the age as calculated between two dates.
        /// </summary>
        /// <param name="year1">The year of the first date.</param>
        /// <param name="month1">The month of the first date.</param>
        /// <param name="day1">The day of the first date.</param>
        /// <param name="year2">The year of the date to compare against.</param>
        /// <param name="month2">The month of the date to compare against.</param>
        /// <param name="day2">The day of the date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(int year1, int month1, int day1, int year2, int month2, int day2) {
            int age = year2 - year1;
            if (month2 < month1 || month2 == month1 && day2 < day1) age--;
            return age;
        }

        #region GetAge/DateTime

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the current date.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <returns>The age calculated between the current date and <paramref name="then"/>.</returns>
        public static int GetAge(DateTime then) {
            return GetAge(then, DateTime.Today);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="dateOfBirth"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="dateOfBirth"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTime compare) {
            return GetAge(dateOfBirth, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="dateOfBirth"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="dateOfBirth"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTimeOffset compare) {
            return GetAge(dateOfBirth, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="dateOfBirth"/>. The age is calculated based on
        /// <paramref name="dt"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="dateOfBirth"/> at the moment of
        /// <paramref name="dt"/>.</returns>
        public static int GetAge(DateTime dateOfBirth, EssentialsDate dt) {
            return GetAge(dateOfBirth, dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="dateOfBirth"/>. The age is calculated based on
        /// <paramref name="dt"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="dateOfBirth"/> at the moment of
        /// <paramref name="dt"/>.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(DateTime dateOfBirth, EssentialsDateTime dt) {
            return GetAge(dateOfBirth, dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="dateOfBirth"/>. The age is calculated based on
        /// <paramref name="dt"/>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="dateOfBirth"/> at the moment of
        /// <paramref name="dt"/>.</returns>
        public static int GetAge(DateTime dateOfBirth, EssentialsTime dt) {
            return GetAge(dateOfBirth, dt.DateTimeOffset);
        }

        #endregion

        #region GetAge/DateTimeOffset

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the current date.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <returns>The age calculated between the current date and <paramref name="then"/>.</returns>
        public static int GetAge(DateTimeOffset then) {
            return GetAge(then, (DateTimeOffset) DateTime.UtcNow);
        }

        /// <summary>
        /// Returns the age, from the specified <paramref name="then"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="then"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTimeOffset then, DateTime compare) {
            DateTimeOffset a = then.ToUniversalTime();
            DateTimeOffset b = compare.ToUniversalTime();
            return GetAge(a.Year, a.Month, a.Day, b.Year, b.Month, b.Day);
        }

        /// <summary>
        /// Returns the age, from the specified <paramref name="then"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="then"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTimeOffset then, DateTimeOffset compare) {
            DateTimeOffset a = then.ToUniversalTime();
            DateTimeOffset b = compare.ToUniversalTime();
            return GetAge(a.Year, a.Month, a.Day, b.Year, b.Month, b.Day);
        }
        
        /// <summary>
        /// Gets the current age, from the specified <paramref name="then"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="then"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTimeOffset then, EssentialsDate compare) {
            DateTimeOffset a = then.ToUniversalTime();
            return GetAge(a.Year, a.Month, a.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="then"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="then"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(DateTimeOffset then, EssentialsDateTime compare) {
            DateTimeOffset a = then.ToUniversalTime();
            return GetAge(a.Year, a.Month, a.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Gets the current age, from the specified <paramref name="then"/>. The age is calculated based on
        /// <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date used for calculating the age.</param>
        /// <returns>The age based on the specified <paramref name="then"/> at the moment of
        /// <paramref name="compare"/>.</returns>
        public static int GetAge(DateTimeOffset then, EssentialsTime compare) {
            DateTimeOffset a = then.ToUniversalTime();
            DateTimeOffset b = compare.ToUniversalTime().DateTimeOffset;
            return GetAge(a.Year, a.Month, a.Day, b.Year, b.Month, b.Day);
        }

        #endregion

        #region GetAge/EssentialsDate

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the current date.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <returns>The age calculated between the current date and <paramref name="then"/>.</returns>
        public static int GetAge(EssentialsDate then) {
            return GetAge(then, EssentialsDate.Today);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsDate then, DateTime compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsDate then, DateTimeOffset compare) {
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsDate then, EssentialsDate compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDate then, EssentialsDateTime compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsDate then, EssentialsTime compare) {
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        #endregion

        #region GetAge/EssentialsDateTime

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the current date.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <returns>The age calculated between the current date and <paramref name="then"/>.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then) {
            return GetAge(then, DateTime.Today);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then, DateTime compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then, DateTimeOffset compare) {
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then, EssentialsDate compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then, EssentialsDateTime compare) {
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsDateTime then, EssentialsTime compare) {
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        #endregion

        #region GetAge/EssentialsTime

        /// <summary>
        /// Returns the age as calculated between <paramref name="then"/> and the current date.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <returns>The age calculated between the current date and <paramref name="then"/>.</returns>
        public static int GetAge(EssentialsTime then) {
            return GetAge(then, EssentialsTime.Today);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsTime then, DateTime compare) {
            then = then.ToUniversalTime();
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsTime then, DateTimeOffset compare) {
            then = then.ToUniversalTime();
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsTime then, EssentialsDate compare) {
            then = then.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        [Obsolete("Use EssentialsTime instead of EssentialsDateTime.")]
        public static int GetAge(EssentialsTime then, EssentialsDateTime compare) {
            then = then.ToUniversalTime();
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        /// <summary>
        /// Returns the age as calculated between the two dates <paramref name="then"/> and <paramref name="compare"/>.
        /// </summary>
        /// <param name="then">The date of birth.</param>
        /// <param name="compare">The date to compare against.</param>
        /// <returns>The calculated age between the two dates.</returns>
        public static int GetAge(EssentialsTime then, EssentialsTime compare) {
            then = then.ToUniversalTime();
            compare = compare.ToUniversalTime();
            return GetAge(then.Year, then.Month, then.Day, compare.Year, compare.Month, compare.Day);
        }

        #endregion

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified
        /// <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTime date) {
            return date.Day + GetDaySuffix(date);
        }

        /// <summary>
        /// Gets the day of the month along with the English ordinal suffix based on the specified
        /// <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumberAndSuffix(DateTimeOffset date) {
            return GetDayNumberAndSuffix(date.Date);
        }

        /// <summary>
        /// Gets the English ordinal suffix of the day based on the specified <paramref name="date"/>.
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
        /// Gets the English ordinal suffix of the day based on the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The day ordinal suffix.</returns>
        public static string GetDaySuffix(DateTimeOffset date) {
            return GetDaySuffix(date.Date);
        }

        /// <summary>
        /// Gets the week number of <paramref name="date"/> according to the <strong>ISO 8601</strong> specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        [Obsolete("Use Iso8601Utils.GetWeekNumber method instead.")]
        public static int GetIso8601WeekNumber(DateTime date) {
            return Iso8601Utils.GetWeekNumber(date);
        }

        /// <summary>
        /// Gets the week number of <paramref name="date"/> according to the <strong>ISO 8601</strong> specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        [Obsolete("Use Iso8601Utils.GetWeekNumber method instead.")]
        public static int GetIso8601WeekNumber(DateTimeOffset date) {
            return Iso8601Utils.GetWeekNumber(date.DateTime);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the specified day is weekday; otherwise <c>false</c>.</returns>
        public static bool IsWeekday(DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the specified day is weekday; otherwise <c>false</c>.</returns>
        public static bool IsWeekday(DateTimeOffset date) {
            return IsWeekday(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the specified day is weekend; otherwise <c>false</c>.</returns>
        public static bool IsWeekend(DateTime date) {
            return !IsWeekday(date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is in the weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the specified day is weekend; otherwise <c>false</c>.</returns>
        public static bool IsWeekend(DateTimeOffset date) {
            return IsWeekend(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the year of the specified <paramref name="date"/> is a leap year; otherwise
        /// <c>false</c>.</returns>
        public static bool IsLeapYear(DateTime date) {
            return IsLeapYear(date.Year);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="date"/> is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if the year of the specified <paramref name="date"/> is a leap year; otherwise
        /// <c>false</c>.</returns>
        public static bool IsLeapYear(DateTimeOffset date) {
            return IsLeapYear(date.Date);
        }

        /// <summary>
        /// Gets whether the specified <paramref name="year"/> is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns><c>true</c> if the specified year is a leap year; otherwise <c>false</c>.</returns>
        public static bool IsLeapYear(int year) {
            return DateTime.DaysInMonth(year, 2).Equals(29);
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The elapsed seconds since <paramref name="date"/>.</returns>
        public static double GetElapsedSeconds(DateTime date) {
            return DateTime.Now.Subtract(date).TotalSeconds;
        }

        /// <summary>
        /// Gets the elapsed seconds since the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The elapsed seconds since <paramref name="date"/>.</returns>
        public static double GetElapsedSeconds(DateTimeOffset date) {
            // TODO: Should this be based on DateTimeOffset? And is there a difference?
            return GetElapsedSeconds(date.DateTime);
        }

        /// <summary>
        /// Returns whether <paramref name="date"/> is within the last number of specified <paramref name="days"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns><c>true</c> if the <paramref name="date"/> is within the last number of
        /// <paramref name="days"/>, otherwise <c>false</c>.</returns>
        public static bool IsDateWithinLastDays(DateTime date, int days) {
            double lastDays = (double) 0 - days;
            DateTime startDate = date.AddDays(lastDays);
            return date >= startDate;
        }

        /// <summary>
        /// Returns whether <paramref name="date"/> is within the last number of specified <paramref name="days"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns <c>true</c> if the <paramref name="date"/> is within the last number of
        /// <paramref name="days"/>, otherwise <c>false</c>.
        /// </returns>
        public static bool IsDateWithinLastDays(DateTimeOffset date, int days) {
            return IsDateWithinLastDays(date.DateTime, days);
        }

        #region GetFirstDayOfMonth

        /// <summary>
        /// Gets the first day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime GetFirstDayOfMonth(DateTime date) {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Gets the first day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the first day of the month.</returns>
        public static DateTimeOffset GetFirstDayOfMonth(DateTimeOffset date) {
            return new DateTimeOffset(date.Year, date.Month, 1, 0, 0, 0, date.Offset);
        }

        #endregion

        #region GetLastDayOfMonth

        /// <summary>
        /// Gets the last day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(DateTime date) {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59);
        }

        /// <summary>
        /// Gets the last day of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the last day of the month.</returns>
        public static DateTimeOffset GetLastDayOfMonth(DateTimeOffset date) {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTimeOffset(date.Year, date.Month, daysInMonth, 23, 59, 59, date.Offset);
        }

        #endregion

        #region GetFirstDayOfWeek

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date) {
            return GetFirstDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date) {
            return GetFirstDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/> and based on <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return date.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Gets the first day of the week of the specified <paramref name="date"/> and based on <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the first day of the week.</returns>
        public static DateTimeOffset GetFirstDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            int diff = date.DayOfWeek - startOfWeek;
            if (diff < 0) diff += 7;
            return date.AddDays(-1 * diff).Date;
        }

        #endregion

        #region GetLastDayOfWeek

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date) {
            return GetLastDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/>. Monday is considered the first day of
        /// the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date) {
            return GetLastDayOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/> and based on <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
        }

        /// <summary>
        /// Gets the last day of the week of the specified <paramref name="date"/> and based on <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="DayOfWeek.Monday"/> or
        /// <see cref="DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the last day of the week.</returns>
        public static DateTimeOffset GetLastDayOfWeek(DateTimeOffset date, DayOfWeek startOfWeek) {
            return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
        }

        #endregion

        #region GetFirstWeekdayOfMonth

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>.
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(DateTime date, DayOfWeek dayOfWeek) {
            return GetFirstWeekdayOfMonth(date.Year, date.Month, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetFirstWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return GetFirstWeekdayOfMonth(date.Year, date.Month, dayOfWeek, date.Offset);
        }

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, EssentialsDateMonthName month, DayOfWeek dayOfWeek) {
            return GetFirstWeekdayOfMonth(year, (int) month, dayOfWeek);
        }

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        public static DateTimeOffset GetFirstWeekdayOfMonth(int year, EssentialsDateMonthName month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return GetFirstWeekdayOfMonth(year, (int) month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetFirstWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            DateTime dt = new DateTime(year, month, 1);
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(1);
            }
            return dt;
        }

        /// <summary>
        /// Gets the first day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
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
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetLastWeekdayOfMonth(DateTime date, DayOfWeek dayOfWeek) {
            return GetLastWeekdayOfMonth(date.Year, date.Month, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="date">A date in the month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(DateTimeOffset date, DayOfWeek dayOfWeek) {
            return GetLastWeekdayOfMonth(date.Year, date.Month, dayOfWeek, date.Offset);
        }

        /// <summary>
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, EssentialsDateMonthName month, DayOfWeek dayOfWeek) {
            return GetLastWeekdayOfMonth(year, (int) month, dayOfWeek);
        }

        /// <summary>
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, EssentialsDateMonthName month, DayOfWeek dayOfWeek, TimeSpan offset) {
            return GetLastWeekdayOfMonth(year, (int) month, dayOfWeek, offset);
        }

        /// <summary>
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <returns>An instance of <see cref="DateTime"/> representing the day.</returns>
        public static DateTime GetLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek) {
            DateTime dt = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }
            return dt;
        }

        /// <summary>
        /// Gets the last day of the month that matches <paramref name="dayOfWeek"/>..
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="dayOfWeek">The weekday to match.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/> representing the day.</returns>
        public static DateTimeOffset GetLastWeekdayOfMonth(int year, int month, DayOfWeek dayOfWeek, TimeSpan offset) {
            DateTimeOffset dt = new DateTimeOffset(year, month, DateTime.DaysInMonth(year, month), 0, 0, 0, offset);
            while (dt.DayOfWeek != dayOfWeek) {
                dt = dt.AddDays(-1);
            }
            return dt;
        }

        #endregion

        #region GetDayName

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetDayName(DayOfWeek day) {
            return CultureInfo.InvariantCulture.DateTimeFormat.GetDayName(day);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetDayName(DateTime date) {
            return GetDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetDayName(DateTimeOffset date) {
            return GetDayName(date.DayOfWeek);
        }

        #endregion

        #region GetAbbreviatedDayName

        /// <summary>
        /// Gets the abbreviated English name of the day.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetAbbreviatedDayName(DayOfWeek day) {
            return CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedDayName(day);
        }

        /// <summary>
        /// Gets the abbreviated English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetAbbreviatedDayName(DateTime date) {
            return GetAbbreviatedDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the abbreviated English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the day.</returns>
        public static string GetAbbreviatedDayName(DateTimeOffset date) {
            return GetAbbreviatedDayName(date.DayOfWeek);
        }

        #endregion

        #region GetLocalDayName

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DayOfWeek day) {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(day);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DateTime date) {
            return GetLocalDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date) {
            return GetLocalDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DayOfWeek day, CultureInfo culture) {
            return culture.DateTimeFormat.GetDayName(day);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DateTime date, CultureInfo culture) {
            return GetLocalDayName(date.DayOfWeek, culture);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetLocalDayName(DateTimeOffset date, CultureInfo culture) {
            return GetLocalDayName(date.DayOfWeek, culture);
        }

        #endregion

        #region GetAbbreviatedLocalDayName

        /// <summary>
        /// Gets the abbreviated name of the day according to the current culture.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DayOfWeek day) {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(day);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DateTime date) {
            return GetAbbreviatedLocalDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DateTimeOffset date) {
            return GetAbbreviatedLocalDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DayOfWeek day, CultureInfo culture) {
            return culture.DateTimeFormat.GetAbbreviatedDayName(day);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DateTime date, CultureInfo culture) {
            return GetAbbreviatedLocalDayName(date.DayOfWeek, culture);
        }

        /// <summary>
        /// Gets the abbreviated name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public static string GetAbbreviatedLocalDayName(DateTimeOffset date, CultureInfo culture) {
            return GetAbbreviatedLocalDayName(date.DayOfWeek, culture);
        }

        #endregion

        #region GetMonthName

        /// <summary>
        /// Gets the English name of the specified <paramref name="month"/>.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>The English name of the month.</returns>
        public static string GetMonthName(int month) {
            return CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the month.</returns>
        public static string GetMonthName(DateTime date) {
            return GetMonthName(date.Month);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The English name of the month.</returns>
        public static string GetMonthName(DateTimeOffset date) {
            return GetMonthName(date.Month);
        }

        #endregion

        #region GetAbbreviatedMonthName

        /// <summary>
        /// Gets the abbreviated English name of the specified <paramref name="month"/>.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>The abbreviated English name of the month.</returns>
        public static string GetAbbreviatedMonthName(int month) {
            return CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
        }

        /// <summary>
        /// Gets the abbreviated English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The abbreviated English name of the month.</returns>
        public static string GetAbbreviatedMonthName(DateTime date) {
            return GetAbbreviatedMonthName(date.Month);
        }

        /// <summary>
        /// Gets the abbreviated English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The abbreviated English name of the month.</returns>
        public static string GetAbbreviatedMonthName(DateTimeOffset date) {
            return GetAbbreviatedMonthName(date.Month);
        }

        #endregion

        #region GetLocalMonthName

        /// <summary>
        /// Gets the name of the <paramref name="month"/> according to the current culture.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(int month) {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date) {
            return GetLocalMonthName(date.Month);
        }

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date) {
            return GetLocalMonthName(date.Month);
        }

        /// <summary>
        /// Gets the name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(int month, CultureInfo culture) {
            return culture.DateTimeFormat.GetMonthName(month);
        }

        /// <summary>
        /// Gets the name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
            return GetLocalMonthName(date.Month, culture);
        }

        /// <summary>
        /// Gets the name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the month.</returns>
        public static string GetLocalMonthName(DateTimeOffset date, CultureInfo culture) {
            return GetLocalMonthName(date.Month, culture);
        }

        #endregion


        #region GetAbbreviatedLocalMonthName

        /// <summary>
        /// Gets the abbreviated name of the <paramref name="month"/> according to the current culture.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(int month) {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(DateTime date) {
            return GetAbbreviatedLocalMonthName(date.Month);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(DateTimeOffset date) {
            return GetAbbreviatedLocalMonthName(date.Month);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(int month, CultureInfo culture) {
            return culture.DateTimeFormat.GetAbbreviatedMonthName(month);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(DateTime date, CultureInfo culture) {
            return GetAbbreviatedLocalMonthName(date.Month, culture);
        }

        /// <summary>
        /// Gets the abbreviated name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The abbreviated local name of the month.</returns>
        public static string GetAbbreviatedLocalMonthName(DateTimeOffset date, CultureInfo culture) {
            return GetAbbreviatedLocalMonthName(date.Month, culture);
        }

        #endregion

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the numerical representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in <c>8</c>).
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <returns>An instance of <see cref="System.Int32"/> representing the month.</returns>
        public static int ParseNumberFromMonthName(string monthName) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            return DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the numerical representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in <c>8</c>).
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="provider">An object that supplies culture-specific format information about
        /// <paramref name="monthName"/>.</param>
        /// <returns>An instance of <see cref="System.Int32"/> representing the month.</returns>
        public static int ParseNumberFromMonthName(string monthName, IFormatProvider provider) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            return DateTime.ParseExact(monthName, "MMMM", provider).Month;
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the numerical representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in <c>8</c>) and returns a
        /// value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="result">When this method returns, contains the <see cref="System.Int32"/> value
        /// equivalent to the month name contained in <paramref name="monthName"/>, if the conversion succeeded,
        /// or <c>0</c> if the conversion failed. The conversion fails if <paramref name="monthName"/> is
        /// <c>null</c>, is an empty string (""), or does not contain a valid month name. This parameter is
        /// passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="monthName"/> was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParseNumberFromMonthName(string monthName, out int result) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            return TryParseNumberFromMonthName(monthName, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the numerical representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in <c>8</c>) and returns a
        /// value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="provider">An object that supplies culture-specific format information about
        /// <paramref name="monthName"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="System.Int32"/> value
        /// equivalent to the month name contained in <paramref name="monthName"/>, if the conversion succeeded,
        /// or <c>0</c> if the conversion failed. The conversion fails if <paramref name="monthName"/> is
        /// <c>null</c>, is an empty string (""), or does not contain a valid month name. This parameter is
        /// passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="monthName"/> was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParseNumberFromMonthName(string monthName, IFormatProvider provider, out int result) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            result = 0;
            if (!DateTime.TryParseExact(monthName, "MMMM", provider, DateTimeStyles.None, out DateTime dt)) return false;
            result = dt.Month;
            return true;
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the an instance of
        /// <see cref="EssentialsDateMonthName"/> (eg. <c>August</c> will be converted to
        /// <see cref="EssentialsDateMonthName.August"/>).
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <returns>An instance of <see cref="EssentialsDateMonthName"/> representing the month.</returns>
        public static EssentialsDateMonthName ParseEnumFromMonthName(string monthName) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            return (EssentialsDateMonthName) DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into the an instance of
        /// <see cref="EssentialsDateMonthName"/> (eg. <c>August</c> will be converted to
        /// <see cref="EssentialsDateMonthName.August"/>).
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="provider">An object that supplies culture-specific format information about
        /// <paramref name="monthName"/>.</param>
        /// <returns>An instance of <see cref="EssentialsDateMonthName"/> representing the month.</returns>
        public static EssentialsDateMonthName ParseEnumFromMonthName(string monthName, IFormatProvider provider) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            return (EssentialsDateMonthName) DateTime.ParseExact(monthName, "MMMM", provider).Month;
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into an enum representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in
        /// <see cref="EssentialsDateMonthName.August"/>) and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsDateMonthName"/> value
        /// equivalent to the month name contained in <paramref name="monthName"/>, if the conversion succeeded, or the
        /// default value of <see cref="EssentialsDateMonthName"/> if the conversion failed. The conversion fails if
        /// <paramref name="monthName"/> is <c>null</c>, is an empty string (""), or does not contain a valid
        /// month name. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="monthName"/> was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParseEnumFromMonthName(string monthName, out EssentialsDateMonthName result) {
            return TryParseEnumFromMonthName(monthName, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="monthName"/> into an enum representation of the month
        /// (eg. <c>August</c> is the eight month of the year, and will result in
        /// <see cref="EssentialsDateMonthName.August"/>) and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="monthName">The name of the month.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsDateMonthName"/> value
        /// equivalent to the month name contained in <paramref name="monthName"/>, if the conversion succeeded, or the
        /// default value of <see cref="EssentialsDateMonthName"/> if the conversion failed. The conversion fails if
        /// <paramref name="monthName"/> is <c>null</c>, is an empty string (""), or does not contain a valid
        /// month name. This parameter is passed uninitialized.</param>
        /// <param name="provider">An object that supplies culture-specific format information about
        /// <paramref name="monthName"/>.</param> <returns><c>true</c> if <paramref name="monthName"/> was converted
        /// successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseEnumFromMonthName(string monthName, IFormatProvider provider, out EssentialsDateMonthName result) {
            if (string.IsNullOrWhiteSpace(monthName)) throw new ArgumentNullException(nameof(monthName));
            result = 0;
            if (!DateTime.TryParseExact(monthName, "MMMM", provider, DateTimeStyles.None, out DateTime dt)) return false;
            result = (EssentialsDateMonthName) dt.Month;
            return true;
        }

        internal static DateTimeOffset AdjustForTimeZoneAndDaylightSavings(DateTimeOffset time, TimeZoneInfo timeZone) {

            time = TimeZoneInfo.ConvertTime(time, timeZone);

            if (timeZone.IsDaylightSavingTime(time) == false) return time;

            TimeSpan diff = timeZone.GetUtcOffset(time) - timeZone.BaseUtcOffset;

            return time.Subtract(diff);

        }

        internal static object ToFormat(DateTime value, TimeFormat format) {

            switch (format) {

                case TimeFormat.Iso8601:
                    return Iso8601Utils.ToString(value);

                case TimeFormat.Rfc822:
                    return Rfc822Utils.ToString(value);

                case TimeFormat.Rfc2822:
                    return Rfc2822Utils.ToString(value);

                case TimeFormat.UnixTime:
                    return GetUnixTimeFromDateTime(value);

                default:
                    throw new ArgumentException("Unsupported format " + format, nameof(format));

            }

        }

        internal static object ToFormat(EssentialsDate date, TimeFormat format) {

            switch (format) {

                case TimeFormat.Iso8601:
                    return date.Iso8601;

                default:
                    throw new ArgumentException("Unsupported format " + format, nameof(format));

            }

        }

        internal static object ToFormat(DateTimeOffset value, TimeFormat format) {

            switch (format) {

                case TimeFormat.Iso8601:
                    return Iso8601Utils.ToString(value);

                case TimeFormat.Rfc822:
                    return Rfc822Utils.ToString(value);

                case TimeFormat.Rfc2822:
                    return Rfc2822Utils.ToString(value);

                case TimeFormat.UnixTime:
                    return GetUnixTimeFromDateTimeOffset(value);

                default:
                    throw new ArgumentException("Unsupported format " + format, nameof(format));

            }

        }

        internal static object ToFormat(EssentialsPartialDate value, TimeFormat format) {

            switch (format) {

                case TimeFormat.Iso8601:
                    return value.ToString();

                default:
                    throw new ArgumentException("Unsupported format " + format, nameof(format));

            }

        }

    }

}