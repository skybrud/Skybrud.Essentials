using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a date without a time.
    /// </summary>
    public class EssentialsDate {

        private DateTime _dateTime;

        #region Properties

        /// <summary>
        /// Gets the year.
        /// </summary>
        public int Year => _dateTime.Year;

        /// <summary>
        /// Gets the month.
        /// </summary>
        public int Month => _dateTime.Month;

        /// <summary>
        /// Gets the day.
        /// </summary>
        public int Day => _dateTime.Day;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="DateTime"/>.</param>
        public EssentialsDate(DateTime time) {
            _dateTime = time;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="DateTimeOffset"/>.</param>
        public EssentialsDate(DateTimeOffset time) {
            _dateTime = time.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="EssentialsDateTime"/>.</param>
        public EssentialsDate(EssentialsDateTime time) {
            _dateTime = time.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="EssentialsTime"/>.</param>
        public EssentialsDate(EssentialsTime time) {
            _dateTime = time.DateTimeOffset.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        public EssentialsDate(int year, int month, int day) {
            _dateTime = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the start of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero);
        }

        /// <summary>
        /// Gets the start of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone);
        }

        /// <summary>
        /// Gets the end of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfDay();
        }

        /// <summary>
        /// Gets the end of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfDay();
        }

        /// <summary>
        /// Gets the start of the week, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetStartOfWeek();
        }

        /// <summary>
        /// Gets the start of the week, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetStartOfWeek();
        }

        /// <summary>
        /// Gets the end of the week, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfWeek();
        }

        /// <summary>
        /// Gets the end of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfWeek();
        }

        /// <summary>
        /// Gets the start of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetStartOfMonth();
        }

        /// <summary>
        /// Gets the start of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetStartOfMonth();
        }

        /// <summary>
        /// Gets the end of the month, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfMonth();
        }

        /// <summary>
        /// Gets the end of the month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfMonth();
        }

        #endregion

        #region Static methods
        
        public static EssentialsDate Parse(string input) {
            
            // Is "input" an empty string?
            if (String.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        public static EssentialsDate Parse(string input, IFormatProvider formatProvider) {
            
            // Is "input" an empty string?
            if (String.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input, formatProvider);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        public static EssentialsTime Parse(string input, IFormatProvider formatProvider, DateTimeStyles styles) {
            
            // Is "input" an empty string?
            if (String.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input, formatProvider, styles);

            // Intialize a new instance
            return new EssentialsTime(dt);

        }

        #endregion

    }

}