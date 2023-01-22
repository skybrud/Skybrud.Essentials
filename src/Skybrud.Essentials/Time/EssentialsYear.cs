using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class describing a year.
    /// </summary>
    public class EssentialsYear : EssentialsPeriod, IComparable, IComparable<EssentialsYear> {

        #region Properties

        /// <summary>
        /// Gets an instance of <see cref="EssentialsYear"/> representing the current month.
        /// </summary>
        public static EssentialsYear Current => new(DateTime.Now.Year);

        /// <summary>
        /// Gets the year.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets whether the year is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(Year);

        /// <summary>
        /// Gets the amount of days in the yeay - <c>366</c> if <see cref="IsLeapYear"/> is <c>true</c>,
        /// otherwise <c>365</c>.
        /// </summary>
        public int Days => IsLeapYear ? 366 : 365;

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the start of the year.
        /// </summary>
        public new EssentialsTime Start {
            get => base.Start!;
            protected set => base.Start = value;
        }

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the end of the year.
        /// </summary>
        public new EssentialsTime End {
            get => base.End!;
            protected set => base.End = value;
        }

        #region Calendar dates

        /// <summary>
        /// Gets the date of <strong>Palm Sunday</strong>, which falls on the Sunday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Palm_Sunday#Observance_in_the_liturgy</cref>
        /// </see>
        public DateTime PalmSunday => CalendarUtils.GetPalmSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Moundy Thursday</strong>, which falls on the Thursday before
        /// <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Maundy_Thursday</cref>
        /// </see>
        public DateTime GetMoundyThursday => CalendarUtils.GetMoundyThursday(Year);

        /// <summary>
        /// Gets the date of <strong>Good Friday</strong>, which falls on the Friday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Good_Friday</cref>
        /// </see>
        public DateTime GetGoodFriday => CalendarUtils.GetGoodFriday(Year);

        /// <summary>
        /// Gets the date of <strong>Holy Saturday</strong>, which falls on the Saturday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Holy_Saturday</cref>
        /// </see>
        public DateTime GetHolySaturday => CalendarUtils.GetHolySaturday(Year);

        /// <summary>
        /// Gets the date of <strong>Easter Sunday</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Påske#Beregning_af_p.C3.A5skedagens_dato</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter#Date</cref>
        /// </see>
        public DateTime EasterSunday => CalendarUtils.GetEasterSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Easter Monday</strong>, which falls on the Monday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter_Monday</cref>
        /// </see>
        public DateTime EasterMonday => CalendarUtils.GetEasterMonday(Year);

        /// <summary>
        /// Gets the date of <strong>General Prayer Day</strong> (or <strong>Store Bededag</strong> in Danish) - a national
        /// holiday in Denmark. It falls on the 4th Friday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Store_bededag</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Store_Bededag</cref>
        /// </see>
        public DateTime StoreBededag => CalendarUtils.Denmark.GetGeneralPrayerDay(Year);

        /// <summary>
        /// Gets the date of <strong>Ascension Day</strong>, which is celebrated on a Thursday, the fortieth day of
        /// <strong>Easter</strong> (the 6th Thursday after <strong>Moundy Thursday</strong>).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Feast_of_the_Ascension</cref>
        /// </see>
        public DateTime AscensionDay => CalendarUtils.GetAscensionDay(Year);

        /// <summary>
        /// Gets the date of <strong>Whit Sunday</strong>, which is celebrated on the 7th Sunday after
        /// <strong>Easter</strong>.
        ///
        /// Depending on the year, Whit Sunday falls within the period from the
        /// <strong>10th of May</strong> to the <strong>13th of June</strong> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whitsun</cref>
        /// </see>
        public DateTime WhitSunday => CalendarUtils.GetWhitSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Whit Monday</strong>, which is celebrated the day after
        /// <strong>Whit Sunday</strong>. Whit Sunday is the 7th Sunday after
        /// <strong>Easter</strong>.
        ///
        /// Depending on the year, Whit Monday falls within the period from the <strong>11th of May</strong> to the
        /// <strong>14th of June</strong> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whit_Monday</cref>
        /// </see>
        public DateTime WhitMonday => CalendarUtils.GetWhitMonday(Year);

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new year based on the specified <paramref name="year"/>.
        ///
        /// Timestamps for start and end will be calculated using <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        public EssentialsYear(int year) : this(year, TimeZoneInfo.Local) { }

        /// <summary>
        /// Initializes a new year based on the specified <paramref name="year"/>.
        ///
        /// Timestamps for start and end will be calculated using <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="timeZone">The time zone used for calculating the start and end of the year.</param>
        public EssentialsYear(int year, TimeZoneInfo timeZone) {
            Year = year;
            Start = new EssentialsTime(year, 1, 1, timeZone);
            End = new EssentialsTime(year, 12, 31, timeZone).GetEndOfDay();
        }

        /// <summary>
        /// Initializes a new instance for the year containing the specified <paramref name="timestamp"/>.
        ///
        /// If <paramref name="timestamp"/> doesn't specify a timestamp (eg. only an offset), the timestamp will be converted to <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the year to be created.</param>
        public EssentialsYear(EssentialsTime timestamp) {

            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));

            if (timestamp.TimeZone == null) timestamp = timestamp.ToTimeZone(TimeZoneInfo.Local);

            Year = timestamp.Year;
            Start = new EssentialsTime(timestamp.Year, 1, 1, timestamp.TimeZone);
            End = new EssentialsTime(timestamp.Year, 12, 31, timestamp.TimeZone).GetEndOfDay();

        }

        /// <summary>
        /// Initializes a new instance for the year containing the specified <paramref name="timestamp"/>.
        ///
        /// <paramref name="timestamp"/> will be converted to <see cref="TimeZoneInfo.Local"/> prior to calculating the start and end of the year.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the year to be created.</param>
        /// <param name="timeZone">The time zone used for calculating the start and end of the year.</param>
        public EssentialsYear(EssentialsTime timestamp, TimeZoneInfo timeZone) {

            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            if (timeZone == null) throw new ArgumentNullException(nameof(timeZone));

            timestamp = timestamp.ToTimeZone(timeZone);

            Year = timestamp.Year;
            Start = new EssentialsTime(timestamp.Year, 1, 1, timeZone);
            End = new EssentialsTime(timestamp.Year, 12, 31, timeZone).GetEndOfDay();

        }

        #endregion

        #region Member methods

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
        /// Returns the year representing the earliest point in time.
        /// </summary>
        /// <param name="a">The first year.</param>
        /// <param name="b">The second year.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Min(EssentialsYear a, EssentialsYear b) {
            return a > b ? b : a;
        }

        /// <summary>
        /// Returns the year representing the earliest point in time.
        /// </summary>
        /// <param name="a">The first year.</param>
        /// <param name="b">The second year.</param>
        /// <param name="c">The third year.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Min(EssentialsYear a, EssentialsYear b, EssentialsYear c) {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// Returns the year representing the earliest point in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsYear"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Min(params EssentialsYear[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the year representing the earliest point in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsYear"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Min(IEnumerable<EssentialsYear> values) {
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the year representing the latest point in time.
        /// </summary>
        /// <param name="a">The first year.</param>
        /// <param name="b">The second year.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Max(EssentialsYear a, EssentialsYear b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the year representing the latest point in time.
        /// </summary>
        /// <param name="a">The first year.</param>
        /// <param name="b">The second year.</param>
        /// <param name="c">The third year.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Max(EssentialsYear a, EssentialsYear b, EssentialsYear c) {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// Returns the year representing the latest point in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsYear"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Max(params EssentialsYear[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Max(x => x)!;
        }

        /// <summary>
        /// Returns the year representing the latest point in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsYear"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsYear"/>.</returns>
        public static EssentialsYear Max(IEnumerable<EssentialsYear> values) {
            return values.Max(x => x)!;
        }


        /// <summary>
        /// Compares the value of this instance to a specified object that contains an <see cref="EssentialsYear"/>
        /// value, and returns an integer value that indicates whether this instance is earlier than, the same as, or
        /// later than the specified <see cref="EssentialsYear"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(object? value) {
            return value switch {
                null => 1,
                EssentialsYear month => CompareTo(month),
                _ => throw new ArgumentException("Object must be of type EssentialsDate.")
            };
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="EssentialsYear"/> value and returns an
        /// integer value that indicates whether this instance is lower than, the same as, or greater than the
        /// specified <see cref="EssentialsYear"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(EssentialsYear? value) {
            return value is null ? 1 : Year.CompareTo(value.Year);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsYear"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsYear"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is EssentialsYear month && Equals(month);
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsYear"/> equals the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year to compare.</param>
        /// <returns>Whether this <see cref="EssentialsYear"/> equals the specified <paramref name="year"/>.</returns>
        public bool Equals(EssentialsYear? year) {
            return this == year;
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDate"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return Year.GetHashCode();
        }

        #endregion

        #region Static methods

        private static int CompareTo(EssentialsYear? a, EssentialsYear? b) {
            if (a is null) return b is null ? 0 : -1;
            return a.CompareTo(b);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Returns whether the years represented by two instances of <see cref="EssentialsYear"/> are equal.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><see langword="true"/> if the two instances represent the same year; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) == 0;
        }

        /// <summary>
        /// Returns whether the year represented by two instances of <see cref="EssentialsYear"/> are different from each other.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><c>true</c> if the two instances represent two different years; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) != 0;
        }

        /// <summary>
        /// Returns whether <paramref name="year1"/> is less than <paramref name="year2"/>.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><c>true</c> if <paramref name="year1"/> is less than <paramref name="year2"/>, otherwise <c>false</c>.</returns>
        public static bool operator <(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) < 0;
        }

        /// <summary>
        /// Gets whether <paramref name="year1"/> is less than or equal to <paramref name="year2"/>.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><c>true</c> if <paramref name="year1"/> is less than or equal to <paramref name="year2"/>, otherwise <c>false</c>.</returns>
        public static bool operator <=(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) <= 0;
        }

        /// <summary>
        /// Gets whether <paramref name="year1"/> is greater than <paramref name="year2"/>.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><c>true</c> if <paramref name="year1"/> is greater than <paramref name="year2"/>, otherwise <c>false</c>.</returns>
        public static bool operator >(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) > 0;
        }

        /// <summary>
        /// Gets whether <paramref name="year1"/> is greater than or equal to <paramref name="year2"/>.
        /// </summary>
        /// <param name="year1">The first instance of <see cref="EssentialsYear"/>.</param>
        /// <param name="year2">The second instance of <see cref="EssentialsYear"/>.</param>
        /// <returns><c>true</c> if <paramref name="year1"/> is greater than or equal to <paramref name="year2"/>, otherwise <c>false</c>.</returns>
        public static bool operator >=(EssentialsYear? year1, EssentialsYear? year2) {
            return CompareTo(year1, year2) >= 0;
        }

        #endregion

    }

}