using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a week as defined by the <strong>ISO 8601</strong> specification.
    /// </summary>
    public class EssentialsWeek : IEnumerable<EssentialsDate> {

        #region Properties

        /// <summary>
        /// Gets the year of the week.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Alias of <see cref="WeekNumber"/>.
        /// </summary>
        [Obsolete("Use the WeekNumber property instead.")]
        public int Week => WeekNumber;

        /// <summary>
        /// Gets the number of the week.
        /// </summary>
        public int WeekNumber { get; }

        /// <summary>
        /// Returns a numeric value representing both the year and week number.
        /// </summary>
        public int YearAndWeek => Year * 1000 + WeekNumber;

        /// <summary>
        /// Gets a reference to the timestamp representing the start of the week.
        /// </summary>
        public EssentialsTime Start { get; }

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the week.
        /// </summary>
        public EssentialsTime End { get; }

        /// <summary>
        /// Gets an instance representing the current <strong>ISO 8601</strong> week according to the local time zone.
        /// </summary>
        public static EssentialsWeek Current => new(DateTimeOffset.Now);

        /// <summary>
        /// Gets an instance representing the current <strong>ISO 8601</strong> week according to Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsWeek CurrentUtc => new(DateTimeOffset.UtcNow);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/> and <paramref name="week"/>. The week will be based on the local time zone.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week number.</param>
        public EssentialsWeek(int year, int week) : this(year, week, TimeZoneInfo.Local) { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="week"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week number.</param>
        /// <param name="offset">The offset.</param>
        public EssentialsWeek(int year, int week, TimeSpan offset) {
            WeekNumber = week;
            Year = year;
            Start = Iso8601Utils.FromWeekNumber(year, week, offset);
            End = Start.GetEndOfWeek();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="week"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="week">The week number.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsWeek(int year, int week, TimeZoneInfo? timeZone) {
            WeekNumber = week;
            Year = year;
            Start = EssentialsTime.FromIso8601Week(year, week, timeZone);
            End = Start.GetEndOfWeek(timeZone);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        public EssentialsWeek(DateTimeOffset timestamp) {
            WeekNumber = Iso8601Utils.GetWeekNumber(timestamp);
            Start = TimeUtils.GetStartOfWeek(timestamp);
            End = TimeUtils.GetEndOfWeek(timestamp);
            Year = GetYearNumber();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="timestamp"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsWeek(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {
            WeekNumber = Iso8601Utils.GetWeekNumber(timestamp);
            Start = TimeUtils.GetStartOfWeek(timestamp, timeZone);
            End = TimeUtils.GetEndOfWeek(timestamp, timeZone);
            Year = GetYearNumber();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        public EssentialsWeek(EssentialsTime timestamp) {
            WeekNumber = timestamp.WeekNumber;
            Start = timestamp.GetStartOfWeek();
            End = timestamp.GetEndOfWeek();
            Year = GetYearNumber();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The dare.</param>
        public EssentialsWeek(EssentialsDate date) {
            WeekNumber = date.WeekNumber;
            Start = date.GetStartOfWeek();
            End = date.GetEndOfWeek();
            Year = GetYearNumber();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="date"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="date">The dare.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsWeek(EssentialsDate date, TimeZoneInfo timeZone) {
            WeekNumber = date.WeekNumber;
            Start = date.GetStartOfWeek(timeZone);
            End = date.GetEndOfWeek(timeZone);
            Year = GetYearNumber();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        public EssentialsWeek(int year, int month, int day) : this(new EssentialsDate(year, month, day)) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsWeek"/> representing the previous week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public EssentialsWeek GetPreviousWeek() {
            return new EssentialsWeek(Start.DateTimeOffset.AddDays(-4), Start.TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsWeek"/> representing the next week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public EssentialsWeek GetNextWeek() {
            return new EssentialsWeek(End.DateTimeOffset.AddDays(+4), Start.TimeZone);
        }

        /// <summary>
        /// Returns a string representation of the ISO 8601 week - eg. <c>2022-W49</c> or <c>2023-W01</c>.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return $"{Year}-W{WeekNumber:00}";
        }

        /// <summary>
        /// Returns an enumerator that iterates through the days of the week.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the days of the week.</returns>
        public IEnumerator<EssentialsDate> GetEnumerator() {

            EssentialsDate start = new(Start);
            EssentialsDate end = new(End);

            for (EssentialsDate day = start; day <= end; day = day.AddDays(1)) {
                yield return day;
            }

        }

        /// <summary>
        /// Returns an instance of <see cref="EssentialsYear"/> representing the ISO 8601 year of this week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public EssentialsYear GetYear() {
            return new EssentialsYear(Year);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private int GetYearNumber() {
            if (End.Month == 1 && WeekNumber == 1) return End.Year;
            if (Start.Month == 12 && WeekNumber >= 50) return Start.Year;
            return Start.Year;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="input"/> string representation of an ISO 8601 week into an instance of
        /// <see cref="EssentialsWeek"/>. If <paramref name="input"/> is either <see langword="null"/> or white space,
        /// <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string identifying the ISO 8601 week.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek? Parse(string input) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input, out EssentialsWeek? result)) return result;
            throw new Exception("Specified input string is not a valid week.");
        }

        /// <summary>
        /// Tries to convert the specified string representation of an ISO 8601 week to its <see cref="EssentialsWeek"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains the week to convert.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsWeek"/> value equivalent to
        /// the week, if the conversion succeeded, or <see langword="null"/>, if the conversion failed. The conversion
        /// fails if the input parameter is <see langword="null"/> or does not contain a valid string representation of
        /// a date. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the input parameter is successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string input, [NotNullWhen(true)] out EssentialsWeek? result) {

            if (string.IsNullOrWhiteSpace(input)) {
                result = null;
                return false;
            }

            if (RegexUtils.IsMatch(input, "^([0-9]{4})(-|-W|W)([0-9]{1,2})$", out int year, out int _, out int week)) {
                result = new EssentialsWeek(year, week);
                return true;
            }

            result = null;
            return false;

        }

        #endregion

    }

}