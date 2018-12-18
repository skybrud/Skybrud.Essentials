using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class wrapping an instance of <see cref="DateTimeOffset"/> (as an alternative to using <see cref="Nullable{DateTimeOffset}"/>).
    /// </summary>
    public class EssentialsDateTimeOffset : IComparable, IComparable<EssentialsDateTimeOffset>, IComparable<DateTimeOffset> {

        #region Static properties

        /// <summary>
        /// Gets a <see cref="EssentialsDateTimeOffset"/> object that is set to the current date and time on this computer,  expressed as the local time.
        /// </summary>
        public static EssentialsDateTimeOffset Now => new EssentialsDateTimeOffset(DateTimeOffset.Now);

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTimeOffset"/> representing the current date, according to the local time.
        /// </summary>
        public static EssentialsDateTimeOffset Today => new EssentialsDateTimeOffset(DateTime.Today);

        /// <summary>
        /// Gets a <see cref="EssentialsDateTimeOffset"/> object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsDateTimeOffset UtcNow => new EssentialsDateTimeOffset(DateTimeOffset.UtcNow);

        /// <summary>
        /// Represents the earliest possible <see cref="EssentialsDateTimeOffset"/> value.
        /// </summary>
        public static EssentialsDateTimeOffset MinValue => new EssentialsDateTimeOffset(DateTimeOffset.MinValue);

        /// <summary>
        /// Represents the greatest possible value of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        public static EssentialsDateTimeOffset MaxValue => new EssentialsDateTimeOffset(DateTimeOffset.MaxValue);

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTimeOffset"/> representing the start of the Unix Epoch (AKA <c>0</c> seconds).
        /// </summary>
        public static EssentialsDateTimeOffset Zero => FromUnixTimestamp(0);

        #endregion

        #region Member properties

        /// <summary>
        /// Gets the wrapped <see cref="DateTimeOffset"/>.
        /// </summary>
        public DateTimeOffset DateTimeOffset { get; }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>1</c> and <c>31</c>.
        /// </summary>
        public int Day => DateTimeOffset.Day;

        /// <summary>
        /// Returns the day-of-week part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer
        /// between <c>0</c> and <c>6</c>, where <c>0</c> indicates <strong>Sunday</strong>,
        /// <c>1</c> indicates <strong>Monday</strong>, <c>2</c> indicates <strong>Tuesday</strong>,
        /// <c>3</c> indicates <strong>Wednesday</strong>, <c>4</c> indicates <strong>Thursday</strong>,
        /// <c>5</c> indicates <strong>Friday</strong>, and <c>6</c> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek => DateTimeOffset.DayOfWeek;

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>1</c> and <c>366</c>.
        /// </summary>
        public int DayOfYear => DateTimeOffset.DayOfYear;

        /// <summary>
        /// Gets the hour part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between
        /// <c>0</c> and <c>23</c>.
        /// </summary>
        public int Hour => DateTimeOffset.Hour;

        /// <summary>
        /// Gets the millisecond part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>0</c> and <c>999</c>.
        /// </summary>
        public int Millisecond => DateTimeOffset.Millisecond;


        /// <summary>
        /// Gets the minute part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>0</c> and <c>59</c>.
        /// </summary>
        public int Minute => DateTimeOffset.Minute;

        /// <summary>
        /// Gets the month part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>1</c> and <c>12</c>.
        /// </summary>
        public int Month => DateTimeOffset.Month;

        /// <summary>
        /// Gets the second part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>0</c> and <c>59</c>.
        /// </summary>
        public int Second => DateTimeOffset.Second;

        /// <summary>
        /// Gets the tick count for this <see cref="EssentialsDateTimeOffset"/>. The returned value is the number of 100-nanosecond intervals that have elapsed since <c>1/1/0001 12:00am</c>.
        /// </summary>
        public long Ticks => DateTimeOffset.Ticks;

        /// <summary>
        /// Gets the time-of-day part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is a <see cref="TimeSpan"/> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay => DateTimeOffset.TimeOfDay;

        /// <summary>
        /// Gets the year part of this <see cref="EssentialsDateTimeOffset"/>. The returned value is an integer between <c>1</c> and <c>9999</c>.
        /// </summary>
        public int Year => DateTimeOffset.Year;

        /// <summary>
        /// Gets the UNIX timestamp (amount of seconds since the start of the Unix Epoch) for this <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        public long UnixTimestamp => TimeUtils.GetUnixTimeFromDateTimeOffset(DateTimeOffset);

        /// <summary>
        /// Gets the time's offset from Coordinated Universal Time (UTC).
        /// </summary>
        public TimeSpan Offset => DateTimeOffset.Offset;

        /// <summary>
        /// Gets whether the year of this <see cref="EssentialsDateTimeOffset"/> is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(DateTimeOffset);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTimeOffset"/> is within a weekend.
        /// </summary>
        public bool IsWeekend => TimeUtils.IsLeapYear(DateTimeOffset);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTimeOffset"/> is a weekday.
        /// </summary>
        public bool IsWeekday => TimeUtils.IsWeekday(DateTimeOffset);

        /// <summary>
        /// Gets the week number the <strong>ISO 8601</strong> week of this <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        public int WeekNumber => TimeUtils.GetIso8601WeekNumber(DateTimeOffset);

        /// <summary>
        /// Gets the amount of days in the month.
        /// </summary>
        public int DaysInMonth => DateTime.DaysInMonth(Year, Month);

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTimeOffset"/> is <c>0</c>.
        /// </summary>
        public bool IsZero => UnixTimestamp == 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTimeOffset"/> is less than <c>0</c>.
        /// </summary>
        public bool IsNegative => UnixTimestamp < 0;

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTimeOffset"/> is greater than <c>0</c>.
        /// </summary>
        public bool IsPositive => UnixTimestamp > 0;

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        public string Iso8601 => TimeUtils.ToIso8601(DateTimeOffset);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        public string Rfc822 => TimeUtils.ToRfc822(DateTimeOffset);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        public string Rfc2822 => TimeUtils.ToRfc2822(DateTimeOffset);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <see cref="System.DateTimeOffset.MinValue"/>.
        /// </summary>
        public EssentialsDateTimeOffset() {
            DateTimeOffset = DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="DateTime"/> the instance should be based on.</param>
        public EssentialsDateTimeOffset(DateTime dateTime) {
            DateTimeOffset = dateTime;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">An instance <see cref="DateTimeOffset"/> the instance should be based on.</param>
        public EssentialsDateTimeOffset(DateTimeOffset dateTimeOffset) {
            DateTimeOffset = dateTimeOffset;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">An instance <see cref="EssentialsDateTime"/> the instance should be based on.</param>
        public EssentialsDateTimeOffset(EssentialsDateTime dateTime) {
            DateTimeOffset = dateTime.DateTime;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTimeOffset"/> using the specified  <paramref name="year"/>, <paramref name="month"/>,
        /// <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        /// <param name="hour">The hours (0 through 23).</param>
        /// <param name="minute">The minutes (0 through 59).</param>
        /// <param name="second">The seconds (0 through 59).</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param> 
        public EssentialsDateTimeOffset(int year, int month, int day, int hour, int minute, int second, TimeSpan offset) {
            DateTimeOffset = new DateTimeOffset(year, month, day, hour, minute, second, offset);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the value of the specified <see cref="TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less than
        /// <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset Add(TimeSpan value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.Add(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less than
        /// <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddDays(double value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddDays(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of hours represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddHours(double value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddHours(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of milliseconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional milliseconds. The value parameter can be negative or
        /// positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of milliseconds represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddMilliseconds(double value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddMilliseconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of minutes represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddMinutes(double value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddMinutes(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>. Or
        /// <paramref name="months"/> is less than <c>-120000</c> or greater than <c>120000</c>.</exception>
        public EssentialsDateTimeOffset AddMonths(int months) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddMonths(months));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of seconds to the value of this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of seconds represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddSeconds(double value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddSeconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of ticks to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddTicks(long value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddTicks(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTimeOffset"/> that adds the specified number of years to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of years represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTimeOffset"/> is less
        /// than <see cref="System.DateTimeOffset.MinValue"/> or greater than <see cref="System.DateTimeOffset.MaxValue"/>.</exception>
        public EssentialsDateTimeOffset AddYears(int value) {
            return new EssentialsDateTimeOffset(DateTimeOffset.AddYears(value));
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
        /// Compares the value of this instance to a specified <see cref="EssentialsDateTimeOffset"/> value and returns an integer that
        /// indicates whether this instance is earlier than, the same as, or later than the specified <see cref="EssentialsDateTimeOffset"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <paramref name="value"/> parameter.</returns>
        public int CompareTo(EssentialsDateTimeOffset value) {
            return DateTimeOffset.CompareTo(value == null ? default(DateTimeOffset) : value.DateTimeOffset);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(DateTimeOffset value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return DateTimeOffset.Subtract(value);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(EssentialsDateTimeOffset value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return DateTimeOffset.Subtract(value.DateTimeOffset);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTimeOffset"/> to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTimeOffset"/> object.</returns>
        public override string ToString() {
            return DateTimeOffset.ToString(DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTimeOffset"/> to its equivalent string representation using the specified <paramref name="provider"/>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTimeOffset"/> object as specified by <paramref name="provider"/>.</returns>
        public string ToString(IFormatProvider provider) {
            return DateTimeOffset.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTimeOffset"/> to its equivalent string representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTimeOffset"/> object as specified by <paramref name="format"/>.</returns>
        public string ToString(string format) {
            return DateTimeOffset.ToString(format);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTimeOffset"/> to its equivalent string representation using the specified <paramref name="format"/> and <paramref name="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTimeOffset"/> object as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return DateTimeOffset.ToString(format, provider);
        }

        /// <summary>
        /// Converts the current <see cref="EssentialsDateTimeOffset"/> to another instance of <see cref="EssentialsDateTimeOffset"/> that represents the local time.
        /// </summary>
        /// <returns>An object that represents the date and time of the current <see cref="EssentialsDateTimeOffset"/> object converted to local time.</returns>
        public EssentialsDateTimeOffset ToLocalTime() {
            return new EssentialsDateTimeOffset(DateTimeOffset.ToLocalTime());
        }

        /// <summary>
        /// Converts the current <see cref="EssentialsDateTimeOffset"/> to another instance of <see cref="EssentialsDateTimeOffset"/> that represents the Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object that represents the date and time of the current <see cref="EssentialsDateTimeOffset"/> object converted to Coordinated Universal Time (UTC).</returns>
        public EssentialsDateTimeOffset ToUniversalTime() {
            return new EssentialsDateTimeOffset(DateTimeOffset.ToUniversalTime());
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTimeOffset"/> object to the date and time specified by an offset value.
        /// </summary>
        /// <param name="offset">The offset to convert the <see cref="EssentialsDateTimeOffset"/> value to.</param>
        /// <returns>An object that is equal to the original <see cref="EssentialsDateTimeOffset"/> object (that is, their <see cref="ToUniversalTime"/> methods return identical points in time) but whose <see cref="Offset"/> property is set to <paramref name="offset"/>.</returns>.
        public EssentialsDateTimeOffset ToOffset(TimeSpan offset) {
            return new EssentialsDateTimeOffset(DateTimeOffset.ToOffset(offset));
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsDateTimeOffset"/> representing the start of the day.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public EssentialsDateTimeOffset GetStartOfDay() {
            return new EssentialsDateTimeOffset(Year, Month, Day, 0, 0, 0, Offset);
        }

        /// <summary>
        /// Gets a new instance of <see cref="EssentialsDateTimeOffset"/> representing the end of the day.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public EssentialsDateTimeOffset GetEndOfDay() {
            return new EssentialsDateTimeOffset(Year, Month, Day, 23, 59, 59, Offset);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <param name="input">The input string to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset Parse(string input) {
            
            // Is "input" an empty string?
            if (String.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTimeOffset dto = DateTimeOffset.Parse(input);

            // Intialize a new instance
            return new EssentialsDateTimeOffset(dto);

        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its
        /// <see cref="EssentialsDateTimeOffset"/> equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="str">A string containing a date and time to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsDateTimeOffset"/> value
        /// equivalent to the date and time contained in <paramref name="str"/>, if the conversion succeeded, or
        /// <c>null</c> if the conversion failed. The conversion fails if the <paramref name="str"/> parameter is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a date and
        /// time. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <paramref name="str"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string str, out EssentialsDateTimeOffset result) {

            // Make sure "offset" is initialized
            result = null;

            // Is "input" an empty string?
            if (String.IsNullOrWhiteSpace(str)) return false;

            // Attempt to parse the date
            if (DateTimeOffset.TryParse(str, out DateTimeOffset dto)) {
                result = new EssentialsDateTimeOffset(dto);
            }

            return result != null;

        }
        
        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromUnixTimestamp(int timestamp) {
            return new EssentialsDateTimeOffset(TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTimeOffset FromUnixTimestamp(long timestamp) {
            return new EssentialsDateTimeOffset(TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTimeOffset FromUnixTimestamp(double timestamp) {
            return new EssentialsDateTimeOffset(TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp));
        }

        /// <summary>
        /// Convert the specified <strong>ISO 8601</strong> string to an instance of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <strong>ISO 8601</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromIso8601(string value) {
            return new EssentialsDateTimeOffset(TimeUtils.Iso8601ToDateTimeOffset(value));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromIso8601Week(int year, int week) {
            return new EssentialsDateTimeOffset(TimeUtils.GetDateTimeOffsetFromIso8601Week(year, week));
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTimeOffset"/> representing the start of the specified <strong>ISO 8601</strong> <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The <strong>ISO 8601</strong> year of the week.</param>
        /// <param name="week">The <strong>ISO 8601</strong> week number.</param>
        /// <param name="offset">The offset to convert the <see cref="EssentialsDateTimeOffset"/> value to.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromIso8601Week(int year, int week, TimeSpan offset) {
            return new EssentialsDateTimeOffset(TimeUtils.GetDateTimeOffsetFromIso8601Week(year, week, offset));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 822</strong> string to an instance of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromRfc822(string str) {
            return new EssentialsDateTimeOffset(TimeUtils.Rfc822ToDateTimeOffset(str));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 2822</strong> string to an instance of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 2822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset FromRfc2822(string str) {
            return new EssentialsDateTimeOffset(TimeUtils.Rfc822ToDateTimeOffset(str));
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTimeOffset"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/>.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static implicit operator EssentialsDateTimeOffset(DateTimeOffset timestamp) {
            return new EssentialsDateTimeOffset(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static implicit operator EssentialsDateTimeOffset(long timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTimeOffset"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static implicit operator EssentialsDateTimeOffset(double timestamp) {
            return FromUnixTimestamp(timestamp);
        }

        /// <summary>
        /// Adds <paramref name="date"/> and <paramref name="timespan"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be added to <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset operator +(EssentialsDateTimeOffset date, TimeSpan timespan) {
            return new EssentialsDateTimeOffset(date.DateTimeOffset + timespan);
        }

        /// <summary>
        /// Subtracts <paramref name="timespan"/> from <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timespan">The time that should be subtracted from <paramref name="date"/>.</param>
        /// <returns>The result as a new instance of <see cref="EssentialsDateTimeOffset"/>.</returns>
        public static EssentialsDateTimeOffset operator -(EssentialsDateTimeOffset date, TimeSpan timespan) {
            return new EssentialsDateTimeOffset(date.DateTimeOffset - timespan);
        }

        /// <summary>
        /// Subtracts two instances of <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns>The result as an instance of <see cref="TimeSpan"/>.</returns>
        public static TimeSpan operator -(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {
            return d1.DateTimeOffset - d2.DateTimeOffset;
        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTimeOffset"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if the two instances represent the same date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator ==(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {

            // Check for NULL conditions
            object value1 = d1;
            object value2 = d2;
            if (value1 == null) return value2 == null;
            if (value2 == null) return false;

            // Pass the comparison on the the == operator of DateTime
            return d1.DateTimeOffset == d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTimeOffset"/> are different
        /// from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if the two instances represents a different date and time, otherwise
        /// <c>false</c>.</returns>
        public static bool operator !=(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {
            return !(d1 == d2);
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than <paramref name="d2"/>, otherwise
        /// <c>false</c>.</returns>
        public static bool operator <(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {

            // Check for NULL conditions
            if (d1 == null) return d2 != null;
            if (d2 == null) return false;

            // Pass the comparison on the the < operator of DateTime
            return d1.DateTimeOffset < d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is less than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is less than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator <=(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {
            return d1 < d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {

            // Check for NULL conditions
            if (d2 == null) return d1 != null;
            if (d1 == null) return false;

            // Pass the comparison on the the > operator of DateTime
            return d1.DateTimeOffset > d2.DateTimeOffset;

        }

        /// <summary>
        /// Gets whether <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTimeOffset"/>.</param>
        /// <returns><c>true</c> if <paramref name="d1"/> is greater than or equal to <paramref name="d2"/>,
        /// otherwise <c>false</c>.</returns>
        public static bool operator >=(EssentialsDateTimeOffset d1, EssentialsDateTimeOffset d2) {
            return d1 > d2 || d1 == d2;
        }

        public int CompareTo(object value) {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets whether this <see cref="EssentialsDateTimeOffset"/> equals the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Whether this <see cref="EssentialsDateTimeOffset"/> equals the specified <paramref name="obj"/>.</returns>
        public override bool Equals(Object obj) {
            EssentialsDateTimeOffset time = obj as EssentialsDateTimeOffset;
            return time != null && (this == time);
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDateTimeOffset"/>.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() {
            return DateTimeOffset.GetHashCode();
        }

        #endregion

    }

}