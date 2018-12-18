using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {
    
    /// <summary>
    /// Class representing a specific date/day in the Gregorian calendar.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Gregorian_calendar</cref>
    /// </see>
    public class EssentialsDate {

        private readonly EssentialsDateTimeOffset _date;
        private EssentialsDateTimeOffset _start;
        private EssentialsDateTimeOffset _end;

        #region Properties


        /// <summary>
        /// Gets a reference to the timestamp representing the start of the week.
        /// </summary>
        public EssentialsDateTimeOffset Start => _start ?? (_start = _date.GetStartOfDay());

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the week.
        /// </summary>
        public EssentialsDateTimeOffset End => _end ?? (_end = _date.GetEndOfDay());

        /// <summary>
        /// Returns the day-of-month part of this <see cref="EssentialsDate"/>. The returned value is an integer between <c>1</c> and <c>31</c>.
        /// </summary>
        public int Day => _date.Day;

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsDate"/>. The returned value is an integer between <c>1</c> and <c>366</c>.
        /// </summary>
        public int DayOfYear => _date.DayOfYear;

        /// <summary>
        /// Gets the year part of this <see cref="EssentialsDate"/>. The returned value is an integer between <c>1</c> and <c>9999</c>.
        /// </summary>
        public int Year => _date.Year;

        /// <summary>
        /// Gets the day of the week of this <see cref="EssentialsDate"/>.
        /// </summary>
        public DayOfWeek DayOfWeek => _date.DateTimeOffset.DayOfWeek;

        /// <summary>
        /// Gets whether the day is in the past.
        /// </summary>
        public bool IsPast => Year < DateTimeOffset.Now.Year || (Year == DateTimeOffset.Now.Year && DayOfYear < DateTimeOffset.Now.DayOfYear);

        /// <summary>
        /// Gets whether the day matches the current day.
        /// </summary>
        public bool IsToday => Year == DateTimeOffset.Now.Year && DayOfYear == DateTimeOffset.Now.DayOfYear;

        /// <summary>
        /// Gets whether the day is in the future.
        /// </summary>
        public bool IsFuture => Year > DateTimeOffset.Now.Year || (Year == DateTimeOffset.Now.Year && DayOfYear > DateTimeOffset.Now.DayOfYear);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDateTimeOffset"/> representing the day.</param>
        public EssentialsDate(EssentialsDateTimeOffset date) {
            _date = date;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <returns>The English name of the day.</returns>
        public string GetDayName() {
            return TimeUtils.GetDayName(_date.DateTimeOffset);
        }

        /// <summary>
        /// Gets the name of the day, according to the current culture.
        /// </summary>
        /// <returns>The local name of the day.</returns>
        public string GetLocalDayName() {
            return TimeUtils.GetLocalDayName(_date.DateTimeOffset);
        }

        /// <summary>
        /// Gets the name of the day, according to the specified <paramref name="culture"/>.
        /// </summary>
        /// <param name="culture">The <see cref="CultureInfo"/> to be used.</param>
        /// <returns>The local name of the day.</returns>
        public string GetLocalDayName(CultureInfo culture) {
            return TimeUtils.GetLocalDayName(_date.DateTimeOffset.Date, culture);
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsWeek"/> representing the week of this day.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public EssentialsWeek GetWeek() {
            return new EssentialsWeek(_date);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsWeek"/> to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of value of the current <see cref="EssentialsWeek"/> object.</returns>
        public override string ToString() {
            return Start.ToString();
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsWeek"/> to its equivalent string representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsWeek"/> object as specified by <paramref name="format"/>.</returns>
        public string ToString(string format) {
            return Start.ToString(format);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsWeek"/> to its equivalent string representation using the specified <paramref name="format"/> and <paramref name="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsWeek"/> object as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return Start.ToString(format, provider);
        }

        #endregion

    }

}