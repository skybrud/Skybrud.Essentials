using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    public static class TimeHelpers {

        #region Constants

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string IsoDateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";

        #endregion

        #region Static methods

        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns the age based on the specified date of birth.</returns>
        public static int GetAge(DateTime dateOfBirth) {
            return GetAge(dateOfBirth, DateTime.Today);
        }

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
        /// <returns>The day number and ordinal suffix.</returns>
        public static string GetDaySuffix(DateTime date) {
            switch (date.Day) {
                case 1: case 21: case 31: return "st";
                case 2: case 22: return "nd";
                case 3: case 23: return "rd";
                default: return "th";
            }
        }

        /// <summary>
        /// Gets the week number of <code>date</code> according to the ISO8601 specification.
        /// </summary>
        /// <param name="date">The date.</param>
        public static int GetIso8601WeekNumber(DateTime date) {
            var day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        ///     Gets whether the specified <code>date</code> is a weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///     Returns <code>TRUE</code> if the specified day is weekday; otherwise <code>FALSE</code>.
        /// </returns>
        public static bool IsWeekday(DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        #endregion

    }

}