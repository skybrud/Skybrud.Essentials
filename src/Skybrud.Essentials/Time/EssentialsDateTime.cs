using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Time.Iso8601;

// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Time {

    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Class wrapping an instance of <see cref="DateTime"/> (as an alternative to using <see cref="Nullable{DateTime}"/>).
    /// </summary>
    [JsonConverter(typeof(TimeConverter))]
    [Obsolete("Use EssentialsTime class instead.")]
    public class EssentialsDateTime : IComparable, IComparable<EssentialsDateTime>, IComparable<DateTime> {

        #region Properties

        /// <summary>
        /// Gets a <see cref="EssentialsDateTime"/> object that is set to the current date and time on this computer,
        /// expressed as the local time.
        /// </summary>
        public static EssentialsDateTime Now => new(DateTime.Now);

        /// <summary>
        /// Gets the current UNIX timestamp (amount of seconds since the start of the Unix Epoch).
        /// </summary>
        public static long CurrentUnixTimestamp => TimeUtils.GetUnixTimeFromDateTime(DateTime.Now);

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTime"/> representing the start of the Unix Epoch
        /// (AKA <c>0</c> seconds).
        /// </summary>
        public static EssentialsDateTime Zero => FromUnixTimestamp(0);

        /// <summary>
        /// Gets the current date.
        /// </summary>
        public static EssentialsDateTime Today => new(DateTime.Today);

        /// <summary>
        /// Gets a <see cref="EssentialsDateTime"/> object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsDateTime UtcNow => new(DateTime.UtcNow);

        /// <summary>
        /// Gets the wrapped <see cref="DateTime"/>.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="EssentialsDateTime"/>. The returned value is an integer
        /// between <c>1</c> and <c>31</c>.
        /// </summary>
        public int Day => DateTime.Day;

        /// <summary>
        /// Returns the day-of-week part of this <see cref="EssentialsDateTime"/>. The returned value is an integer
        /// between <c>0</c> and <c>6</c>, where <c>0</c> indicates <strong>Sunday</strong>,
        /// <c>1</c> indicates <strong>Monday</strong>, <c>2</c> indicates <strong>Tuesday</strong>,
        /// <c>3</c> indicates <strong>Wednesday</strong>, <c>4</c> indicates <strong>Thursday</strong>,
        /// <c>5</c> indicates <strong>Friday</strong>, and <c>6</c> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek => DateTime.DayOfWeek;

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsDateTime"/>. The returned value is an integer
        /// between <c>1</c> and <c>366</c>.
        /// </summary>
        public int DayOfYear => DateTime.DayOfYear;

        /// <summary>
        /// Gets the hour part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>0</c> and <c>23</c>.
        /// </summary>
        public int Hour => DateTime.Hour;

        /// <summary>
        /// Gets the kind of the underlying <see cref="DateTime"/>.
        /// </summary>
        public DateTimeKind Kind => DateTime.Kind;

        /// <summary>
        /// Gets the millisecond part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>0</c> and <c>999</c>.
        /// </summary>
        public int Millisecond => DateTime.Millisecond;

        /// <summary>
        /// Gets the minute part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>0</c> and <c>59</c>.
        /// </summary>
        public int Minute => DateTime.Minute;

        /// <summary>
        /// Gets the month part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>1</c> and <c>12</c>.
        /// </summary>
        public int Month => DateTime.Month;

        /// <summary>
        /// Gets the second part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>0</c> and <c>59</c>.
        /// </summary>
        public int Second => DateTime.Second;

        /// <summary>
        /// Gets the tick count for this <see cref="EssentialsDateTime"/>. The returned value is the number of
        /// 100-nanosecond intervals that have elapsed since <c>1/1/0001 12:00am</c>.
        /// </summary>
        public long Ticks => DateTime.Ticks;

        /// <summary>
        /// Gets the time-of-day part of this <see cref="EssentialsDateTime"/>. The returned value is a
        /// <see cref="TimeSpan"/> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay => DateTime.TimeOfDay;

        /// <summary>
        /// Returns the year part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <c>1</c> and <c>9999</c>.
        /// </summary>
        public int Year => DateTime.Year;

        /// <summary>
        /// Gets the UNIX timestamp (amount of seconds since the start of the Unix Epoch) for this
        /// <see cref="EssentialsDateTime"/>.
        /// </summary>
        public long UnixTimestamp => TimeUtils.GetUnixTimeFromDateTime(DateTime);

        /// <summary>
        /// Gets whether the year of this <see cref="EssentialsDateTime"/> is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(DateTime);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTime"/> is within a weekend.
        /// </summary>
        public bool IsWeekend => TimeUtils.IsWeekend(DateTime);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTime"/> is a weekday.
        /// </summary>
        public bool IsWeekday => TimeUtils.IsWeekday(DateTime);

        /// <summary>
        /// Gets the week number the ISO8601 week of this <see cref="EssentialsDateTime"/>.
        /// </summary>
        public int WeekNumber => Iso8601Utils.GetWeekNumber(DateTime);

        /// <summary>
        /// Gets a reference to an instance of <see cref="EssentialsDateWeek"/> representing the
        /// <strong>ISO 8601</strong> week of this
        /// <see cref="EssentialsDateTime"/>.
        /// </summary>
        public EssentialsDateWeek Week => new(DateTime);

        /// <summary>
        /// Gets the amount of days in the month.
        /// </summary>
        public int DaysInMonth => DateTime.DaysInMonth(Year, Month);

        /// <summary>
        /// Gets the English ordinal suffix of the day.
        /// </summary>
        public string DaySuffix => TimeUtils.GetDaySuffix(DateTime);

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is <c>0</c>.
        /// </summary>
        public bool IsZero => UnixTimestamp == 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is less than <c>0</c>.
        /// </summary>
        public bool IsNegative => UnixTimestamp < 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is greater than <c>0</c>.
        /// </summary>
        public bool IsPositive => UnixTimestamp > 0;

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        public string Iso8601 => TimeUtils.ToIso8601(this);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        [Obsolete("Use the Iso8601 property instead.")]
        public string ToIso8601 => TimeUtils.ToIso8601(this);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        public string Rfc822 => TimeUtils.ToRfc822(this);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        public string Rfc2822 => TimeUtils.ToRfc2822(this);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        [Obsolete("Use the Rfc2822 property instead.")]
        public string ToRfc2822 => TimeUtils.ToRfc2822(this);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <see cref="System.DateTime.MinValue"/>.
        /// </summary>
        public EssentialsDateTime() {
            DateTime = DateTime.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dt"/>.
        /// </summary>
        /// <param name="dt">The an instance <see cref="DateTime"/> the instance should be based on.</param>
        public EssentialsDateTime(DateTime dt) {
            DateTime = dt;
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <paramref name="ticks"/>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        public EssentialsDateTime(long ticks) {
            DateTime = new DateTime(ticks);
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <paramref name="ticks"/> and
        /// <paramref name="kind"/>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(long ticks, DateTimeKind kind) {
            DateTime = new DateTime(ticks, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/> and
        /// <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        public EssentialsDateTime(int year, int month, int day) {
            DateTime = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/> and <paramref name="second"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second) {
            DateTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and
        /// <paramref name="kind"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and
        /// <paramref name="millisecond"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="millisecond">The milliseconds (<c>0</c> through <c>999</c>).</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/>,
        /// <paramref name="millisecond"/> and <paramref name="kind"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="millisecond">The milliseconds (<c>0</c> through <c>999</c>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, kind);
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/> and
        /// <paramref name="day"/> for the specified <paramref name="calendar"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, Calendar calendar) {
            DateTime = new DateTime(year, month, day, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/> and <paramref name="second"/>
        /// for the specified  <paramref name="calendar"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and
        /// <paramref name="millisecond"/> for the specified
        /// <paramref name="calendar"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="millisecond">The milliseconds (<c>0</c> through <c>999</c>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and
        /// <paramref name="millisecond"/> for the specified<paramref name="calendar"/> and <paramref name="kind"/>.
        /// </summary>
        /// <param name="year">The year (<c>1</c> through <c>9999</c>).</param>
        /// <param name="month">The month (<c>1</c> through <c>12</c>).</param>
        /// <param name="day">The day (<c>1</c> through the number of days in month).</param>
        /// <param name="hour">The hours (<c>0</c> through <c>23</c>).</param>
        /// <param name="minute">The minutes (<c>0</c> through <c>59</c>).</param>
        /// <param name="second">The seconds (<c>0</c> through <c>59</c>).</param>
        /// <param name="millisecond">The milliseconds (<c>0</c> through <c>999</c>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
        }

#endif

        #endregion

        #region Member methods

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object.</returns>
        public override string ToString() {
            return DateTime.ToString(DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation
        /// using the specified <paramref name="provider"/>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as
        /// specified by <paramref name="provider"/>.</returns>
        public string ToString(IFormatProvider provider) {
            return DateTime.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation
        /// using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as
        /// specified by <paramref name="format"/>.</returns>
        public string ToString(string format) {
            return DateTime.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation
        /// using the specified <paramref name="format"/> and <paramref name="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as
        /// specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return DateTime.ToString(format, provider);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the value of the specified
        /// <see cref="System.TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// interval represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime Add(TimeSpan value) {
            return new EssentialsDateTime(DateTime.Add(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of days to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of days represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddDays(double value) {
            return new EssentialsDateTime(DateTime.AddDays(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of hours to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of hours represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddHours(double value) {
            return new EssentialsDateTime(DateTime.AddHours(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of milliseconds to the value
        /// of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional milliseconds. The value parameter can be negative or
        /// positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of milliseconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddMilliseconds(double value) {
            return new EssentialsDateTime(DateTime.AddMilliseconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of minutes to the value of
        /// this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of minutes represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddMinutes(double value) {
            return new EssentialsDateTime(DateTime.AddMinutes(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of months to the value of
        /// this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>. Or
        /// <paramref name="months"/> is less than <c>-120000</c> or greater than <c>120000</c>.</exception>
        public EssentialsDateTime AddMonths(int months) {
            return new EssentialsDateTime(DateTime.AddMonths(months));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of seconds to the value of
        /// this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of seconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddSeconds(double value) {
            return new EssentialsDateTime(DateTime.AddSeconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of ticks to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddTicks(long value) {
            return new EssentialsDateTime(DateTime.AddTicks(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of years to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of years represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddYears(int value) {
            return new EssentialsDateTime(DateTime.AddYears(value));
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="DateTime"/> value and returns an integer that
        /// indicates whether this instance is earlier than, the same as, or later than the specified
        /// <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(DateTime value) {
            return DateTime.CompareTo(value);
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="EssentialsDateTime"/> value and returns an
        /// integer that indicates whether this instance is earlier than, the same as, or later than the specified
        /// <see cref="EssentialsDateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(EssentialsDateTime? value) {
#if NET_FRAMEWORK
            return DateTime.CompareTo(value == null ? default(object) : value.DateTime);
#else
            throw new NotImplementedException();
#endif
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified <see cref="DateTime"/>
        /// value, and returns an integer that indicates whether this instance is earlier than, the same as, or later
        /// than the specified <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(object? value) {
#if NET_FRAMEWORK
            return DateTime.CompareTo(value);
#else
            throw new NotImplementedException();
#endif
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the standard date and
        /// time format specifiers.
        /// </summary>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats() {
            return DateTime.GetDateTimeFormats();
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the standard date and
        /// time format specifiers and the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information about this instance.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats(IFormatProvider provider) {
            return DateTime.GetDateTimeFormats(provider);
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the specified standard
        /// date and time format specifier.
        /// </summary>
        /// <param name="format">A standard date and time format string.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with the format standard date and time format specifier.</returns>
        public string[] GetDateTimeFormats(char format) {
            return DateTime.GetDateTimeFormats(format);
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the specified standard
        /// date and time format specifier and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about this instance.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats(char format, IFormatProvider provider) {
            return DateTime.GetDateTimeFormats(format, provider);
        }

        /// <summary>
        /// Indicates whether the internal instance of <see cref="EssentialsDateTime"/> is within the daylight saving
        /// time range for the current time zone.
        /// </summary>
        /// <summary>
        /// Returns <c>true</c> if <see cref="System.DateTime.Kind"/> is <see cref="System.DateTimeKind.Local"/>
        /// or <see cref="System.DateTimeKind.Unspecified"/> and the value of the internal instance of
        /// <see cref="System.DateTime"/> is within the daylight saving time range for the current time zone. Returns
        /// <c>false</c> if <see cref="System.DateTime.Kind"/> is <see cref="System.DateTimeKind.Utc"/>.
        /// </summary>
        public bool IsDaylightSavingTime() {
            return DateTime.IsDaylightSavingTime();
        }

        /// <summary>
        /// Serializes the internal <see cref="System.DateTime"/> object to a 64-bit binary value that subsequently can
        /// be used to recreate the <see cref="System.DateTime"/> object.
        /// </summary>
        /// <returns>A 64-bit signed integer that encodes the <see cref="System.DateTime.Kind"/> and
        /// <see cref="System.DateTime.Ticks"/> properties.</returns>
        public long ToBinary() {
            return DateTime.ToBinary();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to a Windows file time.
        /// </summary>
        /// <returns>The value of the internal <see cref="System.DateTime"/> object expressed as a Windows file time.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting file time would represent a date and
        /// time before 12:00 midnight January 1, 1601 C.E. UTC.</exception>
        public long ToFileTime() {
            return DateTime.ToFileTime();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to a Windows file time.
        /// </summary>
        /// <returns>The value of the internal <see cref="System.DateTime"/> object expressed as a Windows file time.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting file time would represent a date and
        /// time before 12:00 midnight January 1, 1601 C.E. UTC.</exception>
        public long ToFileTimeUtc() {
            return DateTime.ToFileTimeUtc();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to local time.
        /// </summary>
        /// <returns>An object whose <see cref="System.DateTime.Kind"/> property is
        /// <see cref="System.DateTimeKind.Local"/>, and whose value is the local time equivalent to the value of the
        /// internal <see cref="System.DateTime"/> object, or <see cref="System.DateTime.MaxValue"/> if the converted
        /// value is too large to be represented by a <see cref="System.DateTime"/> object, or
        /// <see cref="System.DateTime.MinValue"/> if the converted value is too small to be represented as a
        /// <see cref="System.DateTime"/> object.</returns>
        public EssentialsDateTime ToLocalTime() {
            return DateTime.ToLocalTime();
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent long date string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the long date string representation of the current
        /// <see cref="EssentialsDateTime"/> object.</returns>
        public string ToLongDateString() {
            return DateTime.ToLongDateString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent long time string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the long time string representation of the current
        /// <see cref="EssentialsDateTime"/> object.</returns>
        public string ToLongTimeString() {
            return DateTime.ToLongTimeString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to the equivalent OLE Automation
        /// date.
        /// </summary>
        /// <returns>A double-precision floating-point number that contains an OLE Automation date equivalent to the
        /// value of this instance.</returns>
        /// <exception cref="System.OverflowException">The value of this instance cannot be represented as an OLE
        /// Automation Date.</exception>
        public double ToOADate() {
            return DateTime.ToOADate();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent short date string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the internal
        /// <see cref="System.DateTime"/> object.</returns>
        public string ToShortDateString() {
            return DateTime.ToShortDateString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent short time string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the short time string representation of the internal
        /// <see cref="System.DateTime"/> object.</returns>
        public string ToShortTimeString() {
            return DateTime.ToShortTimeString();
        }

#endif

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object whose <see cref="System.DateTime.Kind"/> property is
        /// <see cref="DateTimeKind.Utc"/>, and whose value is the UTC equivalent to the value of the internal
        /// <see cref="System.DateTime"/> object, or <see cref="System.DateTime.MaxValue"/> if the converted value is
        /// too large to be represented by a <see cref="System.DateTime"/> object, or
        /// <see cref="System.DateTime.MinValue"/> if the converted value is too small to be represented by a
        /// <see cref="System.DateTime"/> object.</returns>
        public EssentialsDateTime ToUniversalTime() {
            return DateTime.ToUniversalTime();
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(DateTime value) {
            return DateTime.Subtract(value);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(EssentialsDateTime value) {
            if (value is null) throw new ArgumentNullException(null);
            return DateTime.Subtract(value.DateTime);
        }

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="value">The time interval to subtract.</param>
        /// <returns>An object that is equal to the date and time represented by this instance minus the time interval
        /// represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime Subtract(TimeSpan value) {
            return new EssentialsDateTime(DateTime.Subtract(value));
        }

        /// <summary>
        /// Gets the first day of the month based on this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>An instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public EssentialsDateTime GetFirstDayOfMonth() {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfMonth(DateTime));
        }

        /// <summary>
        /// Gets the last day of the month based on this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the last day of the month.</returns>
        public EssentialsDateTime GetLastDayOfMonth() {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfMonth(DateTime));
        }

        /// <summary>
        /// Gets the first day of the week based on this <see cref="EssentialsDateTime"/>. <strong>Monday</strong> is
        /// considered the first day of the week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the first day of the week.</returns>
        public EssentialsDateTime GetFirstDayOfWeek() {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfWeek(DateTime));
        }

        /// <summary>
        /// Gets the first day of the week based on this <see cref="EssentialsDateTime"/> and
        /// <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="System.DayOfWeek.Monday"/> or
        /// <see cref="System.DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the first day of the week.</returns>
        public EssentialsDateTime GetFirstDayOfWeek(DayOfWeek startOfWeek) {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfWeek(DateTime, startOfWeek));
        }

        /// <summary>
        /// Gets the last day of the week based on this <see cref="EssentialsDateTime"/>. <strong>Monday</strong> is
        /// considered the first day of the week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the last day of the week.</returns>
        public EssentialsDateTime GetLastDayOfWeek() {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfWeek(DateTime));
        }

        /// <summary>
        /// Gets the last day of the week based on this <see cref="EssentialsDateTime"/> and
        /// <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="System.DayOfWeek.Monday"/> or <see cref="System.DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the last day of the week.</returns>
        public EssentialsDateTime GetLastDayOfWeek(DayOfWeek startOfWeek) {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfWeek(DateTime, startOfWeek));
        }

        /// <summary>
        /// Gets the last day of the week based on this <see cref="EssentialsDateTime"/> and
        /// <paramref name="startOfWeek"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <see cref="System.DayOfWeek.Monday"/> or <see cref="System.DayOfWeek.Sunday"/>).</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/> representing the last day of the week.</returns>
        [Obsolete("Use overload instead.")]
        public EssentialsDateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfWeek(DateTime, startOfWeek));
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <returns>The English name of the day.</returns>
        public string GetDayName() {
            return TimeUtils.GetDayName(DateTime);
        }

        /// <summary>
        /// Gets the name of the day according to <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <returns>The local name of the day.</returns>
        public string GetLocalDayName() {
            return TimeUtils.GetLocalDayName(DateTime);
        }

        /// <summary>
        /// Gets the name of the day according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>The local name of the day.</returns>
        public string GetLocalDayName(CultureInfo culture) {
            return TimeUtils.GetLocalDayName(DateTime, culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <returns>The English name of the month.</returns>
        public string GetMonthName() {
            return TimeUtils.GetMonthName(DateTime);
        }

        /// <summary>
        /// Gets the name of the month according to current culture.
        /// </summary>
        /// <returns>The local name of the month.</returns>
        public string GetLocalMonthName() {
            return TimeUtils.GetLocalMonthName(DateTime);
        }

        /// <summary>
        /// Gets the name of the month according to current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The local name of the month.</returns>
        [Obsolete("Use overload instead")]
        public string GetLocalMonthName(DateTime date) {
            return TimeUtils.GetLocalMonthName(DateTime);
        }

        /// <summary>
        /// Gets the name of the month according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>The local name of the month.</returns>
        public string GetLocalMonthName(CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(DateTime, culture);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        [return: NotNullIfNotNull("str")]
        public static EssentialsDateTime? Parse(string? str) {
            return string.IsNullOrWhiteSpace(str) ? null : new EssentialsDateTime(DateTime.Parse(str));
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="EssentialsDateTime"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing a date and time to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsDateTime"/> value
        /// equivalent to the date and time contained in <paramref name="str"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed. The conversion fails if the <paramref name="str"/> parameter is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a date and
        /// time. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParse(string? str, [NotNullWhen(true)] out EssentialsDateTime? result) {

            if (string.IsNullOrWhiteSpace(str)) {
                result = null;
                return false;
            }

            if (DateTime.TryParse(str, out DateTime dt)) {
                result = new EssentialsDateTime(dt);
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see cref="EssentialsDateTime"/>
        /// equivalent using the specified culture-specific format information and formatting style, and returns a
        /// value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing a date and time to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about
        /// <paramref name="str"/>.</param>
        /// <param name="styles">A bitwise combination of enumeration values that defines how to interpret the parsed
        /// date in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="DateTimeStyles.None"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsDateTime"/> value
        /// equivalent to the date and time contained in <paramref name="str"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed. The conversion fails if the <paramref name="str"/> parameter is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a date and
        /// time. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParse(string? str, IFormatProvider provider, DateTimeStyles styles, [NotNullWhen(true)] out EssentialsDateTime? result) {

            if (string.IsNullOrWhiteSpace(str)) {
                result = null;
                return false;
            }

            if (DateTime.TryParse(str, provider, styles, out DateTime dt)) {
                result = new EssentialsDateTime(dt);
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(int timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(long timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(double timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Convert the specified <strong>ISO 8601</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>ISO 8601</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        [return: NotNullIfNotNull("str")]
        public static EssentialsDateTime? FromIso8601(string? str) {
            return string.IsNullOrWhiteSpace(str) ? null : new EssentialsDateTime(TimeUtils.Iso8601ToDateTime(str!));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTime"/> representing the start of the specified
        /// <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromIso8601Week(int year, int week) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromIso8601Week(year, week));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 822</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromRfc822(string str) {
            return new EssentialsDateTime(TimeUtils.Rfc822ToDateTime(str));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 2822</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 2822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        [return: NotNullIfNotNull("str")]
        public static EssentialsDateTime? FromRfc2822(string? str) {
            return string.IsNullOrWhiteSpace(str) ? null : new EssentialsDateTime(TimeUtils.Rfc822ToDateTime(str!));
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// HEST Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/>.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static implicit operator EssentialsDateTime(DateTime timestamp) {
            return new EssentialsDateTime(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static implicit operator EssentialsDateTime(long timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static implicit operator EssentialsDateTime(double timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Adds <paramref name="date"/> and <paramref name="timespan"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be added to <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime operator +(EssentialsDateTime date, TimeSpan timespan) {
            return new EssentialsDateTime(date.DateTime + timespan);
        }

        /// <summary>
        /// Subtracts <paramref name="timespan"/> from <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be subtracted from <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime operator -(EssentialsDateTime date, TimeSpan timespan) {
            return new EssentialsDateTime(date.DateTime - timespan);
        }

        /// <summary>
        /// Subtracts two instances of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>The result as an instance of <see cref="TimeSpan"/>.</returns>
        public static TimeSpan operator -(EssentialsDateTime d1, EssentialsDateTime d2) {
            return d1.DateTime - d2.DateTime;
        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTime"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if the two instances represent the same date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator ==(EssentialsDateTime? d1, EssentialsDateTime? d2) {

            // Check for NULL conditions
            object? value1 = d1;
            object? value2 = d2;
            if (value1 is null) return value2 is null;
            if (value2 is null) return false;

            // Pass the comparison on the the == operator of DateTime
            return d1!.DateTime == d2!.DateTime;

        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTime"/> are different
        /// from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if the two instances represents a different date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator !=(EssentialsDateTime? d1, EssentialsDateTime? d2) {
            return !(d1 == d2);
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than <paramref name="d2"/>, otherwise
        /// <c>false</c>.</returns>
        public static bool operator <(EssentialsDateTime? d1, EssentialsDateTime? d2) {

            // Check for NULL conditions
            if (d1 is null) return d2 is not null;
            if (d2 is null) return false;

            // Pass the comparison on the the < operator of DateTime
            return d1.DateTime < d2.DateTime;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator <=(EssentialsDateTime? d1, EssentialsDateTime? d2) {
            return d1 < d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >(EssentialsDateTime? d1, EssentialsDateTime? d2) {

            // Check for NULL conditions
            if (d2 is null) return d1 is not null;
            if (d1 is null) return false;

            // Pass the comparison on the the > operator of DateTime
            return d1.DateTime > d2.DateTime;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >=(EssentialsDateTime? d1, EssentialsDateTime? d2) {
            return d1 > d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsDateTime"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsDateTime"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(object? obj) {
            EssentialsDateTime? time = obj as EssentialsDateTime;
            return time != null && (this == time);
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return DateTime.GetHashCode();
        }

#if TYPE_CODE

        /// <summary>
        /// Returns the <see cref="TypeCode"/> for value type <see cref="DateTime"/>.
        /// </summary>
        /// <returns>The enumerated constant, <see cref="TypeCode.DateTime"/>.</returns>
        public TypeCode GetTypeCode() {
            return DateTime.GetTypeCode();
        }

#endif

        #endregion

    }

    // ReSharper restore InconsistentNaming

}