﻿using System;
using System.Globalization;

using static Skybrud.Essentials.Time.Iso8601.Iso8601Constants;

namespace Skybrud.Essentials.Time.Iso8601 {

    /// <summary>
    /// Static class with various utility methods for working with the <strong>ISO 8601</strong> standard.
    /// </summary>
    public class Iso8601Utils {

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromWeekNumber(int year, int week) {
            return FromWeekNumber(year, week, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="timeZone">The time zone to convert the <see cref="DateTimeOffset"/> value to.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromWeekNumber(int year, int week, TimeZoneInfo timeZone) {

            // Must have a time zone
            if (timeZone == null) throw new ArgumentNullException(nameof(timeZone));

            // Get the start of the week
            DateTimeOffset time = FromWeekNumber(year, week, timeZone.BaseUtcOffset);

            // Adjust to the specified time zone
            time = TimeUtils.AdjustForTimeZoneAndDaylightSavings(time, timeZone);

            return time;

        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="offset">The offset to convert the <see cref="DateTimeOffset"/> value to.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromWeekNumber(int year, int week, TimeSpan offset) {

            // See: https://stackoverflow.com/a/9064954

            DateTimeOffset jan1 = new DateTimeOffset(year, 1, 1, 0, 0, 0, offset);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTimeOffset firstThursday = jan1.AddDays(daysOffset);
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int weekNum = week;
            if (firstWeek <= 1) weekNum -= 1;
            DateTimeOffset result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);

        }

        /// <summary>
        /// Gets the week number of <paramref name="date"/> according to the <strong>ISO 8601</strong> specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        public static int GetWeekNumber(DateTime date) {
            int day = (int) CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Gets the week number of <paramref name="date"/> according to the <strong>ISO 8601</strong> specification.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The <strong>ISO 8601</strong> week number.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
        /// </see>
        public static int GetWeekNumber(DateTimeOffset date) {
            return GetWeekNumber(date.Date);
        }

        /// <summary>
        /// Returns the <strong>ISO 8601</strong> week-numbering year of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An <see cref="int"/> representing the year.</returns>
        public static int GetYear(DateTime timestamp) {

            int week = GetWeekNumber(timestamp);

            switch (timestamp.Month)  {
            
                case 1 when week > 50:
                    return timestamp.Year - 1;
                
                case 12 when week == 1:
                    return timestamp.Year + 1;
                
                default:
                    return timestamp.Year;

            }

        }

        /// <summary>
        /// Returns the <strong>ISO 8601</strong> week-numbering year of the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns>An <see cref="int"/> representing the year.</returns>
        public static int GetYear(DateTimeOffset timestamp) {
            return GetYear(timestamp.DateTime);
        }

        /// <summary>
        /// Returns the amount of weeks in the specified <strong>ISO 8601</strong> <paramref name="year"/>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/ISO_week_date#Weeks_per_year</cref>
        /// </see>
        /// <see>
        ///     <cref>https://github.com/dotnet/runtime/blob/6072e4d3a7a2a1493f514cdf4be75a3d56580e84/src/libraries/System.Private.CoreLib/src/System/Globalization/ISOWeek.cs#L85</cref>
        /// </see>
        public static int GetWeeksInYear(int year) {
            static int P(int y) => (y + (y / 4) - (y / 100) + (y / 400)) % 7;
            return P(year) == 4 || P(year - 1) == 3 ? 53 : 52;
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        public static string ToString(DateTime timestamp) {
            return timestamp.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        public static string ToString(DateTimeOffset timestamp) {
            return timestamp.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8106 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Parse(string iso8601) {
            if (string.IsNullOrWhiteSpace(iso8601)) throw new ArgumentNullException(nameof(iso8601));
            return DateTimeOffset.ParseExact(iso8601, DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
        
        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> formatted date and time to its <see cref="DateTime"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8601 formatted date and time.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value
        /// equivalent to the date and time contained in <paramref name="iso8601"/>, if the conversion succeeded, or
        /// <see cref="DateTime.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="iso8601"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string iso8601, out DateTime result) {
            return DateTime.TryParseExact(iso8601, DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> formatted date and time to its <see cref="DateTimeOffset"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8601 formatted date and time.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTimeOffset"/> value
        /// equivalent to the date and time contained in <paramref name="iso8601"/>, if the conversion succeeded, or
        /// <see cref="DateTimeOffset.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="iso8601"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string iso8601, out DateTimeOffset result) {
            return DateTimeOffset.TryParseExact(iso8601, DateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

    }

}