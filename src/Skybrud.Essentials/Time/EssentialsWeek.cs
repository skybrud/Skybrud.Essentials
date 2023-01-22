using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a week as defined by the <strong>ISO 8601</strong> specification.
    /// </summary>
    public class EssentialsWeek : IEnumerable<EssentialsDate>, IComparable, IComparable<EssentialsWeek> {

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

        /// <summary>
        /// Gets whether the week represents the week month.
        /// </summary>
        public bool IsCurrent => this == Current;

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
        /// Returns a timestamp representing the start of the week, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the week.</returns>
        public EssentialsTime GetStartOfWeek() {
            return GetStartOfWeek(null);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the month.</returns>
        public EssentialsTime GetStartOfWeek(TimeZoneInfo? timeZone) {
            timeZone ??= TimeZoneInfo.Local;
            return new EssentialsTime(Start.Year, Start.Month, Start.Day, 0, 0, 0, timeZone);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the year, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the year.</returns>
        public EssentialsTime GetEndOfWeek() {
            return GetEndOfWeek(null);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the year, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the year.</returns>
        public EssentialsTime GetEndOfWeek(TimeZoneInfo? timeZone) {
            timeZone ??= TimeZoneInfo.Local;
            return new EssentialsTime(End.Year, End.Month, End.Day, 12, 0, 0, timeZone).GetEndOfDay(timeZone);
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

        /// <summary>
        /// Compares the value of this instance to a specified object that contains an <see cref="EssentialsWeek"/>
        /// value, and returns an integer value that indicates whether this instance is earlier than, the same as, or
        /// later than the specified <see cref="EssentialsWeek"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/> parameter.</returns>
        public int CompareTo(object? value) {
            return value switch {
                null => 1,
                EssentialsWeek week => CompareTo(week),
                _ => throw new ArgumentException("Object must be of type EssentialsWeek.")
            };
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="EssentialsMonth"/> value and returns an
        /// integer value that indicates whether this instance is lower than, the same as, or greater than the
        /// specified <see cref="EssentialsMonth"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(EssentialsWeek? value) {
            if (value is null) return 1;
            if (value.Year < Year) return +1;
            if (value.Year > Year) return -1;
            return WeekNumber.CompareTo(value.WeekNumber);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsWeek"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsWeek"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is EssentialsWeek week && Equals(week);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsWeek"/> equals the specified <paramref name="week"/>.
        /// </summary>
        /// <param name="week">The week to compare.</param>
        /// <returns>Whether this <see cref="EssentialsWeek"/> equals the specified <paramref name="week"/>.</returns>
        public bool Equals(EssentialsWeek? week) {
            return this == week;
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDate"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return Year.GetHashCode() + WeekNumber.GetHashCode();
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

        /// <summary>
        /// Returns the week representing the earliest period in time.
        /// </summary>
        /// <param name="a">The first week.</param>
        /// <param name="b">The second week.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Min(EssentialsWeek a, EssentialsWeek b) {
            return a > b ? b : a;
        }

        /// <summary>
        /// Returns the week representing the earliest period in time.
        /// </summary>
        /// <param name="a">The first week.</param>
        /// <param name="b">The second week.</param>
        /// <param name="c">The third week.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Min(EssentialsWeek a, EssentialsWeek b, EssentialsWeek c) {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// Returns the week representing the earliest period in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsWeek"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Min(params EssentialsWeek[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the week representing the earliest period in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsWeek"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Min(IEnumerable<EssentialsWeek> values) {
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the week representing the latest period in time.
        /// </summary>
        /// <param name="a">The first week.</param>
        /// <param name="b">The second week.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Max(EssentialsWeek a, EssentialsWeek b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the week representing the latest period in time.
        /// </summary>
        /// <param name="a">The first week.</param>
        /// <param name="b">The second week.</param>
        /// <param name="c">The third week.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Max(EssentialsWeek a, EssentialsWeek b, EssentialsWeek c) {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// Returns the week representing the latest period in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsWeek"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Max(params EssentialsWeek[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Max(x => x)!;
        }

        /// <summary>
        /// Returns the week representing the latest period in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsWeek"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public static EssentialsWeek Max(IEnumerable<EssentialsWeek> values) {
            return values.Max(x => x)!;
        }

        private static int CompareTo(EssentialsWeek? a, EssentialsWeek? b) {
            if (a is null) return b is null ? 0 : -1;
            return a.CompareTo(b);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Gets whether the week represented by two instances of <see cref="EssentialsWeek"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if the two instances represent the same week; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) == 0;
        }

        /// <summary>
        /// Gets whether the week represented by two instances of <see cref="EssentialsWeek"/> are different
        /// from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if the two instances represents two different weeks; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) != 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="d1"/> is less than <paramref name="d2"/>, otherwise <see langword="false"/>.</returns>
        public static bool operator <(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) < 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="d1"/> is less than or equal to <paramref name="d2"/>, otherwise <see langword="false"/>.</returns>
        public static bool operator <=(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) <= 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="d1"/> is greater than <paramref name="d2"/>, otherwise <see langword="false"/>.</returns>
        public static bool operator >(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) > 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsWeek"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsWeek"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>, otherwise <see langword="false"/>.</returns>
        public static bool operator >=(EssentialsWeek? d1, EssentialsWeek? d2) {
            return CompareTo(d1, d2) >= 0;
        }

        #endregion

    }

}