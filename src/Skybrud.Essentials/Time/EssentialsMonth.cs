using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Common;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class describing a month.
    /// </summary>
    public class EssentialsMonth : EssentialsPeriod, IComparable, IComparable<EssentialsMonth> {

        #region Properties

        /// <summary>
        /// Gets the year of the month.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets the ordinal of the month - eg. <c>1</c> for January.
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Gets the month name in English.
        /// </summary>
        public string MonthName => TimeUtils.GetMonthName(Month);

        /// <summary>
        /// Gets the month name according to the current culture.
        /// </summary>
        public string LocalMonthName => TimeUtils.GetLocalMonthName(Month);

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the start of the month.
        /// </summary>
        public new EssentialsTime Start {
            get => base.Start!;
            protected set => base.Start = value;
        }

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the end of the month.
        /// </summary>
        public new EssentialsTime End {
            get => base.End!;
            protected set => base.End = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new month based on the specified <paramref name="year"/> and <paramref name="month"/>.
        ///
        /// Timestamps for start and end will be calculated using <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        public EssentialsMonth(int year, int month) : this(year, month, TimeZoneInfo.Local) { }

        /// <summary>
        /// Initializes a new month based on the specified <paramref name="year"/> and <paramref name="month"/>.
        ///
        /// Timestamps for start and end will be calculated using <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="timeZone"></param>
        public EssentialsMonth(int year, int month, TimeZoneInfo timeZone) {
            Year = year;
            Month = month;
            Start = new EssentialsTime(year, month, 1, timeZone);
            End = Start.GetEndOfMonth(timeZone);
        }

        /// <summary>
        /// Initializes a new instance for the month containing the specified <paramref name="timestamp"/>.
        ///
        /// If <paramref name="timestamp"/> doesn't specify a timestamp (eg. only an offset), the timestamp will be converted to <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the month to be created.</param>
        public EssentialsMonth(EssentialsTime timestamp) {

            if (timestamp is null) throw new ArgumentNullException(nameof(timestamp));
            if (timestamp.TimeZone is null) timestamp = timestamp.ToTimeZone(TimeZoneInfo.Local);

            Year = timestamp.Year;
            Month = timestamp.Month;
            Start = timestamp.GetStartOfMonth();
            End = timestamp.GetEndOfMonth();

        }

        /// <summary>
        /// Initializes a new instance for the month containing the specified <paramref name="timestamp"/>.
        ///
        /// <paramref name="timestamp"/> will be converted to <see cref="TimeZoneInfo.Local"/> prior to calculating the start and end of the month.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the month to be created.</param>
        /// <param name="timeZone"></param>
        public EssentialsMonth(EssentialsTime timestamp, TimeZoneInfo? timeZone) {

            if (timestamp is null) throw new ArgumentNullException(nameof(timestamp));

            timestamp = timestamp.ToTimeZone(timeZone ?? TimeZoneInfo.Local);

            Year = timestamp.Year;
            Month = timestamp.Month;
            Start = timestamp.GetStartOfMonth();
            End = timestamp.GetEndOfMonth();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new instance representing the previous month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetPrevious() {
            if (Start is null) throw new PropertyNotSetException(nameof(Start));
            return new EssentialsMonth(Start.GetStartOfMonth(TimeZoneInfo.Local).AddDays(-1));
        }

        /// <summary>
        /// Returns a new instance representing the previous month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetPrevious(TimeZoneInfo timeZone) {
            if (Start is null) throw new PropertyNotSetException(nameof(Start));
            return new EssentialsMonth(Start.GetStartOfMonth(timeZone).AddDays(-1));
        }

        /// <summary>
        /// Returns a new instance representing the next month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetNext() {
            if (End is null) throw new PropertyNotSetException(nameof(End));
            return new EssentialsMonth(End.GetEndOfMonth(TimeZoneInfo.Local).AddDays(+1));
        }

        /// <summary>
        /// Returns a new instance representing the next month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetNext(TimeZoneInfo timeZone) {
            if (End is null) throw new PropertyNotSetException(nameof(End));
            return new EssentialsMonth(End.GetEndOfMonth(timeZone).AddDays(+1));
        }

        /// <summary>
        /// Returns a timestamp representing the start of the month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the month.</returns>
        public EssentialsTime GetStartOfMonth() {
            return GetStartOfMonth(TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the month.</returns>
        public EssentialsTime GetStartOfMonth(TimeZoneInfo? timeZone) {
            return new EssentialsTime(Year, Month, 1, timeZone ?? TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the year, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the year.</returns>
        public EssentialsTime GetStartOfYear() {
            return GetStartOfYear(TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the start of the year, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the start of the year.</returns>
        public EssentialsTime GetStartOfYear(TimeZoneInfo? timeZone) {
            return new EssentialsTime(Year, 1, 1, timeZone ?? TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the end of the month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the month.</returns>
        public EssentialsTime GetEndOfMonth() {
            return GetEndOfMonth(TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the end of the month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the month.</returns>
        public EssentialsTime GetEndOfMonth(TimeZoneInfo? timeZone) {
            return new EssentialsTime(Year, Month, DateTime.DaysInMonth(Year, Month), timeZone ?? TimeZoneInfo.Local).GetEndOfDay();
        }

        /// <summary>
        /// Returns a timestamp representing the end of the year, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the year.</returns>
        public EssentialsTime GetEndOfYear() {
            return GetEndOfYear(TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns a timestamp representing the end of the year, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used. Defaults to <see cref="TimeZoneInfo.Local"/> it not specified.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the end of the year.</returns>
        public EssentialsTime GetEndOfYear(TimeZoneInfo? timeZone) {
            return new EssentialsTime(Year, 12, 31, timeZone ?? TimeZoneInfo.Local).GetEndOfDay();
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains an <see cref="EssentialsMonth"/>
        /// value, and returns an integer value that indicates whether this instance is earlier than, the same as, or
        /// later than the specified <see cref="EssentialsMonth"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(object? value) {
            return value switch {
                null => 1,
                EssentialsMonth month => CompareTo(month),
                _ => throw new ArgumentException("Object must be of type EssentialsMonth.")
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
        public int CompareTo(EssentialsMonth? value) {
            if (value is null) return 1;
            if (value.Year < Year) return +1;
            if (value.Year > Year) return -1;
            return Month.CompareTo(value.Month);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsMonth"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsMonth"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is EssentialsMonth month && Equals(month);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsMonth"/> equals the specified <paramref name="month"/>.
        /// </summary>
        /// <param name="month">The month to compare.</param>
        /// <returns>Whether this <see cref="EssentialsMonth"/> equals the specified <paramref name="month"/>.</returns>
        public bool Equals(EssentialsMonth? month) {
            return this == month;
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDate"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return Year.GetHashCode() + Month.GetHashCode();
        }

        /// <summary>
        /// Returns a string representing the year and month.
        /// </summary>
        /// <returns>An instance of <see cref="string"/> representing the year and month.</returns>
        public override string ToString() {
            return $"{Year}-{Month:00}";
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an array with the months from <paramref name="startYear"/> and <paramref name="startMonth"/>.
        ///
        /// Start and end dates of each month are calculated based on <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="startYear">The year of the starting month.</param>
        /// <param name="startMonth">The starting month.</param>
        /// <param name="months">The amount of month, including the start month.</param>
        /// <returns>An array of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth[] GetMonths(int startYear, int startMonth, int months) {
            return GetMonths(startYear, startMonth, months, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns an array with the months from <paramref name="startYear"/> and <paramref name="startMonth"/>.
        ///
        /// Start and end dates of each month are calculated based on <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="startYear">The year of the starting month.</param>
        /// <param name="startMonth">The starting month.</param>
        /// <param name="months">The amount of month, including the start month.</param>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An array of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth[] GetMonths(int startYear, int startMonth, int months, TimeZoneInfo timeZone) {

            List<EssentialsMonth> temp = new();

            int year = startYear;

            for (int i = 0; i < months; i++) {
                int month = (startMonth + i - 1) % 12 + 1;
                if (i > 0 && month == 1) year++;
                temp.Add(new EssentialsMonth(year, month, timeZone));
            }

            return temp.ToArray();

        }

        /// <summary>
        /// Returns the month representing the earliest period in time.
        /// </summary>
        /// <param name="a">The first month.</param>
        /// <param name="b">The second month.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Min(EssentialsMonth a, EssentialsMonth b) {
            return a > b ? b : a;
        }

        /// <summary>
        /// Returns the month representing the earliest period in time.
        /// </summary>
        /// <param name="a">The first month.</param>
        /// <param name="b">The second month.</param>
        /// <param name="c">The third month.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Min(EssentialsMonth a, EssentialsMonth b, EssentialsMonth c) {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// Returns the month representing the earliest period in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsMonth"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Min(params EssentialsMonth[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the month representing the earliest period in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsMonth"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Min(IEnumerable<EssentialsMonth> values) {
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the month representing the latest period in time.
        /// </summary>
        /// <param name="a">The first month.</param>
        /// <param name="b">The second month.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Max(EssentialsMonth a, EssentialsMonth b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the month representing the latest period in time.
        /// </summary>
        /// <param name="a">The first month.</param>
        /// <param name="b">The second month.</param>
        /// <param name="c">The third month.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Max(EssentialsMonth a, EssentialsMonth b, EssentialsMonth c) {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// Returns the month representing the latest period in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsMonth"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Max(params EssentialsMonth[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Max(x => x)!;
        }

        /// <summary>
        /// Returns the month representing the latest period in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsMonth"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth Max(IEnumerable<EssentialsMonth> values) {
            return values.Max(x => x)!;
        }

        private static int CompareTo(EssentialsMonth? a, EssentialsMonth? b) {
            if (a is null) return b is null ? 0 : -1;
            return a.CompareTo(b);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Gets whether the month represented by two instances of <see cref="EssentialsMonth"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if the two instances represent the same month; otherwise, <c>false</c>.</returns>
        public static bool operator ==(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) == 0;
        }

        /// <summary>
        /// Gets whether the month represented by two instances of <see cref="EssentialsMonth"/> are different
        /// from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if the two instances represents two different months; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) != 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than <paramref name="d2"/>, otherwise
        /// <c>false</c>.</returns>
        public static bool operator <(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) < 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator <=(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) <= 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) > 0;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsMonth"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsMonth"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >=(EssentialsMonth? d1, EssentialsMonth? d2) {
            return CompareTo(d1, d2) >= 0;
        }

        #endregion

    }

}