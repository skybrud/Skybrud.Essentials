﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.Rfc2822;
using Skybrud.Essentials.Time.Rfc822;
using Skybrud.Essentials.Time.Swatch;
using Skybrud.Essentials.Time.UnixTime;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class wrapping an instance of <see cref="System.DateTimeOffset"/> (as an alternative to using <see cref="Nullable{DateTimeOffset}"/>).
    /// </summary>
    [JsonConverter(typeof(TimeConverter))]
    public class EssentialsTime : IComparable, IComparable<EssentialsTime>, IComparable<DateTimeOffset> {

        #region Static properties

        /// <summary>
        /// Gets a <see cref="EssentialsTime"/> object that is set to the current date and time on this computer,  expressed as the local time.
        /// </summary>
        public static EssentialsTime Now => new(DateTimeOffset.Now, TimeZoneInfo.Local);

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> representing the current date, according to the local time.
        /// </summary>
        public static EssentialsTime Today => new(DateTime.Today, TimeZoneInfo.Local);

        /// <summary>
        /// Gets a <see cref="EssentialsTime"/> object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsTime UtcNow => new(DateTimeOffset.UtcNow, TimeZoneInfo.Utc);

        /// <summary>
        /// Represents the earliest possible <see cref="EssentialsTime"/> value.
        /// </summary>
        public static EssentialsTime MinValue => new(DateTimeOffset.MinValue);

        /// <summary>
        /// Represents the greatest possible value of <see cref="EssentialsTime"/>.
        /// </summary>
        public static EssentialsTime MaxValue => new(DateTimeOffset.MaxValue);

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> representing the start of the Unix Epoch (AKA <c>0</c> seconds).
        /// </summary>
        public static EssentialsTime Zero => FromUnixTimeSeconds(0);

        /// <summary>
        /// Returns the amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static long CurrentUnixTimeSeconds => (long) UnixTimeUtils.CurrentSeconds;

        /// <summary>
        /// Returns the amount of milliseconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static long CurrentUnixTimeMilliseconds => (long) UnixTimeUtils.CurrentMilliseconds;

        #endregion

        #region Member properties

        /// <summary>
        /// Gets the time zone.
        /// </summary>
        public TimeZoneInfo? TimeZone { get; }

        /// <summary>
        /// Gets whether this <see cref="EssentialsTime"/> has a reference to a specific time zone.
        /// </summary>
        [MemberNotNullWhen(true)]
        public bool HasTimeZone => TimeZone != null;

        /// <summary>
        /// Gets the wrapped <see cref="DateTimeOffset"/>.
        /// </summary>
        public DateTimeOffset DateTimeOffset { get; }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>1</c> and <c>31</c>.
        /// </summary>
        public int Day => DateTimeOffset.Day;

        /// <summary>
        /// Returns the day-of-week part of this <see cref="EssentialsTime"/>. The returned value is an integer
        /// between <c>0</c> and <c>6</c>, where <c>0</c> indicates <strong>Sunday</strong>,
        /// <c>1</c> indicates <strong>Monday</strong>, <c>2</c> indicates <strong>Tuesday</strong>,
        /// <c>3</c> indicates <strong>Wednesday</strong>, <c>4</c> indicates <strong>Thursday</strong>,
        /// <c>5</c> indicates <strong>Friday</strong>, and <c>6</c> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek => DateTimeOffset.DayOfWeek;

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>1</c> and <c>366</c>.
        /// </summary>
        public int DayOfYear => DateTimeOffset.DayOfYear;

        /// <summary>
        /// Returns a numeric value representing both the year and date.
        /// </summary>
        public int YearAndDay => Year * 1000 + DayOfYear;

        /// <summary>
        /// Gets the hour part of this <see cref="EssentialsTime"/>. The returned value is an integer between
        /// <c>0</c> and <c>23</c>.
        /// </summary>
        public int Hour => DateTimeOffset.Hour;

        /// <summary>
        /// Gets the millisecond part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>0</c> and <c>999</c>.
        /// </summary>
        public int Millisecond => DateTimeOffset.Millisecond;

        /// <summary>
        /// Gets the minute part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>0</c> and <c>59</c>.
        /// </summary>
        public int Minute => DateTimeOffset.Minute;

        /// <summary>
        /// Gets the month part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>1</c> and <c>12</c>.
        /// </summary>
        public int Month => DateTimeOffset.Month;

        /// <summary>
        /// Gets the second part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>0</c> and <c>59</c>.
        /// </summary>
        public int Second => DateTimeOffset.Second;

        /// <summary>
        /// Gets the tick count for this <see cref="EssentialsTime"/>. The returned value is the number of 100-nanosecond intervals that have elapsed since <c>1/1/0001 12:00am</c>.
        /// </summary>
        public long Ticks => DateTimeOffset.Ticks;

        /// <summary>
        /// Gets the time-of-day part of this <see cref="EssentialsTime"/>. The returned value is a <see cref="TimeSpan"/> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay => DateTimeOffset.TimeOfDay;

        /// <summary>
        /// Gets the year part of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>1</c> and <c>9999</c>.
        /// </summary>
        public int Year => DateTimeOffset.Year;

        /// <summary>
        /// Gets the quarter of this <see cref="EssentialsTime"/>. The returned value is an integer between <c>1</c> and <c>4</c>.
        /// </summary>
        public int Quarter => TimeUtils.GetQuarter(this);

        /// <summary>
        /// Gets the UNIX timestamp (amount of seconds since the start of the Unix Epoch) for this <see cref="EssentialsTime"/>.
        /// </summary>
        [Obsolete("Use 'UnixTimeSeconds' instead.")]
        public long UnixTimestamp => (long) UnixTimeUtils.ToSeconds(DateTimeOffset);

        /// <summary>
        /// Gets the UNIX timestamp in seconds (amount of time the start of the Unix Epoch) for this <see cref="EssentialsTime"/>.
        /// </summary>
        public long UnixTimeSeconds => (long) UnixTimeUtils.ToSeconds(DateTimeOffset);

        /// <summary>
        /// Gets the UNIX timestamp in milliseconds (amount of time the start of the Unix Epoch) for this <see cref="EssentialsTime"/>.
        /// </summary>
        public long UnixTimeMilliseconds => (long) UnixTimeUtils.ToMilliseconds(DateTimeOffset);

        /// <summary>
        /// Gets the time's offset from Coordinated Universal Time (UTC).
        /// </summary>
        public TimeSpan Offset => DateTimeOffset.Offset;

        /// <summary>
        /// Gets whether the year of this <see cref="EssentialsTime"/> is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(DateTimeOffset);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsTime"/> is within a weekend.
        /// </summary>
        public bool IsWeekend => TimeUtils.IsWeekend(DateTimeOffset);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsTime"/> is a weekday.
        /// </summary>
        public bool IsWeekday => TimeUtils.IsWeekday(DateTimeOffset);

        /// <summary>
        /// Gets the week number the <strong>ISO 8601</strong> week of this <see cref="EssentialsTime"/>.
        /// </summary>
        public int WeekNumber => Iso8601Utils.GetWeekNumber(DateTimeOffset);

        /// <summary>
        /// Gets the amount of days in the month.
        /// </summary>
        public int DaysInMonth => DateTime.DaysInMonth(Year, Month);

        /// <summary>
        /// Gets the English ordinal suffix of the day.
        /// </summary>
        public string DaySuffix => TimeUtils.GetDaySuffix(DateTimeOffset);

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsTime"/> is <c>0</c>.
        /// </summary>
        public bool IsZero => UnixTimeSeconds == 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsTime"/> is less than <c>0</c>.
        /// </summary>
        public bool IsNegative => UnixTimeSeconds < 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsTime"/> is greater than <c>0</c>.
        /// </summary>
        public bool IsPositive => UnixTimeSeconds > 0;

        /// <summary>
        /// Gets whether the date of this <see cref="EssentialsTime"/> matches the current day.
        /// </summary>
        public bool IsToday => ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd");

        /// <summary>
        /// Gets whether the date of this <see cref="EssentialsTime"/> matches the day after the current day.
        /// </summary>
        public bool IsTomorrow => ToString("yyyy-MM-dd") == DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");

        /// <summary>
        /// Gets whether the date of this <see cref="EssentialsTime"/> matches the day before the current day.
        /// </summary>
        public bool IsYesterday => ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        public string Iso8601 => Iso8601Utils.ToString(DateTimeOffset);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        public string Rfc822 => Rfc822Utils.ToString(DateTimeOffset);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        public string Rfc2822 => Rfc2822Utils.ToString(DateTimeOffset);

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        public string DayName => TimeUtils.GetDayName(DateTimeOffset);

        /// <summary>
        /// Gets the abbreviated English name of the day.
        /// </summary>
        public string AbbreviatedDayName => TimeUtils.GetAbbreviatedDayName(DateTimeOffset);

        /// <summary>
        /// Gets the name of the day according to the current culture.
        /// </summary>
        public string LocalDayName => TimeUtils.GetLocalDayName(DateTimeOffset);

        /// <summary>
        /// Gets the abbreviated name of the day according to the current culture.
        /// </summary>
        public string AbbreviatedLocalDayName => TimeUtils.GetAbbreviatedLocalDayName(DateTimeOffset);

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        public string MonthName => TimeUtils.GetMonthName(DateTimeOffset);

        /// <summary>
        /// Gets the abbreviated English name of the month.
        /// </summary>
        public string AbbreviatedMonthName => TimeUtils.GetAbbreviatedMonthName(DateTimeOffset);

        /// <summary>
        /// Gets the name of the month according to the current culture.
        /// </summary>
        public string LocalMonthName => TimeUtils.GetLocalMonthName(DateTimeOffset);

        /// <summary>
        /// Gets the abbreviated name of the month according to the current culture.
        /// </summary>
        public string AbbreviatedLocalMonthName => TimeUtils.GetAbbreviatedLocalMonthName(DateTimeOffset);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <see cref="System.DateTimeOffset.MinValue"/>.
        /// </summary>
        public EssentialsTime() {
            DateTimeOffset = DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="DateTime"/> the instance should be based on.</param>
        public EssentialsTime(DateTime dateTime) {
            DateTimeOffset = dateTime;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="DateTime"/> the instance should be based on.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsTime(DateTime dateTime, TimeZoneInfo timeZone) {
            dateTime = TimeZoneInfo.ConvertTime(dateTime, timeZone);
            DateTimeOffset = new DateTimeOffset(dateTime, timeZone.GetUtcOffset(dateTime));
            TimeZone = timeZone;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">An instance <see cref="DateTimeOffset"/> the instance should be based on.</param>
        public EssentialsTime(DateTimeOffset dateTimeOffset) {
            DateTimeOffset = dateTimeOffset;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="EssentialsDateTime"/> the instance should be based on.</param>
#pragma warning disable CS0618 // Type or member is obsolete
        public EssentialsTime(EssentialsDateTime dateTime) {
#pragma warning restore CS0618 // Type or member is obsolete
            if (dateTime is null) throw new ArgumentNullException(nameof(dateTime));
            DateTimeOffset = dateTime.DateTime;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="date"/>. The new instance will not have an offset.
        /// </summary>
        /// <param name="date">An instance <see cref="EssentialsDate"/> the instance should be based on.</param>
        public EssentialsTime(EssentialsDate date) {
            if (date is null) throw new ArgumentNullException(nameof(date));
            DateTimeOffset = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, TimeSpan.Zero);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="date"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="date">An instance <see cref="EssentialsDate"/> the instance should be based on.</param>
        /// <param name="offset">The offset to be used.</param>
        public EssentialsTime(EssentialsDate date, TimeSpan offset) {
            if (date is null) throw new ArgumentNullException(nameof(date));
            DateTimeOffset = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, offset);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="date"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="date">An instance <see cref="EssentialsDate"/> the instance should be based on.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsTime(EssentialsDate date, TimeZoneInfo? timeZone) {

            if (date == null) throw new ArgumentNullException(nameof(date));

            if (timeZone == null) {
                DateTimeOffset = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, TimeZoneInfo.Local.BaseUtcOffset);
                return;
            }

            DateTimeOffset dto = new(date.Year, date.Month, date.Day, 0, 0, 0, timeZone.BaseUtcOffset);

            TimeZone = timeZone;
            DateTimeOffset = TimeUtils.AdjustForTimeZoneAndDaylightSavings(dto, timeZone);

        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="DateTimeOffset"/> the instance should be based on.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsTime(DateTimeOffset dateTime, TimeZoneInfo? timeZone) {
            TimeZone = timeZone;
            DateTimeOffset = timeZone == null ? dateTime : TimeZoneInfo.ConvertTime(dateTime, timeZone);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance <see cref="EssentialsTime"/> the instance should be based on.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsTime(EssentialsTime time, TimeZoneInfo? timeZone) {
            if (time is null) throw new ArgumentNullException(nameof(time));
            TimeZone = timeZone;
            DateTimeOffset = timeZone == null ? time.DateTimeOffset : TimeZoneInfo.ConvertTime(time.DateTimeOffset, timeZone);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        public EssentialsTime(int year, int month, int day, TimeSpan offset) {
            DateTimeOffset = new DateTimeOffset(year, month, day, 0, 0, 0, offset);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param>
        public EssentialsTime(int year, int month, int day, int hour, int minute, int second, TimeSpan offset) {
            DateTimeOffset = new DateTimeOffset(year, month, day, hour, minute, second, offset);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="timeZone">The time zone indicating the time's offset from Coordinated Universal Time (UTC).</param>
        public EssentialsTime(int year, int month, int day, TimeZoneInfo? timeZone) {

            if (timeZone == null) {
                DateTimeOffset = new DateTimeOffset(year, month, day, 0, 0, 0, TimeZoneInfo.Local.BaseUtcOffset);
                return;
            }

            DateTimeOffset dto = new(year, month, day, 0, 0, 0, timeZone.BaseUtcOffset);

            TimeZone = timeZone;
            DateTimeOffset = TimeUtils.AdjustForTimeZoneAndDaylightSavings(dto, timeZone);

        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        /// <param name="timeZone">The time zone indicating the time's offset from Coordinated Universal Time (UTC).</param>
        public EssentialsTime(int year, int month, int day, int hour, int minute, int second, TimeZoneInfo? timeZone) {

            if (timeZone == null) {
                DateTimeOffset = new DateTimeOffset(year, month, day, hour, minute, second, TimeZoneInfo.Local.BaseUtcOffset);
                return;
            }

            DateTimeOffset dto = new(year, month, day, hour, minute, second, timeZone.BaseUtcOffset);

            TimeZone = timeZone;
            DateTimeOffset = TimeUtils.AdjustForTimeZoneAndDaylightSavings(dto, timeZone);

        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        /// <param name="millisecond">The milliseconds (0 through 999).</param>
        /// <param name="timeZone">The time zone indicating the time's offset from Coordinated Universal Time (UTC).</param>
        public EssentialsTime(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeZoneInfo? timeZone) {

            if (timeZone == null) {
                DateTimeOffset = new DateTimeOffset(year, month, day, hour, minute, second, millisecond, TimeZoneInfo.Local.BaseUtcOffset);
                return;
            }

            DateTimeOffset dto = new(year, month, day, hour, minute, second, millisecond, timeZone.BaseUtcOffset);

            TimeZone = timeZone;
            DateTimeOffset = TimeUtils.AdjustForTimeZoneAndDaylightSavings(dto, timeZone);

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the value of the specified <see cref="TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less than
        /// <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime Add(TimeSpan value) {
            return new EssentialsTime(DateTimeOffset.Add(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less than
        /// <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddDays(double value) {
            return new EssentialsTime(DateTimeOffset.AddDays(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of hours represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddHours(double value) {
            return new EssentialsTime(DateTimeOffset.AddHours(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of milliseconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional milliseconds. The value parameter can be negative or
        /// positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of milliseconds represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddMilliseconds(double value) {
            return new EssentialsTime(DateTimeOffset.AddMilliseconds(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of minutes represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddMinutes(double value) {
            return new EssentialsTime(DateTimeOffset.AddMinutes(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>. Or
        /// <paramref name="months"/> is less than <c>-120000</c> or greater than <c>120000</c>.</exception>
        public EssentialsTime AddMonths(int months) {
            return new EssentialsTime(DateTimeOffset.AddMonths(months), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddSeconds(double value) {
            return new EssentialsTime(DateTimeOffset.AddSeconds(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of ticks to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddTicks(long value) {
            return new EssentialsTime(DateTimeOffset.AddTicks(value), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> that adds the specified number of years to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of years represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsTime"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsTime AddYears(int value) {
            return new EssentialsTime(DateTimeOffset.AddYears(value), TimeZone);
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="System.DateTimeOffset"/> value and returns an integer that
        /// indicates whether this instance is earlier than, the same as, or later than the specified <see cref="System.DateTimeOffset"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/> parameter.</returns>
        public int CompareTo(DateTimeOffset value) {
            return DateTimeOffset.CompareTo(value);
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="EssentialsTime"/> value and returns an integer that
        /// indicates whether this instance is earlier than, the same as, or later than the specified <see cref="EssentialsTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/> parameter.</returns>
        public int CompareTo(EssentialsTime? value) {
            return DateTimeOffset.CompareTo(value?.DateTimeOffset ?? default);
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified <see cref="System.DateTimeOffset"/>
        /// value, and returns an integer that indicates whether this instance is earlier than, the same as, or later
        /// than the specified <see cref="System.DateTimeOffset"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/>
        /// parameter.</returns>
        public int CompareTo(object? value) {
            return value switch {
                null => 1,
                EssentialsTime et => DateTimeOffset.CompareTo(et.DateTimeOffset),
                DateTimeOffset dto => DateTimeOffset.CompareTo(dto),
                _ => throw new ArgumentException("Object must be of type DateTimeOffset.")
            };
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(DateTimeOffset value) {
            return DateTimeOffset.Subtract(value);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(EssentialsTime value) {
            if (value is null) throw new ArgumentNullException(nameof(value));
            return DateTimeOffset.Subtract(value.DateTimeOffset);
        }

        /// <summary>
        /// Subtracts a specified time interval from the current <see cref="EssentialsTime"/> object.
        /// </summary>
        /// <param name="value">The time interval to subtract.</param>
        /// <returns>An object that is equal to the date and time represented by the current DateTimeOffset object, minus the time interval represented by value.</returns>
        public EssentialsTime Subtract(TimeSpan value) {
            return new EssentialsTime(DateTimeOffset.Subtract(value), TimeZone);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of value of the current <see cref="EssentialsTime"/> object.</returns>
        public override string ToString() {
            return Iso8601;
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> to its equivalent string representation using the specified <paramref name="provider"/>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsTime"/> object as specified by <paramref name="provider"/>.</returns>
        public string ToString(IFormatProvider? provider) {
            return DateTimeOffset.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> to its equivalent string representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsTime"/> object as specified by <paramref name="format"/>.</returns>
        public string ToString(string format) {
            return DateTimeOffset.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> to its equivalent string representation using the specified <paramref name="format"/> and <paramref name="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsTime"/> object as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public string ToString(string format, IFormatProvider? provider) {
            return DateTimeOffset.ToString(format, provider);
        }

        /// <summary>
        /// Converts the current <see cref="EssentialsTime"/> to another instance of <see cref="EssentialsTime"/> that represents the local time.
        /// </summary>
        /// <returns>An object that represents the date and time of the current <see cref="EssentialsTime"/> object converted to local time.</returns>
        public EssentialsTime ToLocalTime() {
            return new EssentialsTime(DateTimeOffset.ToLocalTime(), TimeZoneInfo.Local);
        }

        /// <summary>
        /// Converts the current <see cref="EssentialsTime"/> to another instance of <see cref="EssentialsTime"/> that represents the Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object that represents the date and time of the current <see cref="EssentialsTime"/> object converted to Coordinated Universal Time (UTC).</returns>
        public EssentialsTime ToUniversalTime() {
            return new EssentialsTime(DateTimeOffset.ToUniversalTime(), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> object to the date and time specified by an offset value.
        /// </summary>
        /// <param name="offset">The offset to convert the <see cref="EssentialsTime"/> value to.</param>
        /// <returns>An object that is equal to the original <see cref="EssentialsTime"/> object (that is, their <see cref="ToUniversalTime"/> methods return identical points in time) but whose <see cref="Offset"/> property is set to <paramref name="offset"/>.</returns>.
        public EssentialsTime ToOffset(TimeSpan offset) {
            return new EssentialsTime(DateTimeOffset.ToOffset(offset));
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsTime"/> to the corresponding date according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An object that is equal to the original <see cref="EssentialsTime"/> object (that is, their <see cref="ToUniversalTime"/> methods return identical points in time) but whose <see cref="Offset"/> property is adjusted according to <paramref name="timeZone"/>.</returns>.
        public EssentialsTime ToTimeZone(TimeZoneInfo timeZone) {
            if (timeZone == null) throw new ArgumentNullException(nameof(timeZone));
            return new EssentialsTime(DateTimeOffset, timeZone);
        }

        /// <summary>
        /// Returns the number of milliseconds that have elapsed since the start of the Unix epoch (<c>1st of January, 1970 - 00:00:00 GMT</c>).
        /// </summary>
        /// <returns>The number of milliseconds that have elapsed since the start of the Unix epoch (<c>1st of January, 1970 - 00:00:00 GMT</c>).</returns>
        /// <seealso>
        ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset.tounixtimeseconds?view=netstandard-2.0</cref>
        /// </seealso>
        public long ToUnixTimeSeconds() {
            return (long) UnixTimeUtils.ToSeconds(DateTimeOffset);
        }

        /// <summary>
        /// Returns the number of milliseconds that have elapsed since the start of the Unix epoch (<c>1st of January, 1970 - 00:00:00 GMT</c>).
        /// </summary>
        /// <returns>The number of milliseconds that have elapsed since the start of the Unix epoch (<c>1st of January, 1970 - 00:00:00 GMT</c>).</returns>
        /// <seealso>
        ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset.tounixtimemilliseconds?view=netstandard-2.0</cref>
        /// </seealso>
        public long ToUnixTimeMilliseconds() {
            return (long) UnixTimeUtils.ToMilliseconds(DateTimeOffset);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the day.
        ///
        /// If <see cref="TimeZone"/> is present, the start of the day will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay() {
            return new EssentialsTime(TimeUtils.GetStartOfDay(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the day.
        ///
        /// The start of the day will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetStartOfDay(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the day.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay() {
            return new EssentialsTime(TimeUtils.GetEndOfDay(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the day.
        ///
        /// The end of the day will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetEndOfDay(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the week.
        ///
        /// If <see cref="TimeZone"/> is present, the start of the week will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek() {
            return new EssentialsTime(TimeUtils.GetStartOfWeek(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the week.
        ///
        /// The start of the week will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetStartOfWeek(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek() {
            return new EssentialsTime(TimeUtils.GetEndOfWeek(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the week.
        ///
        /// The end of the week will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetEndOfWeek(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the month.
        ///
        /// If <see cref="TimeZone"/> is present, the start of the month will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth() {
            return new EssentialsTime(TimeUtils.GetStartOfMonth(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the start of the month.
        ///
        /// The start of the month will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetStartOfMonth(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the month.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth() {
            return new EssentialsTime(TimeUtils.GetEndOfMonth(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsTime"/> representing the end of the month.
        ///
        /// The end of the month will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetEndOfMonth(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the start of the quarter.
        ///
        /// If <see cref="TimeZone"/> is present, the start of the quarter will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfQuarter() {
            return new EssentialsTime(TimeUtils.GetStartOfQuarter(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the start of the quarter.
        ///
        /// The start of the quarter will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfQuarter(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetStartOfQuarter(DateTimeOffset, timeZone), timeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the end of the quarter.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfQuarter() {
            return new EssentialsTime(TimeUtils.GetEndOfQuarter(DateTimeOffset, TimeZone), TimeZone);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> representing the end of the quarter.
        ///
        /// The end of the quarter will be adjusted according to the time zone and daylight saving.
        /// </summary>
        /// <param name="timeZone">The time zone for which the time will be adjusted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfQuarter(TimeZoneInfo? timeZone) {
            return new EssentialsTime(TimeUtils.GetEndOfQuarter(DateTimeOffset, timeZone), timeZone);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="input">The input string to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("input")]
        public static EssentialsTime? Parse(string? input) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTimeOffset dto = DateTimeOffset.Parse(input);

            // Intialize a new instance
            return new EssentialsTime(dto);

        }

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="input">The input string to be parsed.</param>
        /// <param name="provider">An object that provides culture-specific format information about input.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("input")]
        public static EssentialsTime? Parse(string? input, IFormatProvider? provider) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTimeOffset dto = DateTimeOffset.Parse(input, provider);

            // Intialize a new instance
            return new EssentialsTime(dto);

        }

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="input">The input string to be parsed.</param>
        /// <param name="provider">An object that provides culture-specific format information about input.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of input. A typical value to specify is <see cref="DateTimeStyles.None"/>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("input")]
        public static EssentialsTime? Parse(string? input, IFormatProvider? provider, DateTimeStyles styles) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTimeOffset dto = DateTimeOffset.Parse(input, provider, styles);

            // Intialize a new instance
            return new EssentialsTime(dto);

        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its
        /// <see cref="EssentialsTime"/> equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="str">A string containing a date and time to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsTime"/> value
        /// equivalent to the date and time contained in <paramref name="str"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed. The conversion fails if the <paramref name="str"/> parameter is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a date and
        /// time. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string? str, [NotNullWhen(true)] out EssentialsTime? result) {

            // Make sure "offset" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(str)) return false;

            // Attempt to parse the date
            if (DateTimeOffset.TryParse(str, out DateTimeOffset dto)) {
                result = new EssentialsTime(dto);
            }

            return result != null;

        }

        /// <summary>
        /// Tries to convert a specified string representation of a date and time to its <see cref="EssentialsTime"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains a date and time to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about input.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of input.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsTime"/> value equivalent to
        /// the date and time of input, if the conversion succeeded, or <c>null</c>, if the conversion failed. The
        /// conversion fails if the input parameter is null or does not contain a valid string representation of a date
        /// and time. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string? input, IFormatProvider? provider, DateTimeStyles styles, [NotNullWhen(true)] out EssentialsTime? result) {

            // Make sure "offset" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Attempt to parse the date
            if (DateTimeOffset.TryParse(input, provider, styles, out DateTimeOffset dto)) {
                result = new EssentialsTime(dto);
            }

            return result is not null;

        }

        /// <summary>
        /// Converts the specified <paramref name="iso8601"/> formatted date and time to its <see cref="EssentialsTime"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="iso8601">The string with the ISO 8601 formatted date and time.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsTime"/> value
        /// equivalent to the date and time contained in <paramref name="iso8601"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="iso8601"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseIso8601(string? iso8601, [NotNullWhen(true)] out EssentialsTime? result) {

            if (Iso8601Utils.TryParse(iso8601, out DateTimeOffset dto)) {
                result = new EssentialsTime(dto);
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> formatted date and time to its <see cref="EssentialsTime"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsTime"/> value
        /// equivalent to the date and time contained in <paramref name="rfc822"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseRfc822(string? rfc822, [NotNullWhen(true)] out EssentialsTime? result) {

            if (Rfc822Utils.TryParse(rfc822, out DateTimeOffset dto)) {
                result = new EssentialsTime(dto);
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Converts the specified <paramref name="rfc2822"/> formatted date and time to its <see cref="EssentialsTime"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="rfc2822">The string with the RFC 2822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsTime"/> value
        /// equivalent to the date and time contained in <paramref name="rfc2822"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc2822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseRfc2822(string? rfc2822, [NotNullWhen(true)] out EssentialsTime? result) {

            if (Rfc2822Utils.TryParse(rfc2822, out DateTimeOffset dto)) {
                result = new EssentialsTime(dto);
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [Obsolete("Use 'FromUnixTimeSeconds' method instead.")]
        public static EssentialsTime FromUnixTimestamp(int timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [Obsolete("Use 'FromUnixTimeSeconds' method instead.")]
        public static EssentialsTime FromUnixTimestamp(long timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [Obsolete("Use 'FromUnixTimeSeconds' method instead.")]
        public static EssentialsTime FromUnixTimestamp(double timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeSeconds(int timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeSeconds(long timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeSeconds(double timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in milliseconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeMilliseconds(int timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromMilliseconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in milliseconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeMilliseconds(long timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in milliseconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromUnixTimeMilliseconds(double timestamp) {
            return new EssentialsTime(UnixTimeUtils.FromSeconds(timestamp), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Convert the specified <strong>ISO 8601</strong> string to an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="value">The <strong>ISO 8601</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("value")]
        public static EssentialsTime? FromIso8601(string? value) {
            return string.IsNullOrWhiteSpace(value) ? null : new EssentialsTime(Iso8601Utils.Parse(value));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromIso8601Week(int year, int week) {
            return new EssentialsTime(Iso8601Utils.FromWeekNumber(year, week));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="offset">The offset to convert the <see cref="EssentialsTime"/> value to.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromIso8601Week(int year, int week, TimeSpan offset) {
            return new EssentialsTime(Iso8601Utils.FromWeekNumber(year, week, offset));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromIso8601Week(int year, int week, TimeZoneInfo? timeZone) {
            return new EssentialsTime(Iso8601Utils.FromWeekNumber(year, week, timeZone), timeZone);
        }

        /// <summary>
        /// Convert the specified <strong>RFC 822</strong> string to an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("str")]
        public static EssentialsTime? FromRfc822(string? str) {
            return string.IsNullOrWhiteSpace(str) ? null : new EssentialsTime(Rfc822Utils.Parse(str));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 2822</strong> string to an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 2822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [return: NotNullIfNotNull("str")]
        public static EssentialsTime? FromRfc2822(string? str) {
            return string.IsNullOrWhiteSpace(str) ? null : new EssentialsTime(Rfc2822Utils.Parse(str));
        }

        /// <summary>
        /// Converts the specified <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/> and
        /// <strong>Swatch Internet Time </strong> <paramref name="beats"/> into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the converted time and date.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
        /// </see>
        public static EssentialsTime FromSwatchInternetTime(int year, int month, int day, double beats) {
            return FromSwatchInternetTime(year, month, day, beats, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Converts the specified <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/> and
        /// <strong>Swatch Internet Time </strong> <paramref name="beats"/> into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the converted time and date.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
        /// </see>
        public static EssentialsTime FromSwatchInternetTime(int year, int month, int day, double beats, TimeZoneInfo? timeZone) {

            timeZone ??= TimeZoneInfo.Local;

            DateTimeOffset dto = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(1))
                .Add(SwatchUtils.ToTimeSpan(beats));

            return new EssentialsTime(dto, timeZone);

        }

        /// <summary>
        /// Converts the specified <paramref name="date"/> and <strong>Swatch Internet Time </strong>
        /// <paramref name="beats"/> into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the converted time and date.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
        /// </see>
        public static EssentialsTime FromSwatchInternetTime(EssentialsDate date, double beats) {
            if (date == null) throw new ArgumentNullException(nameof(date));
            return FromSwatchInternetTime(date.Year, date.Month, date.Day, beats, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Converts the specified <paramref name="date"/> and <strong>Swatch Internet Time </strong>
        /// <paramref name="beats"/> into an instance of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> representing the converted time and date.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
        /// </see>
        public static EssentialsTime FromSwatchInternetTime(EssentialsDate date, double beats, TimeZoneInfo? timeZone) {
            if (date == null) throw new ArgumentNullException(nameof(date));
            timeZone ??= TimeZoneInfo.Local;
            return FromSwatchInternetTime(date.Year, date.Month, date.Day, beats, timeZone);
        }

        /// <summary>
        /// Creates a new <see cref="EssentialsTime"/> instance from the specified amount of <paramref name="ticks"/>.
        /// </summary>
        /// <param name="ticks">The amount of ticks.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromTicks(long ticks) {
            DateTime time = new(ticks);
            return new EssentialsTime(time, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Creates a new <see cref="EssentialsTime"/> instance from the specified amount of <paramref name="ticks"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="ticks">The amount of ticks.</param>
        /// <param name="offset">The offset to UTC.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromTicks(long ticks, TimeSpan offset) {
            return new EssentialsTime(new DateTimeOffset(ticks, offset));
        }

        /// <summary>
        /// Creates a new <see cref="EssentialsTime"/> instance from the specified amount of <paramref name="ticks"/> and <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="ticks">The amount of ticks.</param>
        /// <param name="timeZone">The time zone to be used. Uses <see cref="TimeZoneInfo.Local"/> if <c>null</c>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime FromTicks(long ticks, TimeZoneInfo? timeZone) {
            DateTime time = new(ticks);
            return new EssentialsTime(time, timeZone ?? TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns the timestamp representing the earliest point in time.
        /// </summary>
        /// <param name="a">The first timestamp.</param>
        /// <param name="b">The second timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Min(EssentialsTime a, EssentialsTime b) {
            return a > b ? b : a;
        }

        /// <summary>
        /// Returns the timestamp representing the earliest point in time.
        /// </summary>
        /// <param name="a">The first timestamp.</param>
        /// <param name="b">The second timestamp.</param>
        /// <param name="c">The third timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Min(EssentialsTime a, EssentialsTime b, EssentialsTime c) {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// Returns the timestamp representing the earliest point in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsTime"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Min(params EssentialsTime[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the timestamp representing the earliest point in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsTime"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Min(IEnumerable<EssentialsTime> values) {
            return values.Min(x => x)!;
        }

        /// <summary>
        /// Returns the timestamp representing the latest point in time.
        /// </summary>
        /// <param name="a">The first timestamp.</param>
        /// <param name="b">The second timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Max(EssentialsTime a, EssentialsTime b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// Returns the timestamp representing the latest point in time.
        /// </summary>
        /// <param name="a">The first timestamp.</param>
        /// <param name="b">The second timestamp.</param>
        /// <param name="c">The third timestamp.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Max(EssentialsTime a, EssentialsTime b, EssentialsTime c) {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// Returns the timestamp representing the latest point in time.
        /// </summary>
        /// <param name="values">An array of <see cref="EssentialsTime"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Max(params EssentialsTime[] values) {
            if (values.Length == 0) throw new ArgumentException("Specified array must not be empty.");
            return values.Max(x => x)!;
        }

        /// <summary>
        /// Returns the timestamp representing the latest point in time.
        /// </summary>
        /// <param name="values">A collection of <see cref="EssentialsTime"/> instances.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime Max(IEnumerable<EssentialsTime> values) {
            return values.Max(x => x)!;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> from the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static implicit operator EssentialsTime(DateTime timestamp) {
            return new EssentialsTime(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/>.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static implicit operator EssentialsTime(DateTimeOffset timestamp) {
            return new EssentialsTime(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        [Obsolete("Use FromUnixTimestamp(long) method instead.")]
        public static implicit operator EssentialsTime(long timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        [Obsolete("Use FromUnixTimestamp(double) method instead.")]
        public static implicit operator EssentialsTime(double timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Adds <paramref name="date"/> and <paramref name="timespan"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be added to <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime operator +(EssentialsTime date, TimeSpan timespan) {
            return new EssentialsTime(date.DateTimeOffset + timespan);
        }

        /// <summary>
        /// Subtracts <paramref name="timespan"/> from <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be subtracted from <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime operator -(EssentialsTime date, TimeSpan timespan) {
            return new EssentialsTime(date.DateTimeOffset - timespan);
        }

        /// <summary>
        /// Subtracts two instances of <see cref="EssentialsTime"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns>The result as an instance of <see cref="TimeSpan"/>.</returns>
        public static TimeSpan operator -(EssentialsTime d1, EssentialsTime d2) {
            return d1.DateTimeOffset - d2.DateTimeOffset;
        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsTime"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if the two instances represent the same date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator ==(EssentialsTime? d1, EssentialsTime? d2) {

            // Check for NULL conditions
            if (d1 is null) return d2 is null;
            if (d2 is null) return false;

            // Pass the comparison on the the == operator of DateTime
            return d1.DateTimeOffset == d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsTime"/> are different
        /// from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if the two instances represents a different date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator !=(EssentialsTime? d1, EssentialsTime? d2) {
            return !(d1 == d2);
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than <paramref name="d2"/>, otherwise
        /// <c>false</c>.</returns>
        public static bool operator <(EssentialsTime? d1, EssentialsTime? d2) {

            // Check for NULL conditions
            if (d1 is null) return d2 is not null;
            if (d2 is null) return false;

            // Pass the comparison on the the < operator of DateTime
            return d1.DateTimeOffset < d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator <=(EssentialsTime? d1, EssentialsTime? d2) {
            return d1 < d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >(EssentialsTime? d1, EssentialsTime? d2) {

            // Check for NULL conditions
            if (d2 is null) return d1 is not null;
            if (d1 is null) return false;

            // Pass the comparison on the the > operator of DateTime
            return d1.DateTimeOffset > d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsTime"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >=(EssentialsTime? d1, EssentialsTime? d2) {
            return d1 > d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsTime"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsTime"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(object? obj) {
            EssentialsTime? time = obj as EssentialsTime;
            return time != null && (this == time);
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsTime"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return DateTimeOffset.GetHashCode();
        }

        #endregion

    }

}