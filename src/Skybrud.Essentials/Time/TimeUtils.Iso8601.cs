using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        [Obsolete("Use Iso8601.DateTimeFormat constant instead.")]
        public const string Iso8601DateFormat = Iso8601.DateTimeFormat;

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        public static string ToIso8601(DateTime timestamp) {
            return timestamp.ToString(Iso8601.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        public static string ToIso8601(DateTimeOffset timestamp) {
            return timestamp.ToString(Iso8601.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>ISO 8601</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a ISO 8601 date string.</returns>
        public static string ToIso8601(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            return ToIso8601(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8601 formatted string.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime Iso8601ToDateTime(string iso8601) {
            return Iso8601ToDateTimeOffset(iso8601).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8106 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Iso8601ToDateTimeOffset(string iso8601) {
            if (string.IsNullOrWhiteSpace(iso8601)) throw new ArgumentNullException(nameof(iso8601));
            return DateTimeOffset.ParseExact(iso8601, Iso8601.DateTimeFormat, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the start of the specified
        /// <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromIso8601Week(int year, int week) {

            // See: https://stackoverflow.com/a/9064954

            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int weekNum = week;
            if (firstWeek <= 1) weekNum -= 1;
            DateTime result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);

        }

        /// <summary>
        /// Gets an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromIso8601Week(int year, int week) {
            return new DateTimeOffset(GetDateTimeFromIso8601Week(year, week));
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="offset">The offset to convert the <see cref="DateTimeOffset"/> value to.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromIso8601Week(int year, int week, TimeSpan offset) {

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
        /// Nested class for working with date and time according to the <strong>ISO 8601</strong> standard.
        /// </summary>
        public static class Iso8601 {

            #region Constants

            /// <summary>
            /// ISO 8601 date and time format.
            /// </summary>
            public const string DateFormat = "yyyy-MM-dd";

            /// <summary>
            /// ISO 8601 date and time format.
            /// </summary>
            public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssK";

            #endregion

            #region Methods

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

            #endregion

        }

    }

}